using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Threading;

namespace AboutThreadingConsole
{
    class StockChangeWithLock
    {
        static object objStockLock = new object();

        public void Run()
        {
            Stock.MoreIt();
            var time = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                Parallel.Invoke(
                                    () =>
                                    {
                                        Func<Stock, bool> fun = p => { return p.Date == new DateTime(2012, 1, 1); };
                                        Add(fun, 2);
                                    }

                                    ,

                                    () =>
                                    {
                                        Func<Stock, bool> fun = p => { return p.Date == new DateTime(2012, 1, 1); };
                                        Sub(fun, 3);
                                    }

                                );
            }

            Console.WriteLine(DateTime.Now - time);


        }




        public void Add(Func<Stock, bool> fun, int number)
        {
            lock (objStockLock)
            {
                var list = Stock.DB.Where(fun);
                foreach (var item in list)
                {
                    item.Number += number;
                }
            }
        }

        public void Sub(Func<Stock, bool> fun, int number)
        {
            lock (objStockLock)
            {
                var list = Stock.DB.Where(fun);
                foreach (var item in list)
                {
                    item.Number -= number;
                }
            }
        }



    }


    /// <summary>
    /// 策略：
    /// 线程A需要资源：1,2,3,4,5
    /// 线程B需要资源：5,4,3,2,1
    /// 当A已经申请了1,2，B也已经申请了5,4，他们都要占3时，则只有一个能申请成功。
    /// 假设A抢成功了，则B要返回所有他申请的资源5,4。
    /// 如果B返回速度比A申请速度快，则A可以顺利申请到5,4。而B会等待一会再重试，直到申请上资源
    /// 反之，B还没来得及返回2，而A已经开始申请2了，则A也因申请不到资源而要释放自己的资源。最后两败俱伤。如果线程较多都在抢资源，则此情况则较多。所以我们最好让申请速度加快。
    /// 申请资源后因为已经归自己所有，所以慢慢处理吧，因为没锁所有资源，所以此时除了自己要锁的资源外，其它资源其它线程还照样可以用。
    /// </summary>
    class StockConcurrent
    {
        //静态池
        static ConcurrentDictionary<long, Stock> dictRequestPool = new ConcurrentDictionary<long, Stock>();
        int optAddNumber = 2;
        int optSubNumber = 1;
        int optRecordCount = 10;
        int optConcurrentCount = 100;
        int sleepNumber = 1;
        int? showLevel = 1;

        public void Run()
        {

            var time = DateTime.Now;

            for (int i = 0; i < optConcurrentCount; i++)
            {
                Parallel.Invoke(Add,Sub);
            }
            var aaa = Stock.DB;
            Console.WriteLine(DateTime.Now - time);

            Console.ReadLine();
        }

        public void Log(int level, string msg)
        {
            if (showLevel.HasValue)
            {
                if (showLevel.Value == level)
                {
                    Console.WriteLine(msg);
                    return;
                }
                return;
            }
            Console.WriteLine(msg);
        }


        public void Add()
        {
            Log(2, "Add 1");
            //第一步：准备待处理的资源
            var lstWant = new List<long>();
            for (int i = 1; i < optRecordCount; i++)
            {
                lstWant.Add(i);
            }


        StartLabel:

            Log(2, "Add 2");
            //第二步：抢资源
            if (lstWant.Any(p => dictRequestPool.Keys.Contains(p)))
            {
                Thread.Sleep(sleepNumber);
                goto StartLabel;
            }


            var lstHasInPool = new List<long>();

            foreach (var item in lstWant)
            {
                if (!dictRequestPool.TryAdd(item, null))
                {
                    Log(1, "Add Back");
                    //只要有添加失败的，就是存在竞争，则自己退出
                    foreach (var item2 in lstHasInPool)
                    {
                        Stock s;
                        dictRequestPool.TryRemove(item2, out s);//因为这些都是自己添加的，所以肯定退出是安全的。
                    }
                    //重新开始
                    goto StartLabel;
                }

                lstHasInPool.Add(item);
            }


            Log(2, "Add 3");
            //第三步：资源到手，慢慢处理。
            Thread.Sleep(1);
            Stock.DB.Where(p => lstHasInPool.Contains(p.StockID)).ToList().ForEach(item =>
            {
                item.Number += optAddNumber;
            });



            Log(2, "Add 4");
            //第四步：放手，资源处理完了就放回去吧。
            foreach (var item in lstHasInPool)
            {
                Stock s;
                dictRequestPool.TryRemove(item, out s);
            }

        }

        public void Sub()
        {
            Log(2, "Sub 1");
            //第一步：准备待处理的资源
            var lstWant = new List<long>();
            for (int i = optRecordCount - 1; i > 0; i--)
            {
                lstWant.Add(i);
            }




        StartLabel:

            Log(2, "Sub 2");
            //第二步：抢资源
            if (lstWant.Any(p => dictRequestPool.Keys.Contains(p)))
            {
                Thread.Sleep(sleepNumber);
                goto StartLabel;
            }


            var lstHasInPool = new List<long>();

            foreach (var item in lstWant)
            {
                if (!dictRequestPool.TryAdd(item, null))
                {
                    Log(1, "Sub Back");
                    //只要有添加失败的，就是存在竞争，则自己退出
                    foreach (var item2 in lstHasInPool)
                    {
                        Stock s;
                        dictRequestPool.TryRemove(item2, out s);//因为这些都是自己添加的，所以肯定退出是安全的。
                    }
                    //重新开始
                    goto StartLabel;
                }

                lstHasInPool.Add(item);
            }


            Log(2, "Sub 3");
            //第三步：资源到手，慢慢处理。
            Thread.Sleep(1);
            Stock.DB.Where(p => lstHasInPool.Contains(p.StockID)).ToList().ForEach(item =>
            {
                item.Number -= optSubNumber;
            });


            Log(2, "Sub 4");
            //第四步：放手，资源处理完了就放回去吧。
            foreach (var item in lstHasInPool)
            {
                Stock s;
                dictRequestPool.TryRemove(item, out s);
            }

        }



    }


    [DebuggerDisplay("StockID={StockID}, Date={Date}, Number={Number}")]
    public class Stock
    {
        public long StockID { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }

        private static List<Stock> db { get; set; }
        public static List<Stock> DB
        {
            get
            {
                if (db == null)
                {
                    db = new List<Stock>();
                    db.Add(new Stock { StockID = 1, Date = new DateTime(2012, 1, 1), Number = 0 });
                    db.Add(new Stock { StockID = 2, Date = new DateTime(2012, 1, 2), Number = 0 });
                    db.Add(new Stock { StockID = 3, Date = new DateTime(2012, 1, 3), Number = 0 });
                    db.Add(new Stock { StockID = 4, Date = new DateTime(2012, 1, 1), Number = 0 });
                    db.Add(new Stock { StockID = 5, Date = new DateTime(2012, 1, 2), Number = 0 });
                    db.Add(new Stock { StockID = 6, Date = new DateTime(2012, 1, 3), Number = 0 });
                }
                return db;
            }
        }

        public static void MoreIt()
        {

            //for (int i = 0; i < 20; i++)
            //{
            //    Stock.DB.AddRange(Stock.DB); 
            //}
            for (int i = 0; i < 1000000; i++)
            {
                Stock.DB.Add(new Stock { StockID = i, Date = new DateTime(2012, 1, 1).AddHours(i), Number = 0 });
            }
        }
    }
}
