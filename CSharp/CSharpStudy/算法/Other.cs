using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 算法
{
    //递归次数太多会出现：System.StackOverflowException
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
        /// 阶乘  N!=n*(n-1)!   1*2*3*4*5*6==6!
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long N的阶乘(long n)
        {
            if (n < 1)
            {
                return 1;
            }
            return n * N的阶乘(n - 1);
        }

        //计算1+2+3+4+...+100的值
        public static long 从1加到N的值(long n)
        {
            //方法一
            //long result=0;
            //for (int i = 1; i < n+1; i++)
            //{
            //    result += i;
            //}
            //return result;

            //方法二
            if (n == 0)
            {
                return 0;
            }
            return n + 从1加到N的值(n - 1);

        }






        /// <summary>
        /// 两个int交换
        /// 两个int不使用变量交换
        /// 一行代码实现 两个int不使用变量交换
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a, ref int b)
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
