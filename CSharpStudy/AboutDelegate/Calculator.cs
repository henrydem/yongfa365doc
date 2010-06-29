using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegate
{
    class Calculator
    {
        //声明一个委托
        delegate void CalculateDelegage(Int32 x, Int32 y);

        //定义委托类型变量
        CalculateDelegage MyDelegate;

        //创建与委托关联的方法，二者具有相同的返回值类型和参数列表
        public void Add(Int32 x, Int32 y)
        {
            Console.WriteLine(x + y);
        }

        public void Subtract(Int32 x, Int32 y)
        {
            Console.WriteLine(x - y);
        }

        public void Mutilply(Int32 x, Int32 y)
        {
            Console.WriteLine(x * y);
        }

        public void Divide(Int32 x, Int32 y)
        {
            Console.WriteLine(x % y);
        }

        public void Test()
        {

            //进行委托绑定
            MyDelegate = new CalculateDelegage(Add);
            MyDelegate(3, -1);
            Console.WriteLine("--------------------------------------------");


            MyDelegate += Subtract;
            MyDelegate += Mutilply;
            MyDelegate += Divide;
            MyDelegate += Add;
            MyDelegate(3, -1);
            Console.WriteLine("--------------------------------------------");

            MyDelegate -= Add;
            MyDelegate(3, -1);
            Console.WriteLine("--------------------------------------------");


            MyDelegate = new CalculateDelegage(Add);
            MyDelegate(3, -1);


            Console.ReadKey();
        }

    }
}
