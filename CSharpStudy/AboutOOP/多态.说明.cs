//using System;
//c#多态

//多态是面向对象编程中三大机制之一,其原理建立在"从父类继承而来的子类可以转换为其父类"这个规则之上,换句话说,能用父类的地方,就能用该类的子类.当从父类派生了很多子类时,由于每个子类都有其不同的代码实现,所以当用父类来引用这些子类时,同样的操作而可以表现出不同的操作结果,这就是所谓的多态.

//1.了解什么是多态性

//2.如何定义一个虚方法

//3.如何重写一个虚方法

//4.如何在程序中运用多态性

//面向对象程序设计中的另外一个重要概念是多态性。
//在运行时，可以通过指向基类的指针，来调用实现派生类中的方法。
//可以把一组对象放到一个数组中，然后调用它们的方法，在这种场合下，多态性作用就体现出来了，这些对象不必是相同类型的对象。
//当然，如果它们都继承自某个类，你可以把这些派生类，都放到一个数组中。
//如果这些对象都有同名方法，就可以调用每个对象的同名方法。本节课将向你介绍如何完成这些事情。

//1.清单9-1. 带有虚方法的基类：DrawingObject.cs

//using System;
//public class DrawingObject
//{
//    public virtual void Draw()
//    {
//        Console.WriteLine("I'm just a generic drawing object.");
//    }
//}

//说明

//清单9-1 定义了DrawingObject类。这是个可以让其他对象继承的基类。该类有一个名为Draw()的方法。Draw()方法带有一个virtual修饰符，该修饰符表明：该基类的派生类可以重载该方法。DrawingObject类的 Draw()方法完成如下事情：输出语句"I'm just a generic drawing object."到控制台。

//2.清单9-2. 带有重载方法的派生类：Line.cs, Circle.cs, and Square.cs

//using System;
//public class Line : DrawingObject
//{
//    public override void Draw()
//    {
//        Console.WriteLine("I'm a Line.");
//    }
//}

//public class Circle : DrawingObject
//{
//    public override void Draw()
//    {
//        Console.WriteLine("I'm a Circle.");
//    }
//}

//public class Square : DrawingObject
//{
//    public override void Draw()
//    {
//        Console.WriteLine("I'm a Square.");
//    }
//}

//说明

//清单9-2定义了三个类。这三个类都派生自DrawingObject类。每个类都有一个同名Draw()方法，这些Draw()方法中的每一个都有一个重载修饰符。重载修饰符可让该方法在运行时重载其基类的虚方法，实现这个功能的条件是：通过基类类型的指针变量来引用该类。

//3.清单9-3. 实现多态性的程序：DrawDemo.cs

//using System;
//public class DrawDemo
//{
//    public static int Main(string[] args)
//    {
//        DrawingObject[] dObj = new DrawingObject[4];
//        dObj[0] = new Line();
//        dObj[1] = new Circle();
//        dObj[2] = new Square();
//        dObj[3] = new DrawingObject();
//        foreach (DrawingObject drawObj in dObj)
//        {
//            drawObj.Draw();
//        }
//        Console.ReadKey();
//        return 0;

//    }
//}

//说明

//清单9-3演示了多态性的实现，该程序使用了在清单 9-1 和清单9-2中定义的类。在DrawDemo类中的Main()方法中，创建了一个数组， 数组元素是DrawingObject 类的对象。该数组名为dObj，是由四个DrawingObject类型的对象组成。

//接下来， 初始化dObj数组， 由于Line， Circle和Square类都是DrawingObject类的派生类，所以这些类可以作为dObj数组元素的类型。如果C#没有这种功能，你得为每个类创建一个数组。继承的性质可以让派生对象当作基类成员一样用，这样就节省了编程工作量。

//一旦数组初始化之后，接着是执行foreach循环，寻找数组中的每个元素。在每次循环中， dObj 数组的每个元素（对象）调用其Draw()方法。多态性体现在：在运行时，各自调用每个对象的Draw()方法。尽管dObj 数组中的引用对象类型是DrawingObject，这并不影响派生类重载DrawingObject 类的虚方法Draw()。 在dObj 数组中，通过指向DrawingObject 基类的指针来调用派生类中的重载的Draw()方法。

//输出结果是：

//I'm a Line.
//I'm a Circle.
//I'm a Square.
//I'm just a generic drawing object.

//在DrawDemo 程序中，调用了每个派生类的重载的Draw()方法。最后一行中，执行的是DrawingObject类的虚方法Draw()。这是因为运行到最后，数组的第四个元素是DrawingObject类的对象。

//小结
//现在对多态性有所了解之后，你可以在派生类中，实现一个重载基类虚方法的方法。虚方法和重载的派生类方法之间的关系就体现出C#的多态性。
