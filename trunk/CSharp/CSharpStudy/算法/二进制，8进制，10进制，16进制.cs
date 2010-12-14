using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace 算法
{
    class 二进制_8进制_10进制_16进制
    {

        //static void Main(string[] args)
        //{
        //int count = 10000;
        //int value = int.MaxValue / 123;

        //run(value, 2, count, IntToString);
        //run(value, 2, count, IntToString2);

        //run(value, 2, count, IntToStringByNet);


        ////十进制转二进制
        //Console.WriteLine(Convert.ToString(value, 2));
        ////十进制转八进制
        //Console.WriteLine(Convert.ToString(value, 8));
        ////十进制转十六进制
        //Console.WriteLine(Convert.ToString(value, 16));

        ////二进制转十进制
        //Console.WriteLine(Convert.ToInt32("100111101", 2));
        ////八进制转十进制
        //Console.WriteLine(Convert.ToInt32("76", 8));
        ////十六进制转十进制
        //Console.WriteLine(Convert.ToInt32("FF", 16));


        //}
        public delegate string DelegateMethod(int value, int toBase);

        public static void run(int value, int toBase, int count, DelegateMethod method)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            for (int i = 0; i < count; i++)
            {
                string str = method(value, toBase);
                //Console.WriteLine(str);
            }
            sp.Stop();
            Console.WriteLine("方法：{0}   ,用时：{1}ms", method.Method.Name, sp.ElapsedMilliseconds);
        }


        public static string IntToString(int value, int toBase)
        {
            if (toBase != 2 && toBase != 8 && toBase != 10 && toBase != 16)
            {
                throw new Exception("无效的基。");
            }
            StringBuilder sb = new StringBuilder(10);
            string str = "ABCDEF";

            while (value / toBase > 0 || (value / toBase == 0 && value % toBase != 0))
            {
                int intTemp = value % toBase;
                if (intTemp >= 10)
                {
                    sb.Append(str[intTemp - 10]);
                }
                else
                {
                    sb.Append(intTemp);
                }
                value /= toBase;
            }
            for (int i = 0, j = sb.Length - 1; i <= j; i++, j--)
            {
                int intTemp = sb[i];
                sb[i] = sb[j];
                sb[j] = (char)intTemp;
            }
            return sb.ToString();
        }


        public static string IntToString2(int value, int toBase)
        {
            if (toBase != 2 && toBase != 8 && toBase != 10 && toBase != 16)
            {
                throw new Exception("无效的基。");
            }
            string result = "";
            string str = "ABCDEF";
            while (value / toBase > 0 || (value / toBase == 0 && value % toBase != 0))
            {
                int intTemp = value % toBase;
                if (intTemp >= 10)
                {
                    result = str[intTemp - 10] + result;

                }
                else
                {
                    result = intTemp + result;
                }
                value /= toBase;
            }

            return result;
        }


        public static string IntToStringByNet(int value, int toBase)
        {
            return Convert.ToString(value, toBase);
        }

    }

}
