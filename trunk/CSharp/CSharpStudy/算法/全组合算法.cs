using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 算法
{
    //ref http://bbs.csdn.net/topics/300069382?page=2
    class 全组合算法
    {
        [Flags]
        public enum PersonType
        {
            Audit = 1,
            Child = 2,
            Senior = 4
        }

        public static void Run(string[] args)
        {
            var lstSource = GetEnumList<PersonType>();
            var lstComb = FullCombination(lstSource);
            var lstResult = new List<PersonType>();
            lstComb.ForEach(item => lstResult.Add(item.Aggregate((result, source) => result | source)));
        }

        private static List<T> GetEnumList<T>()
        {
            var lst = new List<T>();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                lst.Add(item);
            }
            return lst;
        }

        private static List<List<T>> FullCombination<T>(List<T> lstSource)
        {
            var n = lstSource.Count;
            var max = 1 << n;
            var lstResult = new List<List<T>>();
            for (var i = 0; i < max; i++)
            {
                var lstTemp = new List<T>();
                for (var j = 0; j < n; j++)
                {
                    if ((i >> j & 1) > 0)
                    {
                        lstTemp.Add(lstSource[j]);
                    }
                }
                lstResult.Add(lstTemp);
            }
            lstResult.RemoveAt(0);
            return lstResult;
        }

    }
}
