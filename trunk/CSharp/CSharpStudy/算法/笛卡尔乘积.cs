using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace 算法
{
    class 笛卡尔乘积
    {
        static void Exec<T>(string msg, Func<List<T>> func)
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

            Exec("Method3", () =>
            {
                var lstResult = new List<string>();
                Method3(lstSource, 0, lstResult, "");
                return lstResult;
            });

            Exec("Method4", () =>
            {
                return Method4(lstSource);
            });

            Exec("Method5", () =>
            {
                return Method4(lstSource);
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


        private static string Method3(List<List<string>> data, int level, List<string> result, string s)
        {
            var temp = s;
            foreach (var item in data[level])
            {
                if (level < data.Count - 1)
                {
                    temp += Method3(data, level + 1, result, s + item);
                }
                else
                {
                    result.Add(s + item);
                }
            }
            return temp;
        }

        private static List<string> Method4(List<List<string>> data)
        {
            int count = 1;
            data.ForEach(p => count *= p.Count);

            var lstResult = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                var lstTemp = new List<string>();
                int j = 1;
                data.ForEach(p =>
                {
                    j *= p.Count;
                    lstTemp.Add(p[(i / (count / j)) % p.Count]);
                });
                lstResult.Add(string.Join("", lstTemp));
            }
            return lstResult;
        }



        private static List<List<T>> Common<T>(List<List<T>> lstSplit)
        {
            int count = 1;
            lstSplit.ForEach(item => count *= item.Count);
            //lstSplit.Aggregate(1, (total, next) => total *= next.Count);

            var lstResult = new List<List<T>>();

            for (int i = 0; i < count; ++i)
            {
                var lstTemp = new List<T>();
                int j = 1;
                lstSplit.ForEach(item =>
                {
                    j *= item.Count;
                    lstTemp.Add(item[(i / (count / j)) % item.Count]);
                });
                lstResult.Add(lstTemp);
            }
            return lstResult;
        }

        private static void Method4_1()
        {
            var lstSource = new List<List<string>>()
            {
                new List<string>() { "a" },
                new List<string>() { "c", "d" },
                new List<string>() { "e", "f", "g" },
                new List<string>() { "h", "i" },
                new List<string>() { "j" }
            };
            int count = 1;
            lstSource.ForEach(p => count *= p.Count);

            for (int i = 0; i < count; ++i)
            {
                int j = 1;
                lstSource.ForEach(l =>
                {
                    j *= l.Count;
                    Console.Write(l[(i / (count / j)) % l.Count]);
                });
                Console.WriteLine();
            }

        }

        private static List<string> Method5(List<List<string>> data)
        {
            return Common(data).SelectMany(p => p).ToList();
        }


        private static string look(List<List<string>> data, int level, string s)
        {
            var builder = new StringBuilder();
            foreach (var item in data[level])
            {
                if (level < data.Count - 1)
                {
                    builder.Append(look(data, level + 1, s + item));
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
