using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 算法
{
    class Other
    {
        /// <summary>
        /// 遍历目录
        /// </summary>
        /// <param name="dir"></param>
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

        /// <summary>
        /// 两个int交换
        /// 两个int不使用变量交换
        /// 一行代码实现 两个int不使用变量交换
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a,ref int b)
        {
            //方法一
            //a ^= b;
            //b ^= a;
            //a ^= b;

            //方法二
            //a = b + a;
            //b = a - b;
            //a = a - b;

            //方法三
            //a = b + a - (b = a);//不会溢出

            //方法四
            b = a ^ b ^ (a = b); 

            //方法五，使用变量，易读，效率高
            //int temp = a;
            //a = b;
            //b = a;


            //Console.WriteLine("a:{0},b:{1}", a, b);

        }

    }
}
