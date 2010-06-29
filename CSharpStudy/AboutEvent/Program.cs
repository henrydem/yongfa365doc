using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegateEvent
{

    class Program
    {
        static void Main2(string[] args)
        {
            Calculator calculator = new Calculator();

            //事件触发者
            CalcMethod method = new CalcMethod();

            //事件绑定,订阅事件
            calculator.CalcEvent += method.Add;
            calculator.Calc(100, 200);

            calculator.CalcEvent += method.Substract;
            calculator.Calc(100, 200);

            //事件注销
            calculator.CalcEvent -= method.Add;
            calculator.Calc(100, 200);
            Console.ReadKey();
        }
    }


    //定义一个CalcEventArgs,
    //用于存放事件引发时向处理程序传递的状态信息
    class CalcEventArgs : EventArgs
    {
        public readonly Int32 x, y;

        public CalcEventArgs(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Calculator
    {
        //声明事件委托
        public delegate void ClacEventHandler(object sender, CalcEventArgs e);

        //定义事件成员，提供外部绑定
        public event ClacEventHandler CalcEvent;


        //提供受保护的虚方法，可以由子类覆写来拒绝监视
        protected virtual void OnCalc(CalcEventArgs e)
        {
            if (CalcEvent != null)
            {
                CalcEvent(this, e);
            }
        }

        //进行计算，调用该方法表示 有新的计算发生
        public void Calc(Int32 x, Int32 y)
        {
            CalcEventArgs e = new CalcEventArgs(x, y);
            OnCalc(e);
        }

    }

    class CalcMethod
    {
        //定义消息通知方法
        public void Add(object sender, CalcEventArgs e)
        {
            Console.WriteLine(e.x + e.y);
        }

        public void Substract(object sender, CalcEventArgs e)
        {
            Console.WriteLine(e.x - e.y);
        }
    }
}
