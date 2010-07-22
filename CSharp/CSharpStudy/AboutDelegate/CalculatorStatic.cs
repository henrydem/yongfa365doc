using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegate
{
    class CalculatorStatic
    {
        //声明一个委托
        public delegate void CalculateDelegage(Int32 x, Int32 y);

        //定义委托类型变量
        public static CalculateDelegage MyDelegate;

        //创建与委托关联的方法，二者具有相同的返回值类型和参数列表
        public static void Add(Int32 x, Int32 y)
        {
            Console.WriteLine(x + y);
        }


        public static void Test()
        {

            //进行委托绑定
            MyDelegate = new CalculateDelegage(CalculatorStatic.Add);
            MyDelegate(3, -1);
            Console.WriteLine("--------------------------------------------");

            //多播委拖
            MyDelegate -= CalculatorStatic.Add;
            MyDelegate += CalculatorStatic.Add;
            MyDelegate(1, -1);
            Console.WriteLine("--------------------------------------------");

            Console.ReadKey();
        }

    }
}
