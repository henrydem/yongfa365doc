using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AboutString
{
    class Program
    {
        //本示例测试方法相同

        static void Main(string[] args)
        {
            Console.WriteLine(string.Compare("list.aspx","List.aspx",true));
            Console.WriteLine(string.Compare("list.aspx", "sadf"));
            Console.ReadKey(); 

            string aaa="我,";
            Console.WriteLine(System.Text.Encoding.GetEncoding(936).GetBytes("我是1").Length);
            Console.WriteLine(Regex.Replace(aaa, "[^\x00-\xff]", "aa").Length); //没有上面的快，但比上面的通用，可判断所有双字节字符
            Console.WriteLine(aaa.Remove(aaa.Length-1));
            Console.ReadKey(); 

            Console.WriteLine("{0}String.PadLeft{0}", new string('=', 20));
            string[] strTemp = { "12", "1", "234", "12345" };
            foreach (string item in strTemp)
            {
                Console.WriteLine(item.PadLeft(6,'0'));
            }
            Console.ReadKey(); 


            char[] sArr = new char[10000];
            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                    sArr[i] = 'A';
                else
                    sArr[i] = 'B';
            }
            string s = new string(sArr);
            for (int i = 0; i < sArr.Length; i++)
            {
                if (i % 10 == 0)
                    s = s.Insert(i, "中国人");
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)//这个算法用时：22毫秒左右
                Truncate(s, 255);
            sw.Stop();
            Console.WriteLine("字符串截取的方法Truncate: " + sw.Elapsed.TotalMilliseconds + "ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000; i++) //这个用时271毫秒左右
                CutString(s, 255, true, CutType.Varchar);
            sw.Stop();
            Console.WriteLine("字符串截取的方法CutString: " + sw.Elapsed.TotalMilliseconds + "ms");


            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000; i++) //这个用时271毫秒左右
                Truncate002(s, 255);
            sw.Stop();
            Console.WriteLine("字符串截取的方法Truncate002: " + sw.Elapsed.TotalMilliseconds + "ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000; i++) //这个用时540毫秒左右
                Truncate004(s, 255);
            sw.Stop();
            Console.WriteLine("字符串截取的方法Truncate004: " + sw.Elapsed.TotalMilliseconds + "ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000; i++) //这个用时1784毫秒左右
                Truncate001(s, 255);
            sw.Stop();

            Console.WriteLine("按奇偶位判断的方法Truncate001: " + sw.Elapsed.TotalMilliseconds + "ms");

            sw.Reset();
            sw.Start();
            for (int i = 0; i < 10000; i++)//这个慢的吓人，我没耐心等...
                Truncate003(s, 255);
            sw.Stop();

            Console.WriteLine("网友提供的方法Truncate003: " + sw.Elapsed.TotalMilliseconds + "ms");
            Console.Read();
        }

        //这个算法用时：22毫秒左右
        public static string Truncate(string input, int length)
        {
            int len = input.Length;
            int i = 0;
            for (; i < length && i < len; i++)
            {
                if ((int)(input[i]) > 0xFF)
                {
                    --length;
                }
            }

            if (length < i)
            {
                length = i;
            }
            else if (length > len)
            {
                length = len;
            }

            return input.Substring(0, length);
        }

        //这个用时1784毫秒左右
        public static string Truncate001(string input, int length)
        {
            Encoding encode = Encoding.GetEncoding("gb2312");
            byte[] byteArr = encode.GetBytes(input);
            if (byteArr.Length <= length) return input;

            int m = 0, n = 0;
            foreach (byte b in byteArr)
            {
                if (n >= length) break;
                if (b > 127) m++; //重要一步：对前p个字节中的值大于127的字符进行统计
                n++;
            }
            if (m % 2 != 0) n = length + 1; //如果非偶：则说明末尾为双字节字符，截取位数加1

            return encode.GetString(byteArr, 0, n);
        }
        //这个用时271毫秒左右
        public static string Truncate002(string input, int length)
        {
            if (input.Length == 0)
                return string.Empty;
            if (input.Length <= length)
                return input;
            int total = 0;
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (total >= (length - 1)) break;
                string s = input.Substring(i, 1);
                temp.Append(s);
                total += Encoding.Default.GetByteCount(s);
            }
            temp.Append("...");
            return temp.ToString();
        }
        //这个慢的吓人，我没耐心等...
        public static string Truncate003(string input, int length)
        {
            Encoding encode = Encoding.GetEncoding("gb2312");
            string res = String.Empty;
            int bytecount = encode.GetByteCount(input);
            if (length >= bytecount)
            {
                return input;
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (encode.GetByteCount(input.Substring(0, i)) <= length)
                {
                    return input.Substring(0, i);
                }
            }
            return string.Empty;
        }

        //这个用时540毫秒左右
        static string Truncate004(string input, int length)
        {
            if (System.Text.Encoding.Unicode.GetByteCount(input) < length)
                return input;
            byte[] bytesStr = System.Text.Encoding.Unicode.GetBytes(input);
            List<byte> list = new List<byte>();
            int count = 0;
            for (int i = 0; i < bytesStr.Length; i += 2)
            {
                if (count == length)
                    break;
                if (bytesStr[i + 1] == 0)
                {
                    if (count + 1 == length)
                    {
                        list.Add(46);
                        list.Add(0);
                        count++;
                    }
                    else
                    {
                        list.Add(bytesStr[i]);
                        list.Add(bytesStr[i + 1]);
                        count++;
                    }
                }
                else
                {
                    if (count + 2 > length)
                    {
                        list.Add(46);
                        list.Add(0);
                        count++;
                    }
                    else if (count + 2 == length)
                    {
                        list.Add(46);
                        list.Add(0);
                        list.Add(46);
                        list.Add(0);
                        count += 2;
                    }
                    else
                    {
                        list.Add(bytesStr[i]);
                        list.Add(bytesStr[i + 1]);
                        count += 2;
                    }
                }
            }
            return System.Text.Encoding.Unicode.GetString(list.ToArray());
        }


        /// <summary>
        /// 要截取的字节数
        /// </summary>
        /// <param name="value">输入的字符串</param>
        /// <param name="length">限定长度</param>
        /// <param name="ellipsis">是否需要省略号,true--需要，false--不需要</param>
        /// <param name="cuttype">截取类型</param>
        /// <returns>截取后的字符串，如果是NVarchar--则20个字节就会有10个字符，Varchar--20个字节会有>=10个字符</returns>
        public static string CutString(string value, int length, bool ellipsis, CutType cuttype)
        {
            value = value.Trim();
            if (value.Length == 0)
                return string.Empty;
            if (cuttype == CutType.NVarchar)
            {
                if (value.Length > length / 2)
                {
                    value = value.Substring(0, length / 2);
                    if (ellipsis)
                        return value + "..";
                }
            }
            else
            {
                string resultString = string.Empty;
                byte[] myByte = System.Text.Encoding.GetEncoding("gbk").GetBytes(value);
                if (myByte.Length > length)
                {
                    resultString = Encoding.GetEncoding("gbk").GetString(myByte, 0, length);
                    string lastChar = resultString.Substring(resultString.Length - 1, 1);
                    if (lastChar.Equals(value.Substring(resultString.Length - 1, 1)))
                    { value = resultString; }//如果截取后最后一个字符与原始输入字符串中同一位置的字符相等，则表示截取完成
                    else//如果不相等，则减去一个字节再截取
                    {
                        value = Encoding.GetEncoding("gbk").GetString(myByte, 0, length - 1);
                    }
                    if (ellipsis)
                        return value + "..";
                    return value;
                }
            }
            return value;
        }
        #region  截短字串的函数，分区中英文
        /// <summary>
        /// 截短字串的函数
        /// </summary>
        /// <param name="mText">要加工的字串</param>
        /// <param name="byteCount">长度</param>
        /// <returns>被加工过的字串</returns>
        public static string Left(string mText, int byteCount)
        {
            if (byteCount < 1)
                return mText;

            if (System.Text.Encoding.Default.GetByteCount(mText) <= byteCount)
            {
                return mText;
            }
            else
            {
                byte[] txtBytes = System.Text.Encoding.Default.GetBytes(mText);
                byte[] newBytes = new byte[byteCount - 4];

                for (int i = 0; i < byteCount - 4; i++)
                {
                    newBytes[i] = txtBytes[i];
                }
                string OutPut = System.Text.Encoding.Default.GetString(newBytes) + "...";
                if (OutPut.EndsWith("?...") == true)
                {
                    OutPut = OutPut.Substring(0, OutPut.Length - 4);
                    OutPut += "...";
                }
                return OutPut;
            }
        }
        #endregion


    }
    /// <summary>
    /// 截取字符枚举值,Varchar--英文一个字节，中文两个字节，NVarchar--无论中英文都是两个字节
    /// </summary>
    public enum CutType
    {
        Varchar,
        NVarchar
    }
}
