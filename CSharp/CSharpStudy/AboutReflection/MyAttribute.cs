using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutReflection
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class MyAttribute : Attribute
    {
        public string Str { get; set; }
        public bool B { get; set; }
        public ConsoleColor Color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="h">hhhhh</param>
        /// <param name="b">bbbbbbb</param>
        public MyAttribute(string str, ConsoleColor color, bool b = true)
        {
            Str = str;
            B = b;
        }
    }

    //如果没有参数可省略()直接[My]
    //源为[MyAttribute]但可以简写为[My],两种写法都可以
    //调用 IsDefined速度快
    //调用 GetCustomAttributes,会创建相应实例
    [My("heheheheheh", ConsoleColor.Black)]
    class MyClass
    {

    }

    class MyAttributeTest
    {
        public static void Test()
        {
            MyClass hello = new MyClass();
            var type = hello.GetType();
            if (type.IsDefined(typeof(MyAttribute), false))
            {
                foreach (var item in MyAttribute.GetCustomAttributes(type))
                {
                    var obj = item as MyAttribute;
                    Console.WriteLine("Str:{0};B:{1};Color:{2}", obj.Str, obj.B, obj.Color);
                }
            }
            var a = hello.GetType().IsDefined(typeof(MyAttribute), false);//true
            var adsfsadf = MyAttribute.GetCustomAttributes(typeof(MyClass));//true
        }
    }


}
