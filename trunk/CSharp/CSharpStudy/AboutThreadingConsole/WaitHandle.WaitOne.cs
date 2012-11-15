using System;
using System.Threading;

namespace AboutThreading
{
    class WaitOne
    {
        public static ManualResetEvent manualEvent = new ManualResetEvent(false);

        public static void Run()
        {
            Console.WriteLine("Main starting.");

            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkMethod), manualEvent);

            // Wait for work method to signal.
            manualEvent.WaitOne();
            Console.WriteLine("Work method signaled.Main ending.");
            Console.ReadKey();
        }

        public static void WorkMethod(object stateInfo)
        {
            Console.WriteLine("Work starting.");

            // Simulate time spent working.
            Thread.Sleep(new Random().Next(100, 2000));

            // Signal that work is finished.
            Console.WriteLine("Work ending.");

            ((ManualResetEvent)stateInfo).Set();
        }
    }
}
