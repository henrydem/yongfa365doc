using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("请输入数字A：");
                string strNumberA = Console.ReadLine();
                Console.Write("请选择运算符号(+、-、*、/)：");
                string strOperate = Console.ReadLine();
                Console.Write("请输入数字B：");
                string strNumberB = Console.ReadLine();
                string strResult = "";

                Operation oper = OperationFactory.CreateOperate(strOperate);
                oper.NumberA = Convert.ToDouble(strNumberA);
                oper.NumberB = Convert.ToDouble(strNumberB);
                strResult = oper.GetResult().ToString();

                Console.WriteLine("结果是：" + strResult);

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("您的输入有错：" + ex.Message);
            }

        }
    }
}
