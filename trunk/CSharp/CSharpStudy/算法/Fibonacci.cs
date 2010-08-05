using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 算法
{
    /// <summary>
    /// 斐波那契,Fibonacci
    /// </summary>
    class Fibonacci
    {
        /// <summary>
        /// 快速递归 Foo1(1, 1, 3, 50)
        /// </summary>
        /// <param name="n_1">默认为1</param>
        /// <param name="n_2">默认为1</param>
        /// <param name="index">默认为3</param>
        /// <param name="count">要取第多少位的值</param>
        /// <returns></returns>
        public static long Foo1(long n_1, long n_2, int index, int count)
        {
            long result = n_1 + n_2;
            if (index < count)
            {
                return Foo1(n_2, result, ++index, count);
            }
            return result;
        }

        /// <summary>
        /// 这个递归速度很慢
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Foo2(long n)
        {
            if (n < 3)
            {
                return 1;
            }
            return Foo2(n - 1) + Foo2(n - 2);
        }

        /// <summary>
        /// 三个变量实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Foo3(long n)
        {
            long a, b, temp;
            a = b = 1;
            for (int i = 2; i < n; i++)
            {
                temp = a;
                a = b;
                b = temp + b;
            }
            return b;
        }

        /// <summary>
        /// 数组实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Foo4(long n)
        {
            long[] temp = new long[n];
            temp[0] = temp[1] = 1;
            for (int i = 2; i < n; i++)
            {
                temp[i] = temp[i - 1] + temp[i - 2];
            }
            return temp[n - 1];
        }
    }
}
