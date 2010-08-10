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

            //////////////Assembly.Load 程序集名//////////////
            {
                object obj = Assembly.Load("AboutReflection").CreateInstance("AboutReflection.Class1");//反射创建
                Class1 cls2 = obj as Class1;
                Console.WriteLine(cls2.年龄);
            }
            //////////////Assembly.LoadFrom 相对路径//////////////
            {

                object obj = Assembly.LoadFrom("AboutReflection.exe").CreateInstance("AboutReflection.Class1");//反射创建
                Class1 cls2 = obj as Class1;
                Console.WriteLine(cls2.年龄);
            }

            //////////////Assembly.LoadFile 绝对路径//////////////
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\AboutReflection.exe";
                object obj = Assembly.LoadFile(path).CreateInstance("AboutReflection.Class1");//反射创建
                
                //使用反射执行静态方法
                MethodInfo mi = obj.GetType().GetMethod("静态方法");
                object result = mi.Invoke(null, new object[] { "柳永法", 23 });
                Console.WriteLine(result);

                //使用反射执行普通方法
                MethodInfo mi2 = obj.GetType().GetMethod("普通方法");
                object result2 = mi2.Invoke(obj, new object[] { "柳永法", 23 });
                Console.WriteLine(result2);

            }


        }
    }
}
