using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace AboutRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            int doCount = 1000000;
            string target = "fdsfdfdsfs156fsdfdsf65sdf4d13466386725s4fds1f56ds4fdsf6s54f6s15426358745d5f4dsf45dsf6ds13652142365f4sdaf7sdafsd5";
            DateTime start = DateTime.Now;
            for (int i = 0; i < doCount; i++)
            {
                Regex.Matches(target, @"1[35]\d{9}");
            }
            TimeSpan t1 = DateTime.Now - start;
            start = DateTime.Now;
            for (int i = 0; i < doCount; i++)
            {
                CompiledRegex.test.Matches(target);
            }
            TimeSpan t2 = DateTime.Now - start;
            Console.WriteLine("未编译所花费时间：{0}\n编译后花费时间：{1}", t1.Milliseconds, t2.Milliseconds);
            Console.ReadKey(); 
        }
    }
    static class CompiledRegex
    {
        public static Regex test = new Regex(@"1[35]\d{9}", RegexOptions.Compiled);
    }
}

