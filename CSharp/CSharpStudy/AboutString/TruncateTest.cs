using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace AboutString
{
    public delegate string TruncateDelegate(string input, int length);

    public static class TruncateTest
    {
        public static void StartTest()
        {
            Console.WriteLine("\r\nstring.Compare。。。。。。。。。。。");
            Console.WriteLine(string.Compare("list.aspx", "List.aspx", true));
            Console.WriteLine(string.Compare("list.aspx", "sadf"));
            Console.ReadKey();

            Console.WriteLine("\r\n字符串长度测试。。。。。。。。。。。");
            string aaa = "我,";
            Console.WriteLine(System.Text.Encoding.GetEncoding(936).GetBytes("我是1").Length);
            Console.WriteLine(Regex.Replace(aaa, "[^\x00-\xff]", "aa").Length); //没有上面的快，但比上面的通用，可判断所有双字节字符
            Console.WriteLine(aaa.Remove(aaa.Length - 1));
            Console.ReadKey();


            Console.WriteLine("\r\n{0}String.PadLeft{0}", new string('=', 20));
            string[] strTemp = { "12", "1", "234", "12345" };
            foreach (string item in strTemp)
            {
                Console.WriteLine(item.PadLeft(6, '0'));
            }
            Console.ReadKey();


            char[] sArr = new char[10000];
            for (int i = 0; i < 10000; i++)
            {
                if (i % 2 == 0)
                {
                    sArr[i] = 'A';
                }
                else
                {
                    sArr[i] = 'B';
                }
            }
            string s = new string(sArr);
            for (int i = 0; i < sArr.Length; i++)
            {
                if (i % 10 == 0)
                {
                    s = s.Insert(i, "中国人");
                }
            }

            int length = 255;
            int count = 10000;
            Console.WriteLine("\r\n速度测试。。。。。。。。。。。");
            RunTest(s, length, count, Truncate);
            RunTest(s, length, count, TruncateNow);
            RunTest(s, length, count, Truncate001);
            RunTest(s, length, count, Truncate002);
            RunTest(s, length, count, Truncate003);
            RunTest(s, length, count, Left);
            RunTest(s, length, count, CutString);
            Console.ReadKey();

            length = 22;
            for (length = 5; length < 10000; length++)
            {
                Console.WriteLine("\r\n正确性测试\r\n{0}结果: {1} ", "True Length".PadRight(12, ' '), new string('A', length));
                RunTest2(s, length, Truncate);
                RunTest2(s, length, TruncateNow);
                RunTest2(s, length, Truncate001);
                RunTest2(s, length, Truncate002);
                RunTest2(s, length, Truncate003);
                RunTest2(s, length, Left);
                RunTest2(s, length, CutString);
                Console.ReadKey();
            }


            Console.ReadKey();
        }

        public static void RunTest(string input, int length, int count, TruncateDelegate truncate)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                truncate(input, length);
            }
            sw.Stop();
            Console.WriteLine("字符串截取的方法{0}:{1}ms ", truncate.Method.Name, sw.Elapsed.TotalMilliseconds);
        }

        public static void RunTest2(string input, int length, TruncateDelegate truncate)
        {
            Console.WriteLine("{0}结果: {1} ", truncate.Method.Name.PadRight(12, ' '), truncate(input, length));
        }



        //这个算法用时：22毫秒左右
        public static string Truncate(string input, int length)
        {
            int len = input.Length;
            int i;

            for (i = 0; i < length && i < len; i++)
            {
                if ((int)input[i] > 0xFF)
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

        //上面最后的判断代码不明白什么意思，改造下
        public static string TruncateNow(string input, int length)
        {
            int len = input.Length;
            int i;

            for (i = 0; i < length && i < len; i++)
            {
                if ((int)input[i] > 0xFF)
                {
                    --length;
                }
            }

            if (length < i)
            {
                return input.Substring(0, length) + ".";
            }
            else
            {
                return input.Substring(0, length);
            }
        }



        //这个用时240毫秒左右
        public static string Truncate001(string input, int length)
        {
            if (input.Length == 0)
            {
                return string.Empty;
            }
            if (input.Length <= length)
            {
                return input;
            }
            int total = 0;
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (total >= (length - 1))
                {
                    break;
                }
                string s = input.Substring(i, 1);
                temp.Append(s);
                total += Encoding.Default.GetByteCount(s);
            }

            string strOK = temp.ToString();
            if (Encoding.Default.GetByteCount(strOK) < length)
            {
                return strOK + ".";
            }
            else
            {
                return strOK;
            }
        }

        //这个用时500毫秒左右
        static string Truncate002(string input, int length)
        {
            if (Encoding.Unicode.GetByteCount(input) < length)
            {
                return input;
            }

            byte[] bytesStr = Encoding.Unicode.GetBytes(input);
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
            return Encoding.Unicode.GetString(list.ToArray());
        }


        //这个用时1877毫秒左右
        public static string Truncate003(string input, int length)
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


        /// <summary>
        /// 截取字符枚举值,Varchar--英文一个字节，中文两个字节，NVarchar--无论中英文都是两个字节
        /// </summary>
        public enum CutType
        {
            Varchar,
            NVarchar
        }

        //1800ms左右
        public static string CutString(string input, int length)
        {
            return CutString(input, length, true, CutType.Varchar);
        }

        /// <summary>
        /// 要截取的字节数
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="length">限定长度</param>
        /// <param name="ellipsis">是否需要省略号,true--需要，false--不需要</param>
        /// <param name="cuttype">截取类型</param>
        /// <returns>截取后的字符串，如果是NVarchar--则20个字节就会有10个字符，Varchar--20个字节会有>=10个字符</returns>
        public static string CutString(string input, int length, bool ellipsis, CutType cuttype)
        {
            input = input.Trim();
            if (input.Length == 0)
            {
                return string.Empty;
            }

            if (cuttype == CutType.NVarchar)
            {
                if (input.Length > length / 2)
                {
                    input = input.Substring(0, length / 2);
                    if (ellipsis)
                    {
                        return input + "..";
                    }
                }
            }
            else
            {
                Encoding encode = Encoding.GetEncoding("gbk");
                string resultString = string.Empty;
                byte[] myByte = encode.GetBytes(input);
                if (myByte.Length > length)
                {
                    resultString = encode.GetString(myByte, 0, length);
                    string lastChar = resultString.Substring(resultString.Length - 1, 1);
                    if (lastChar.Equals(input.Substring(resultString.Length - 1, 1)))
                    {
                        //如果截取后最后一个字符与原始输入字符串中同一位置的字符相等，则表示截取完成
                        input = resultString;
                    }
                    else
                    {
                        //如果不相等，则减去一个字节再截取
                        input = encode.GetString(myByte, 0, length - 1);
                    }
                    if (ellipsis)
                    {
                        return input + "..";
                    }
                    return input;
                }
            }
            return input;
        }


        /// <summary>
        /// 截短字串的函数
        /// </summary>
        /// <param name="input">要加工的字串</param>
        /// <param name="length">长度</param>
        /// <returns>被加工过的字串</returns>
        public static string Left(string input, int length)
        {
            if (length < 1)
            {
                return input;
            }
            Encoding encode = Encoding.Default;

            if (encode.GetByteCount(input) <= length)
            {
                return input;
            }
            else
            {
                byte[] txtBytes = encode.GetBytes(input);
                byte[] newBytes = new byte[length - 4];

                for (int i = 0; i < length - 4; i++)
                {
                    newBytes[i] = txtBytes[i];
                }
                string OutPut = encode.GetString(newBytes) + "...";
                if (OutPut.EndsWith("?...") == true)
                {
                    OutPut = OutPut.Substring(0, OutPut.Length - 4);
                    OutPut += "...";
                }
                return OutPut;
            }
        }


    }
}
//html里可以这么实现
//.title
//{
//width:200px;
//white-space:nowrap;
//word-break:keep-all;
//overflow:hidden;
//text-overflow:ellipsis;
//}