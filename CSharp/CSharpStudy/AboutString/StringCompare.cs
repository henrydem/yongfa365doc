using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace AboutString
{
    public class StringCompare
    {
        //有没有中文，结果不一样,两个字符串长度不一样时结果也不一样
        //string a = "abcdefghigklmnopqrstuvwxyz0123456789!@#$%^&*()_+我是谁";
        //string b = "abcdefghigklmnopqrstuvwxyz0123456789!@#$%^&*()_+我是谁";

        string a = "abcdefghigklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
        string b = "abcdefghigklmnopqrstuvwxyz0123456789!@#$%^&*()_+?";
        int count = 100000000;

        public StringCompare()
        {

            Test1(count);

            EqualsTest(StringComparison.Ordinal, count);
            EqualsTest(StringComparison.OrdinalIgnoreCase, count);
            EqualsTest(StringComparison.CurrentCulture, count);
            EqualsTest(StringComparison.CurrentCultureIgnoreCase, count);
            Console.ReadKey(); 

        }
        void EqualsTest(StringComparison compare, int count)
        {
            Console.WriteLine("\r\na.Equals(b, StringComparison.{0}):",compare.ToString());
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                bool re = a.Equals(b, compare);
            }
            watch.Stop();
            double time = watch.Elapsed.TotalSeconds;
            Console.Write(time);
        }


        void Test1(int count)
        {
            Console.WriteLine("a == b");

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < count; i++)
            {
                bool re = (a == b);
            }
            watch.Stop();
            double time = watch.Elapsed.TotalSeconds;
            Console.Write(time);
        }
    }



}
