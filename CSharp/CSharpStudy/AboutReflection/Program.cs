﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel;

namespace AboutReflection
{
    static class Program
    {
        static void Main(string[] args)
        {
            TestGet();
            TestDescription();
            TestLoad();
            Console.WriteLine();
        }

        private static void TestDescription()
        {
            ColorWriteLine("列出Description:");
            var props = typeof(User).GetProperties();
            foreach (var item in props)
            {
                var obj = item.GetCustomAttributes(false).FirstOrDefault(p => p is DescriptionAttribute);
                var desc = obj == null ? "无Description" : (obj as DescriptionAttribute).Description;
                Console.WriteLine("Property:{0}\tDescription:{1}", item.Name, desc);

            }
        }

        private static void TestGet()
        {

            ColorWriteLine("列出字段及默认值：");
            var fields = typeof(User).GetFields();
            foreach (var item in fields)
            {
                Console.WriteLine("Field:{0}\tValue:{1}", item.Name, item.GetValue(item.Name));
            }

            ColorWriteLine("列出属性：");
            var props = typeof(User).GetProperties();
            foreach (var item in props)
            {
                Console.WriteLine("Property:{0}\tCanRead:{1}\tCanWrite:{2}", item.Name, item.CanRead, item.CanWrite);
            }


            ColorWriteLine("列出方法：");
            var methods = typeof(User).GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine("MethodName:{0}", item.Name);
            }
        }

        private static void TestLoad()
        {
            User cls = new User();
            ColorWriteLine("列出属性：");
            foreach (var item in cls.GetType().GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            ColorWriteLine("typeof");
            Type t = typeof(System.String);
            Console.WriteLine(t);


            ColorWriteLine("Assembly.Load 程序集名");
            {
                object obj = Assembly.Load("AboutReflection").CreateInstance("AboutReflection.User");//反射创建
                User cls2 = obj as User;
                Console.WriteLine(cls2.Age);
            }
  

            ColorWriteLine("Assembly.LoadFrom 相对路径");
            {

                object obj = Assembly.LoadFrom("AboutReflection.exe").CreateInstance("AboutReflection.User");//反射创建
                User cls2 = obj as User;
                Console.WriteLine(cls2.Age);
            }

            
            ColorWriteLine("Assembly.LoadFile 绝对路径");
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



        static void ColorWriteLine(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + msg);
            Console.ResetColor();
        }
    }
}
