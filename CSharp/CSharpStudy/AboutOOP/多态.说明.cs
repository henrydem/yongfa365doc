//using System;
//c#��̬

//��̬��������������������֮һ,��ԭ������"�Ӹ���̳ж������������ת��Ϊ�丸��"�������֮��,���仰˵,���ø���ĵط�,�����ø��������.���Ӹ��������˺ܶ�����ʱ,����ÿ�����඼���䲻ͬ�Ĵ���ʵ��,���Ե��ø�����������Щ����ʱ,ͬ���Ĳ��������Ա��ֳ���ͬ�Ĳ������,�������ν�Ķ�̬.

//1.�˽�ʲô�Ƕ�̬��

//2.��ζ���һ���鷽��

//3.�����дһ���鷽��

//4.����ڳ��������ö�̬��

//��������������е�����һ����Ҫ�����Ƕ�̬�ԡ�
//������ʱ������ͨ��ָ������ָ�룬������ʵ���������еķ�����
//���԰�һ�����ŵ�һ�������У�Ȼ��������ǵķ����������ֳ����£���̬�����þ����ֳ����ˣ���Щ���󲻱�����ͬ���͵Ķ���
//��Ȼ��������Ƕ��̳���ĳ���࣬����԰���Щ�����࣬���ŵ�һ�������С�
//�����Щ������ͬ���������Ϳ��Ե���ÿ�������ͬ�����������ڿν����������������Щ���顣

//1.�嵥9-1. �����鷽���Ļ��ࣺDrawingObject.cs

//using System;
//public class DrawingObject
//{
//    public virtual void Draw()
//    {
//        Console.WriteLine("I'm just a generic drawing object.");
//    }
//}

//˵��

//�嵥9-1 ������DrawingObject�ࡣ���Ǹ���������������̳еĻ��ࡣ������һ����ΪDraw()�ķ�����Draw()��������һ��virtual���η��������η��������û����������������ظ÷�����DrawingObject��� Draw()��������������飺������"I'm just a generic drawing object."������̨��

//2.�嵥9-2. �������ط����������ࣺLine.cs, Circle.cs, and Square.cs

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

//˵��

//�嵥9-2�����������ࡣ�������඼������DrawingObject�ࡣÿ���඼��һ��ͬ��Draw()��������ЩDraw()�����е�ÿһ������һ���������η����������η����ø÷���������ʱ�����������鷽����ʵ��������ܵ������ǣ�ͨ���������͵�ָ����������ø��ࡣ

//3.�嵥9-3. ʵ�ֶ�̬�Եĳ���DrawDemo.cs

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

//˵��

//�嵥9-3��ʾ�˶�̬�Ե�ʵ�֣��ó���ʹ�������嵥 9-1 ���嵥9-2�ж�����ࡣ��DrawDemo���е�Main()�����У�������һ�����飬 ����Ԫ����DrawingObject ��Ķ��󡣸�������ΪdObj�������ĸ�DrawingObject���͵Ķ�����ɡ�

//�������� ��ʼ��dObj���飬 ����Line�� Circle��Square�඼��DrawingObject��������࣬������Щ�������ΪdObj����Ԫ�ص����͡����C#û�����ֹ��ܣ����Ϊÿ���ഴ��һ�����顣�̳е����ʿ��������������������Աһ���ã������ͽ�ʡ�˱�̹�������

//һ�������ʼ��֮�󣬽�����ִ��foreachѭ����Ѱ�������е�ÿ��Ԫ�ء���ÿ��ѭ���У� dObj �����ÿ��Ԫ�أ����󣩵�����Draw()��������̬�������ڣ�������ʱ�����Ե���ÿ�������Draw()����������dObj �����е����ö���������DrawingObject���Ⲣ��Ӱ������������DrawingObject ����鷽��Draw()�� ��dObj �����У�ͨ��ָ��DrawingObject �����ָ���������������е����ص�Draw()������

//�������ǣ�

//I'm a Line.
//I'm a Circle.
//I'm a Square.
//I'm just a generic drawing object.

//��DrawDemo �����У�������ÿ������������ص�Draw()���������һ���У�ִ�е���DrawingObject����鷽��Draw()��������Ϊ���е��������ĵ��ĸ�Ԫ����DrawingObject��Ķ���

//С��
//���ڶԶ�̬�������˽�֮����������������У�ʵ��һ�����ػ����鷽���ķ������鷽�������ص������෽��֮��Ĺ�ϵ�����ֳ�C#�Ķ�̬�ԡ�
