﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AboutOOP
{
    //using System;
    //public class A
    //{
    //    public void F() { Console.WriteLine("A.F"); }
    //    public virtual void G() { Console.WriteLine("A.G"); }
    //}
    //public class B : A
    //{
    //    new public void F() { Console.WriteLine("B.F"); }
    //    public override void G() { Console.WriteLine("B.G"); }
    //}
    //public class c
    //{
    //    public static void Main()
    //    {
    //        B b = new B();
    //        A a = b;
    //        a.F();
    //        b.F();
    //        a.G();
    //        b.G();
    //        Console.ReadKey();
    //    }
    //}









    //A.F
    //B.F
    //B.G
    //B.G







    //////////////////////////////////////////////////////////////////////////////////////

    //using System;
    //class A
    //{
    //    public virtual void F() { Console.WriteLine("A.F"); }
    //}
    //class B : A
    //{
    //    public override void F() { Console.WriteLine("B.F"); }
    //}
    //class C : B
    //{
    //    new public virtual void F() { Console.WriteLine("C.F"); }
    //}
    //class D : C
    //{
    //    public override void F() { Console.WriteLine("D.F"); }
    //}
    //class Test
    //{
    //    public static void Main()
    //    {
    //        D d = new D();
    //        A a = d;
    //        B b = d;
    //        C c = d;
    //        a.F();
    //        b.F();
    //        c.F();
    //        d.F();
    //        Console.ReadKey();
    //    }
    //}








    //B.F
    //B.F
    //D.F
    //D.F








    ////////////////////////////////////////////////////////////////////////////////////////
    //每一个类都有自己的构造函数,没有构造函数你就不能对它实例化.
    //1.有的类看起来没有构造函数,但在编译器编译时会创建默认的无参构造函数.
    //2.如有自己的构造函数,就不会在编译时创建默认的构造函数.
    //3.在静态类中,也是有个构造函数的,必须是静并无参.


    //new的时候（实例化一个类时），先创建变量，再执行构造函数。
    //子类变量-->父类变量-->...顶级父类变量-->顶级父类构造函数-->子类构造函数...-->最终类构造函数

    //using System;
    //public class A
    //{
    //    public string s = "";
    //    public A()
    //    {
    //        Console.WriteLine("A");
    //    }
    //    public virtual void Fun1(int i)
    //    {
    //        Console.WriteLine(i);
    //    }
    //    public virtual void Fun2(A a)
    //    {
    //        a.Fun1(1);
    //        Fun1(3);
    //    }
    //}

    //public class B : A
    //{
    //    public B()
    //    {
    //        Console.WriteLine("B");
    //    }
    //    public override void Fun1(int i)
    //    {
    //        base.Fun1(i + 1);
    //    }
    //    public new void Fun2(A a)
    //    {
    //        a.Fun1(2);
    //        Fun1(5);
    //    }
    //    public static void Main()
    //    {
    //        A b = new B();
    //        A a = new A();
    //        a.Fun2(b);
    //        b.Fun2(a);
    //        Console.ReadKey();
    //    }
    //}









    //A
    //B
    //A
    //2
    //3
    //1
    //4



    //using System;
    //public class A
    //{
    //    public static string s = "";
    //    public A()
    //    {
    //        Console.WriteLine("A");
    //    }
    //}

    //public class B : A
    //{
    //    public string s = "";
    //    public B()
    //    {
    //        Console.WriteLine("A");
    //    }
    //}
    //public class C : B
    //{
    //    public string s = "";
    //    public C()
    //    {
    //        Console.WriteLine("A");
    //    }
    //    public static void Main()
    //    {
    //        C b = new C();
    //    }
    //}











    //Main放在类里与放在类外，执行A.X或B.Y结果是不一样的
    //Main放在类里，先执行类里的静态变量，
    //Main放在类外，谁在前先执行谁
    //静态字段及静态构造函数，及相关调用同样，先静态变量，再静态方法,

    public class A
    {
        public static int X = 0;
        static A()
        {
            X = B.Y + 1;
        }
    }


    public class B
    {
        public static int Y = A.X + 1;
        static B()
        {
        }
    }


    class MyClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("A.X:{0} ,B.Y{1}\t\n", A.X, B.Y));
            // Console.WriteLine(String.Format("A.X:{1} ,B.Y{0}\t\n", B.Y, A.X));
            Console.ReadKey();
        }
    }

    ////////////////////////////////////////////////
    //如果Main在其中一个类里，就一定先执行这个类里的静态字段

    //class A
    //{
    //    public static int X = 0;//2
    //    static A()
    //    {
    //        X = B.Y + 1;//3
    //    }
    //}
    //class B
    //{
    //    public static int Y = A.X + 1;//1
    //    static B() 
    //    {
    //        //4
    //    }
    //    static void Main()
    //    {
    //        //不论先A.X还是先B.Y都先执行Main所在的类里的字段
    //        Console.WriteLine("X={0},Y={1}", A.X, B.Y);
    //    }
    //}



    //public class Test
    //{
    //    static void Main(string[] args)
    //    {
    //        Child child = new Child();
    //    }
    //}

    //class Parent
    //{
    //    public Parent()
    //    {
    //        Console.WriteLine("to construct Parent.");
    //    }
    //}

    //class Child : Parent
    //{
    //    public Child()
    //    {
    //        Console.WriteLine("to construct Child.");
    //    }

    //    MyClass delegatee = new MyClass();//是变量，所以先执行他
    //}

    //class MyClass
    //{
    //    public MyClass()
    //    {
    //        Console.WriteLine("to construct MyClass.");
    //    }
    //}

}
