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
            Console.WriteLine(Other.从1加到N的值(100));

            int a = 123;
            int b = 234;
            Other.Swap(ref a, ref b);
            Console.WriteLine("a:{0},b:{1}", a, b);
            Console.WriteLine("Decimal.MaxValue:{0}", Decimal.MaxValue);
            Console.WriteLine("   long.MaxValue:{0}", long.MaxValue);

            Console.WriteLine(Fibonacci.Foo1(1, 1, 3, 50));
            Console.WriteLine(Fibonacci.Foo2(30));
            Console.WriteLine(Fibonacci.Foo3(30));
            Console.WriteLine(Fibonacci.Foo4(30));
            Console.WriteLine(Prime.IsPrime(4));
            Prime.所有质数(100).ForEach(n => { Console.Write("{0},", n); });


            Console.ReadKey();
        }

    }
}
