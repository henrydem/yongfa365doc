// Copyright   : �����֪����.NET
// Author      : Anytao��http://www.anytao.com
// FileName    : InsideDotNet.Keyword.BaseAndThis
// Release     : 2007/05/04 1.0
// Description : 6.2  base��this

using System;

namespace InsideDotNet.Keyword.BaseAndThis
{
    public class Action
    {
        public static void ToRun(Vehicle vehicle)
        {
            Console.WriteLine("{0} is running.", vehicle.ToString());
        }
    }

    public class Vehicle
    {
        private string name;
        private int speed;
        private string[] array = new string[10];

        public Vehicle()
        {
        }

        //�޶������Ƶ��������صĳ�Ա
        public Vehicle(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        public virtual void ShowResult()
        {
            Console.WriteLine("The top speed of {0} is {1}.", name, speed);
        }

        public void Run()
        {

            //���ݵ�ǰʵ������
            Action.ToRun(this);
        }

        //����������������Ϊthis�������Ϳ���������һ������������
        public string this[int param]
        {
            get { return array[param]; }
            set { array[param] = value; }
        }
    }

    public class Car : Vehicle
    {
        //������ͻ���ͨ�ţ���baseʵ�֣��������ȱ�����
        //ָ������������ʵ��ʱӦ���õĻ��๹�캯��
        public Car()
            : base("Car", 200)
        { }

        public Car(string name, int speed)
            : this()
        { }

        public override void ShowResult()
        {
            //���û������ѱ�����������д�ķ���
            base.ShowResult();
            Console.WriteLine("It's a car's result.");
        }
    }

    public class Audi : Car
    {
        public Audi()
            : base("Audi", 300)
        { }

        public Audi(string name, int speed)
            : this()
        {
        }

        public override void ShowResult()
        {
            //������̳п��Կ�����baseֻ�ܼ̳���ֱ�ӻ����Ա
            base.ShowResult();
            base.Run();
            Console.WriteLine("It's audi's result.");
        }
    }

    public class Test_baseAndthis
    {
        public static void Main()
        {
            //Audi audi = new Audi();
            //audi[1] = "A6";
            //audi[2] = "A8";
            //Console.WriteLine(audi[1]);
            //audi.Run();
            //audi.ShowResult();
            Car car = new
                 Car("dsafasdf",1000);
            car.ShowResult();
            Console.ReadKey();
        }
    }
}
