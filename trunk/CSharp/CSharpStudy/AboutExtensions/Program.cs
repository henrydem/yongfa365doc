using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YongFa365.String;

namespace AboutExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "admin";
            //Console.WriteLine(a.To16bitMD5());
            //Console.WriteLine(a.To32bitMD5());
            //Console.WriteLine(a.ToSHA1());
            //Example1();
            //Example2();

            var a = true && 1>0;
            var asdf = "123".CompareTo("1");
            List<string> lst = new List<string>() { "wer","dsfdsf","sad" };
            lst.ForEach((item) => { Console.WriteLine(item); });

        }

        public static void Example1()
        {
            bool b1 = 1.In(new int[] { 1, 2, 3, 4, 5 });
            bool b2 = "Tom".In(new string[] { "Bob", "Kitty", "Tom" });
        }

        public static void Example2()
        {
            bool b1 = 1.In(1, 2, 3, 4, 5);
            bool b2 = 1.In(1, 2, 3, 4, 5, 5, 7, 8);
            bool b3 = "Tom".In("Bob", "Kitty", "Tom");
            bool b4 = "Tom".In("Bob", "Kitty", "Tom", "Jim");
            DateTime.Now.In(new DateTime[] { DateTime.Now });

            List<DateTime> lst = new List<DateTime>() { };
            DateTime.Now.In(lst);
        }
    }
}
