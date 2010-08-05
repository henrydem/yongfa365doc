using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 算法
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fibonacci.Foo1(1, 1, 3, 30));
            Console.WriteLine(Fibonacci.Foo2(30));
            Console.WriteLine(Fibonacci.Foo3(30));
            Console.WriteLine(Fibonacci.Foo4(30));
            Console.WriteLine(Prime.IsPrime(4));
            Prime.所有质数(100).ForEach(a => { Console.Write("{0},", a); });
            

            Console.ReadKey();
        }
       
    }
}
