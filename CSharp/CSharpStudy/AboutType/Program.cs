using System;
using System.Collections.Generic;
using System.Text;

namespace AboutType
{
    class Program
    {
        enum MyEnum
        {

        }
        struct MyStruct
        {

        }
        class MyClass
        {

        }

        public static void IsValueType<T>()
        {
            Console.WriteLine("typeof({0}).IsValueType\t==\t{1}", typeof(T).Name, typeof(T).IsValueType);
        }


        static void Main(string[] args)
        {
            IsValueType<MyEnum>();
            IsValueType<MyStruct>();
            IsValueType<MyClass>();
            IsValueType<DateTime>();
            IsValueType<string>();
            IsValueType<char>();
            IsValueType<int>();
            Console.ReadKey();
        }
        //typeof(MyEnum).IsValueType      ==      True
        //typeof(MyStruct).IsValueType    ==      True
        //typeof(MyClass).IsValueType     ==      False
        //typeof(DateTime).IsValueType    ==      True
        //typeof(String).IsValueType      ==      False
        //typeof(Char).IsValueType        ==      True
        //typeof(Int32).IsValueType       ==      True

    }
}
