using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 算法
{
    /// <summary>
    /// 质数又称素数。
    /// 指在一个大于1的自然数中，除了1和此整数自身外，没法被其他自然数整除的数。
    /// </summary>
    class Prime
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public static List<int> 所有质数(int n)
        {
            List<int> list = new List<int>();
            if (n <= 1) return list;

            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }
}
