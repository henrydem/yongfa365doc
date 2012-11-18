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
                                        Func<Stock, bool> fun = p => { return p.ProductID == 1 && p.Date == new DateTime(2012, 1, 1); };
                                        Add(fun, 2);
                                    }

                                    ,

                                    () =>
                                    {
                                        Func<Stock, bool> fun = p => { return p.ProductID == 1 && p.Date == new DateTime(2012, 1, 1); };
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



    class StockConcurrent
    {
        ConcurrentDictionary<long, Stock> doingList = new ConcurrentDictionary<long, Stock>();


        public void Run()
        {
            Stock.MoreIt();
            var time = DateTime.Now;

            for (int i = 0; i < 100; i++)
            {
                Parallel.Invoke(
                                    () =>
                                    {
                                        Func<Stock, bool> fun = p => { return p.ProductID == 1 && p.Date == new DateTime(2012, 1, 1); };
                                        Add(fun, 2);
                                    }

                                    ,

                                    () =>
                                    {
                                        Func<Stock, bool> fun = p => { return p.ProductID == 1 && p.Date == new DateTime(2012, 1, 1); };
                                        Sub(fun, 3);
                                    }

                                );
            }

            Console.WriteLine(DateTime.Now - time);


        }




        public void Add(Func<Stock, bool> fun, int number)
        {
            StartLabel:
            var list = Stock.DB.Where(fun);
            if (list.Any(p=>doingList.Keys.Contains(p.StockID)))
            {
                Thread.Sleep(100);
                goto StartLabel;
            }
     
            foreach (var item in list)
            {
                if (!doingList.TryAdd(item.StockID, null))
                {
                    goto StartLabel;
                }
                ;
                item.Number += number;
            }

        }

        public void Sub(Func<Stock, bool> fun, int number)
        {

            var list = Stock.DB.Where(fun);
            foreach (var item in list)
            {
                item.Number -= number;
            }

        }



    }


    [DebuggerDisplay("StockID={StockID},ProductID={ProductID}, Date={Date}, Number={Number}")]
    public class Stock
    {
        public long StockID { get; set; }
        public int ProductID { get; set; }
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
                    db.Add(new Stock { StockID = 1, ProductID = 1, Date = new DateTime(2012, 1, 1), Number = 0 });
                    db.Add(new Stock { StockID = 2, ProductID = 1, Date = new DateTime(2012, 1, 2), Number = 0 });
                    db.Add(new Stock { StockID = 3, ProductID = 1, Date = new DateTime(2012, 1, 3), Number = 0 });
                    db.Add(new Stock { StockID = 4, ProductID = 2, Date = new DateTime(2012, 1, 1), Number = 0 });
                    db.Add(new Stock { StockID = 5, ProductID = 2, Date = new DateTime(2012, 1, 2), Number = 0 });
                    db.Add(new Stock { StockID = 6, ProductID = 2, Date = new DateTime(2012, 1, 3), Number = 0 });
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
                Stock.DB.Add(new Stock { StockID = i, ProductID = i < 1000 ? 1 : 2, Date = new DateTime(2012, 1, 1).AddHours(i), Number = 0 });
            }
        }
    }
}
