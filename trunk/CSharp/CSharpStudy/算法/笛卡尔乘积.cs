using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 算法
{
    class 笛卡尔乘积
    {
        static void Exec(string msg, Func<List<string>> func)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("======================{0}===========================", msg);
            Console.ResetColor();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var lstResult = func();
            sw.Stop();
            Console.WriteLine("Count:{0}, Run Time:{1}", lstResult.Distinct().Count(), sw.Elapsed);
            lstResult.ForEach(p => Console.WriteLine(p));
        }

        public static void Run()
        {
            var lstSource = new List<List<string>>()
            {
                new List<string>() { "A","B","C"},
                new List<string>() { "D","E","F"},
                new List<string>() { "G","H","I"},
            };



            Exec("Method0", () =>
            {
                return Method0(lstSource);
            });

            Exec("Method1", () =>
            {
                return Method1(lstSource);
            });

            Exec("Method2", () =>
            {
                return Method2(lstSource);
            });

            Exec("Descartes", () =>
            {
                var lstResult = new List<string>();
                Descartes(lstSource, 0, lstResult, "");
                return lstResult;
            });
        }




        private static List<string> Method0(List<List<string>> lst)
        {
            var query = (from a in lst[0]
                         from b in lst[1]
                         from c in lst[2]
                         select a + b + c).ToList();
            return query;
        }


        private static List<string> Method1(List<List<string>> lst)
        {
            return lst.Aggregate((current, total) => total.Join(current, (string x) => 1, (string y) => 1, (string a, string b) => b + a).ToList());
        }


        private static List<string> Method2(List<List<string>> lst)
        {
            return lst.Aggregate(new List<string> { "-->" }, (r, s) => (from a in r from b in s select a + b).ToList());
        }


        private static string Descartes(List<List<string>> data, int level, List<string> result, string s)
        {
            var temp = s;
            foreach (var item in data[level])
            {
                if (level < data.Count - 1)
                {
                    temp += Descartes(data, level + 1, result, s + item);
                }
                else
                {
                    result.Add(s + item);
                }
            }
            return temp;
        }



        private static string look(List<List<string>> data, int level,string s )
        {
            var builder = new StringBuilder();
            foreach (var item in data[level])
            {
                if (level < data.Count - 1)
                {
                    builder.Append(look(data, level + 1,s + item ));
                }
                else
                {
                    builder.Append(s + item + ",");
                }
            }
            return builder.ToString();
        }

    }
}
