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
            Console.WriteLine(Fibonacci.Fun1(1, 1, 3, 30));
            Console.WriteLine(Fibonacci.Fun2(30));
            Console.WriteLine(Fibonacci.Fun3(30));
            Console.WriteLine(Fibonacci.Fun4(30));
            Console.ReadKey();
        }
       
    }
}
