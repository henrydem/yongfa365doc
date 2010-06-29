using System;
using System.Threading;

namespace AboutThreading
{
    class WaitOne
    {
        static ManualResetEvent manualEvent = new ManualResetEvent(false);

        static void Main12()
        {
            Console.WriteLine("Main starting.");

            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkMethod), manualEvent);

            // Wait for work method to signal.
            manualEvent.WaitOne();
            Console.WriteLine("Work method signaled.Main ending.");
            Console.ReadKey();
        }

        static void WorkMethod(object stateInfo)
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
