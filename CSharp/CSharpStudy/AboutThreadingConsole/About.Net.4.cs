using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutThreadingConsole
{
    class AboutNet4
    {
        public static void Run()
        {

            var dict = new ConcurrentDictionary<int, string>();

            Func<int, string> funcAdd = (i) => i.ToString();
            Func<int, string, string> funcUpdate = (key, oldValue) => oldValue + key;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    dict.GetOrAdd(i, funcAdd);
                }
            });


            Task.Factory.StartNew(() =>
            {
                dict.AddOrUpdate(0, funcAdd, funcUpdate);
                Console.WriteLine(dict[0]);
            }).Wait();


        }
    }
}
