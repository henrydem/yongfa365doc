using System;
using System.Collections.Generic;
using System.Text;

namespace AboutSort
{
    class AboutSort
    {
        public static void MaoPaoSort()
        {
            int[] arrInt = new Int32[] { 2, 4, 1, 8, 9, 3, 12, 34, 234, 234234, 12, 6 };
            for (int i = 0; i < arrInt.Length; i++)
            {
                for (int j = i + 1; j < arrInt.Length; j++)
                {
                    if (arrInt[i] > arrInt[j])
                    {
                        int intTemp = arrInt[i];
                        arrInt[i] = arrInt[j];
                        arrInt[j] = intTemp;
                    }
                }
            }

            foreach (int item in arrInt)
            {
                Console.Write("{0}-->", item);
            }

        }
        public static void BubbleSort()
        {
            int[] list = new Int32[] { 2, 4, 1, 8, 9, 3, 12, 34, 234, 234234, 12, 6 };
            bool a = false;
            int i, temp;
            for (int j = 0; j < list.Length; j++)
            {

                for (i = list.Length - 1; i > j; i--)
                {

                    if (list[j] < list[i])
                    {
                        temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                        a = true;
                    }
                }
                //if (a) { a = false; }
                //else { return list; }
            }
            //return list;
            foreach (int item in list)
            {
                Console.Write("{0}-->", item);
            }

        }

        public static void 字符排序()
        {
            //把sSDsBEaaaaaAAAAA排序成AAAAAaaaaaBDESss
            String s = "sSDsBEaaaaaAAAAA";
            char[] arrChar = s.ToCharArray();

            int[] arrInt = new Int32[arrChar.Length];
            for (int i = 0; i < arrChar.Length; i++)
            {
                int temp = (int)arrChar[i];
                if (arrChar[i] >= 'A' && arrChar[i] <= 'Z')
                {
                    temp *= 1000;
                }
                else
                {
                    temp = (temp - 32) * 1000 + temp;
                }
                arrInt[i] = temp;
            }
            Array.Sort(arrInt, arrChar);
            Console.WriteLine(new string(arrChar));
        
        }


    }
}
