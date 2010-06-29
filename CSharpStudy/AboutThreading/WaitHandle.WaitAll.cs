using System;
using System.Threading;

namespace AboutThreading
{

    public class OneCalc
    {
        public int N { get { return _n; } }
        private int _n;

        public int FibOfN { get { return _fibOfN; } }
        private int _fibOfN;

        private ManualResetEvent _doneEvent;

        public OneCalc(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        // Wrapper method for use with thread pool.
        public void ThreadPoolCallback(Object threadContext)
        {
            Console.WriteLine("thread {0} started...", threadContext);
            _fibOfN = Calculate(_n);
            Console.WriteLine("thread {0} result calculated...", threadContext);
            _doneEvent.Set();
        }

        // Recursive method that calculates the Nth Fibonacci number.
        public int Calculate(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }


    }

    public class ThreadPoolExample
    {
        static void Main34()
        {
            const int TaskCount = 10;

            // One event is used for each Fibonacci object
            ManualResetEvent[] doneEvents = new ManualResetEvent[TaskCount];
            OneCalc[] fibArray = new OneCalc[TaskCount];
            Random r = new Random();

            // Configure and launch threads using ThreadPool:
            Console.WriteLine("launching {0} tasks...", TaskCount);
            for (int i = 0; i < TaskCount; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                OneCalc f = new OneCalc(r.Next(20, 40), doneEvents[i]);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculation...
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");
            Console.ReadKey();

            // Display the results...
            for (int i = 0; i < TaskCount; i++)
            {
                OneCalc f = fibArray[i];
                Console.WriteLine("OneCalc({0}) = {1}", f.N, f.FibOfN);
            }
        }

    }
}
