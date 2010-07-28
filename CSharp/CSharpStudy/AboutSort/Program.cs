using System;
using System.Collections.Generic;
using System.Text;

namespace AboutSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //不用中间变量交换两个整数
            int a = 12;
            int b = 23;
            //a = b + a - (b = a);//有人说会溢出，本人测试不会， int.MaxValue;
            a ^= b; b ^= a; a ^= b;
            Console.WriteLine("a:{0},b:{1}", a, b);


            AboutSort.字符排序();
        }
    }
}
