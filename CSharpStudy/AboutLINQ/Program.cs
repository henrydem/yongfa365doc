using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> arr = from a in arrInt
                                   where a > 2 && a < 5
                                   select a;
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
