using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AboutReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            TestLoad();
            TestGet();

        }

        private static void TestGet()
        {
            object o = 1;
            Console.WriteLine(o.GetType().Name);//因为object并不知道里面都放了什么，所以有一个方法来判断他的类型


            Console.WriteLine("\n列出字段：");
            var fields = typeof(User).GetFields();
            foreach (var item in fields)
            {
                Console.WriteLine("Field:{0}\tValue:{1}", item.Name, item.GetValue(item.Name));
            }

            Console.WriteLine("\n列出属性：");
            var props = typeof(User).GetProperties();
            foreach (var item in props)
            {
                Console.WriteLine("Property:{0}\tCanRead:{1}\tCanWrite:{2}", item.Name, item.CanRead, item.CanWrite);
            }


            Console.WriteLine("\n列出方法：");
            var methods = typeof(User).GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine("MethodName:{0}", item.Name);
            }
        }

        private static void TestLoad()
        {
            User cls = new User();
            //得到所有属性
            foreach (var item in cls.GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            //////////////typeof//////////////
            Type t = typeof(System.String);
            Console.WriteLine("Listing all the public constructors of the {0} type", t);

            //////////////Assembly.Load 程序集名//////////////
            {
                object obj = Assembly.Load("AboutReflection").CreateInstance("AboutReflection.User");//反射创建
                User cls2 = obj as User;
                Console.WriteLine(cls2.年龄);
            }
            //////////////Assembly.LoadFrom 相对路径//////////////
            {

                object obj = Assembly.LoadFrom("AboutReflection.exe").CreateInstance("AboutReflection.User");//反射创建
                User cls2 = obj as User;
                Console.WriteLine(cls2.年龄);
            }

            //////////////Assembly.LoadFile 绝对路径//////////////
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\AboutReflection.exe";
                object obj = Assembly.LoadFile(path).CreateInstance("AboutReflection.User");//反射创建

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
