using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace AboutIterators
{
    class Program
    {
        static void Main(string[] args)
        {
            DaysOfTheWeek ddd = new DaysOfTheWeek();
            foreach (var item in ddd)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();




            SampleCollection col = new SampleCollection();

            foreach (int i in col.BuildCollection())
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }


    }

    public class DaysOfTheWeek : IEnumerable
    {
        string[] days = { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < days.Length; i++)
            {
                yield return days[i];
            }
        }
    }

    // Declare the collection:
    public class SampleCollection
    {
        public int[] items = new int[5] { 5, 4, 7, 9, 3 };

        public IEnumerable BuildCollection()
        {
            for (int i = 0; i < items.Length; i++)
            {
                yield return items[i];
            }
        }
    }
}
