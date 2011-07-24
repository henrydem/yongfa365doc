using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AboutThreading
{
    class Threads
    {
        void Run()
        {
            int count = 10;
            Thread[] threads = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                threads[i] = new Thread(new ThreadStart(Fun));
                threads[i].Start();
            }

            Console.WriteLine("主线程分配完毕");

            for (int i = 0; i < count; i++)
            {
                //一个一个Join
                threads[i].Join();
            }
            Console.WriteLine("程序运行结束");
            Console.ReadKey();
        }

        void Fun()
        {
            Console.WriteLine("次线程");
            Thread.Sleep(3000);
        }


    }
}
