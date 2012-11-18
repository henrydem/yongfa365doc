using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AboutThreadingConsole
{
    class AboutThread
    {



        #region Error
        private static List<int> list;
        public static void RunError()
        {
            list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }

            new Thread(T2).Start();
            new Thread(T3).Start();
        }

        static void T2()
        {
            Thread.Sleep(100);
            for (int i = 0; i < 50; i++)
            {
                list.Remove(i);
            }
        }
        static void T3()
        {
            foreach (var a in list)
            {
                Console.WriteLine(a);
            }
        }
        #endregion

        public static void RunSuccess()
        {
            var conList = new ConcurrentBag<int>();
            for (int i = 0; i < 10; i++)
            {
                conList.Add(i);
            }

            var task1 = new Task(()=>
            {
                for (int i = 0; i < 50000; i++)
                {
                    Thread.Sleep(500);
                    conList.TryTake(out i);
                }
            });

            task1.Start();

            var task2 = Task.Factory.StartNew(() =>
            {
                //此線程取數據后，則不受之前
                foreach (var a in conList)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("當前線程迭代數據：{0} 外部的集合.Count:{1}", a, conList.Count);
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine("OK");
            Console.ReadLine();
        }



    }
}
