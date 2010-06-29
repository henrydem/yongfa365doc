////using System;
////using System.Collections;
////using System.Collections.Generic;
////using System.Text;
////using System.Threading;
////using System.IO;

////namespace ConsoleApplication1
////{
////    class CTask
////    {

////        private static int s_nActiveTasks = 0;
////        private static int s_nTaskNoSeed = 1;
////        public int nTaskNO;
////        public CTask()
////        {

////            nTaskNO = s_nTaskNoSeed++;
////        }
////        public void DoTask(object obj)
////        {
////            Interlocked.Increment(ref s_nActiveTasks);
////            Console.WriteLine("Task: {0} Start", nTaskNO);
////            for (int i = 0; i < 10; i++)
////            {
////                Console.Write(".");
////                Thread.Sleep(300);
////            }
////            Console.WriteLine("Task:{0} End", nTaskNO);
////            Interlocked.Decrement(ref s_nActiveTasks);
////        }
////        public static int ActiveTaskCount
////        {
////            get { return s_nActiveTasks; }
////        }

////    }
////    class Program
////    {

////        static void Main(string[] args)
////        {
////            int nCount = 10;
////            Thread[] arrThreads = new Thread[nCount];
////            for (int i = 0; i < nCount; i++)
////            {
////                Console.WriteLine("启动线程{0}.....", i);
////                arrThreads[i] = new Thread(new ThreadStart(fnThreadTest));
////                arrThreads[i].Start();
////            }
////            Console.WriteLine("线程启动完毕");
////            //等待所有工作运行结束
////            while (true)
////            {
////                int nWorker, nPort;
////                ThreadPool.GetAvailableThreads(out nWorker, out nPort);
////                Console.WriteLine("\r\n 主线程监视: 工作线程数：{0}，活跃任务数：{1}", nWorker, CTask.ActiveTaskCount);
////                if (nWorker > 0)
////                    break;
////                Thread.Sleep(3000);
////            }
////            Console.WriteLine("按任意键退出");
////            Console.Read();
////        }
////        static void CreateTask()
////        {
////            //将任务加入线程池
////            ThreadPool.QueueUserWorkItem(new WaitCallback(new CTask().DoTask));
////        }
////        static void fnThreadTest()
////        {
////            for (int i = 0; i < 100; i++)
////            {
////                CreateTask();
////            }
////        }



////    }
////}



//using System;
//using System.Threading;

//public class Worker
//{
//    // This method will be called when the thread is started.
//    public void DoWork()
//    {
//        while (!_shouldStop)
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("worker thread: working...");
//        }
//        Console.WriteLine("worker thread: terminating gracefully.");
//    }
//    public void RequestStop()
//    {
//        _shouldStop = true;
//    }
//    // Volatile is used as hint to the compiler that this data
//    // member will be accessed by multiple threads.
//    private volatile bool _shouldStop;
//}

//public class WorkerThreadExample
//{
//    static void Main()
//    {
//        // Create the thread object. This does not start the thread.
//        Worker workerObject = new Worker();
//        Thread workerThread = new Thread(workerObject.DoWork);

//        // Start the worker thread.
//        workerThread.Start();
//        Console.WriteLine("main thread: Starting worker thread...");

//        // Loop until worker thread activates.
//        while (!workerThread.IsAlive) ;

//        // Put the main thread to sleep for 1 millisecond to
//        // allow the worker thread to do some work:
//        Thread.Sleep(5000);

//        // Request that the worker thread stop itself:
//        workerObject.RequestStop();

//        // Use the Join method to block the current thread 
//        // until the object's thread terminates.
//        workerThread.Join();
//        Console.WriteLine("main thread: Worker thread has terminated.");
//        Console.ReadKey(); 
//    }
//}

//using System;
//using System.Threading;

//public class Fibonacci
//{
//    private ManualResetEvent _doneEvent;

//    private int _n;
//    public int N { get { return _n; } }


//    private int _fibOfN;
//    public int FibOfN { get { return _fibOfN; } }

//    public Fibonacci(int n, ManualResetEvent doneEvent)
//    {
//        _n = n;
//        _doneEvent = doneEvent;
//    }

//    // Wrapper method for use with thread pool.
//    public void ThreadPoolCallback(Object threadContext)
//    {
//        int threadIndex = (int)threadContext;
//        Console.WriteLine("thread {0} started...", threadIndex);
//        _fibOfN = Calculate(_n);
//        Console.WriteLine("thread {0} result calculated...", threadIndex);
//        _doneEvent.Set();
//    }

//    // Recursive method that calculates the Nth Fibonacci number.
//    public int Calculate(int n)
//    {
//        if (n <= 1)
//        {
//            return n;
//        }

//        return Calculate(n - 1) + Calculate(n - 2);
//    }




//}

//public class ThreadPoolExample
//{
//    static void Main()
//    {
//        const int FibonacciCalculations = 10;

//        // One event is used for each Fibonacci object
//        ManualResetEvent[] doneEvents = new ManualResetEvent[FibonacciCalculations];
//        Fibonacci[] fibArray = new Fibonacci[FibonacciCalculations];
//        Random r = new Random();

//        // Configure and launch threads using ThreadPool:
//        Console.WriteLine("launching {0} tasks...", FibonacciCalculations);
//        for (int i = 0; i < FibonacciCalculations; i++)
//        {
//            doneEvents[i] = new ManualResetEvent(false);
//            Fibonacci f = new Fibonacci(r.Next(20, 40), doneEvents[i]);
//            fibArray[i] = f;
//            ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
//        }

//        // Wait for all threads in pool to calculation...
//        WaitHandle.WaitAll(doneEvents);
//        Console.WriteLine("All calculations are complete.");

//        // Display the results...
//        for (int i = 0; i < FibonacciCalculations; i++)
//        {
//            Fibonacci f = fibArray[i];
//            Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
//        }
//        Console.ReadKey(); 
//    }
//}

//using System;
//using System.Threading;

//class Account
//{
//    private Object thisLock = new Object();
//    int balance;

//    Random r = new Random();

//    public Account(int initial)
//    {
//        balance = initial;
//    }

//    int Withdraw(int amount)
//    {

//        // This condition will never be true unless the lock statement
//        // is commented out:
//        if (balance < 0)
//        {
//            throw new Exception("Negative Balance");
//        }

//        // Comment out the next line to see the effect of leaving out 
//        // the lock keyword:
//        lock (thisLock)
//        {
//            if (balance >= amount)
//            {
//                Console.WriteLine("Balance before Withdrawal :  " + balance);
//                Console.WriteLine("Amount to Withdraw        : -" + amount);
//                balance = balance - amount;
//                Console.WriteLine("Balance after Withdrawal  :  " + balance);
//                return amount;
//            }
//            else
//            {
//                return 0; // transaction rejected
//            }
//        }
//    }

//    public void DoTransactions()
//    {
//        for (int i = 0; i < 100; i++)
//        {
//            Withdraw(r.Next(1, 100));
//        }
//    }
//}

//class Test
//{
//    static void Main()
//    {
//        Thread[] threads = new Thread[10];
//        Account acc = new Account(1000);
//        for (int i = 0; i < 10; i++)
//        {
//            Thread t = new Thread(new ThreadStart(acc.DoTransactions));
//            threads[i] = t;
//        }
//        for (int i = 0; i < 10; i++)
//        {
//            threads[i].Start();
//        }
//        Console.ReadKey(); 
//    }
//}

// nullable_type_operator.cs
// nullable_type_operator.cs
