using System;
using System.Collections.Generic;
using System.Text;

namespace AboutDelegateEvent
{
    //定义一个CalculeEventArgs,
    //用于存放事件引发时向处理程序传递的状态信息
    class CalculateEventArgs : EventArgs
    {
        public readonly Int32 x, y;

        public CalculateEventArgs(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Calculator
    {
        //声明事件委托
        public delegate void CalculaterEventHandler(object sender, CalculateEventArgs e);

        //定义事件成员，提供外部绑定
        public event CalculaterEventHandler MyCalculate;


        //提供受保护的虚方法，可以由子类覆写来拒绝监视
        protected virtual void OnCalculate(CalculateEventArgs e)
        {
            if (MyCalculate != null)
            {
                MyCalculate(this, e);
            }
        }

        //进行计算，调用该方法表示 有新的计算发生
        public void Calculate(Int32 x, Int32 y)
        {
            CalculateEventArgs e = new CalculateEventArgs(x, y);
            OnCalculate(e);
        }

    }

    class CalculatorManager
    {
        //定义消息通知方法
        public void Add(object sender, CalculateEventArgs e)
        {
            Console.WriteLine(e.x + e.y);
        }

        public void Substract(object sender, CalculateEventArgs e)
        {
            Console.WriteLine(e.x - e.y);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            //事件触发者
            CalculatorManager cm = new CalculatorManager();

            //事件绑定
            calculator.MyCalculate += cm.Add;
            calculator.Calculate(100, 200);
            calculator.MyCalculate += cm.Substract;
            calculator.Calculate(100, 200);

            //事件注销
            calculator.MyCalculate -= cm.Add;
            calculator.Calculate(100, 200);
            Console.ReadKey();
        }
    }
}
