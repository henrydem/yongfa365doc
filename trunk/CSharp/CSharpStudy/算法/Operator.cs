using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 算法
{
    class Operator
    {
        static void 赋值()
        {

            #region 数字类型定义
            {
                int a = 1;
                short b = 1;
                long c = 1232424L;
                decimal d = 123.123M;
                float e = 4.5F;
                double f = 123.123D;
                double ff = 234.234E12;
                byte bb = 12;
            }
            #endregion
        
        }

        /// <summary>
        /// 两个整数相除的结果始终为一个整数。
        /// 例如，5 除以 2 的结果为 2。
        /// 若要确定 5 除以 2 的余数，请使用 modulo 运算符 (%)。
        /// 若要获取作为有理数或分数的商，
        /// 应将被除数或除数设置为 float 类型或 double 类型。
        /// 可以通过在数字后添加一个小数点来隐式执行此操作，如以下示例中所示。
        /// </summary>
        static void 除法()
        {
            Console.WriteLine(5 / 2);
            Console.WriteLine(5 % 2);

            Console.WriteLine(5 / 2.1);
            Console.WriteLine(5.1 / 2);
            Console.WriteLine(-5 / 2);

            Console.WriteLine(5.0m % 2.2m);

        }
    }
}
