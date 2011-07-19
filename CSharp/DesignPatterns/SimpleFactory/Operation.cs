using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFactory
{
    /// <summary>
    /// 运算类
    /// </summary>
    public abstract class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public abstract double GetResult();
    }


    /// <summary>
    /// 加法类
    /// </summary>
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }

    /// <summary>
    /// 减法类
    /// </summary>
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }

    /// <summary>
    /// 乘法类
    /// </summary>
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }

    /// <summary>
    /// 除法类
    /// </summary>
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            if (NumberB == 0) throw new Exception("除数不能为0。");
            return NumberA / NumberB;
        }
    }

    /// <summary>
    /// 运算类工厂
    /// </summary>
    public class OperationFactory
    {
        public static Operation CreateOperate(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }

}
