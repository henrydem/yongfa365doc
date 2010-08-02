using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AboutReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 cls = new Class1();
            //得到所有属性
            foreach (var item in cls.GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            ////////////////////////////

            object obj = Assembly.Load("AboutReflection").CreateInstance("AboutReflection.Class1");//反射创建
            Class1 cls2 = obj as Class1;
            Console.WriteLine(cls2.年龄);
        }
    }
}
