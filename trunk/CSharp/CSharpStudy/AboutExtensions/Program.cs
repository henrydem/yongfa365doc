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
            string a = "admin";
            Console.WriteLine(a.To16bitMD5());
            Console.WriteLine(a.To32bitMD5());
            Console.WriteLine(a.ToSHA1());
        }
    }
}
