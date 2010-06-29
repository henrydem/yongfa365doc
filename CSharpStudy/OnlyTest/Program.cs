using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OnlyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            质数(10);
            //Tree("F:");
            //Console.WriteLine(Foo(30));
            Console.ReadKey();
        }

        public static void 质数(uint intLength)
        {
            int i, j;
            for (i = 2; i < intLength; i++)
            {
                for (j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                        break;
                }
                if (j > i / 2)
                    Console.WriteLine("质数: " + i);
            }
        }

        public static int Foo(uint i)
        {
            if (i == 1 || i == 2)
            {
                return 1;
            }
            else
            {
                return Foo(i - 1) + Foo(i - 2);
            }
        }

        public static void Tree(string dir)
        {
            foreach (string item in Directory.GetFiles(dir))
            {
                Console.WriteLine(item);
            }
            foreach (string item in Directory.GetDirectories(dir))
            {
                Tree(item);
            }
        }
    }
}
