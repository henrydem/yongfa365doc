using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
//from:http://www.cnblogs.com/zhiyuanf/archive/2009/04/06/1430127.html

namespace 算法
{
    class StringReverse
    {
        //ReverseStack    : 2134.1005ms
        //ReverseStack2   : 632.2616ms
        //ReverseNormal   : 841.3605ms
        //ReverseNormal2  : 903.2365ms
        //ReverseNet      : 238.6772ms

        //static void Main()
        //{
        //    char[] sArr = new char[10000];//我的测试算法中用到的

        //    List<byte> list = new List<byte>(10000);//List测试中用到的
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            sArr[i] = 'A';
        //        }
        //        else
        //        {
        //            sArr[i] = 'B';
        //        }
        //    }
        //    string s = new string(sArr);
        //    int count = 10000;
        //    //s = "1234567890abcdefghijhlmnopqrstuvwxyz http://www.yongfa365.com/ 我是柳永法";
        //    ReverseTest(s, count, ReverseStack);
        //    ReverseTest(s, count, ReverseStack2);
        //    ReverseTest(s, count, ReverseNormal);
        //    ReverseTest(s, count, ReverseNormal2);
        //    ReverseTest(s, count, ReverseNet);

        //}

        delegate string DelegateReverse(string input);
        static void ReverseTest(string input, int count, DelegateReverse method)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            string str = "";
            for (int i = 0; i < count; i++)
            {
                str = method(input);
            }
            sp.Stop();
            Console.WriteLine("{0}\t: {1}ms", method.Method.Name, sp.Elapsed.TotalMilliseconds);
            //Console.WriteLine(str);
        }


        public static string ReverseStack(string input)
        {
            char[] charArray = input.ToCharArray();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < charArray.Length; i++)
            {
                stack.Push(charArray[i]);
            }

            return new string(stack.ToArray());
        }

        public static string ReverseStack2(string input)
        {
            char[] charArray = input.ToCharArray();
            Stack<char> stack = new Stack<char>(charArray);
            return new string(stack.ToArray());
        }

        public static string ReverseNormal(string input)
        {
            char[] charArray = input.ToCharArray();

            int num = 0;
            int num2 = charArray.Length - 1;

            while (num < num2)
            {
                char temp = charArray[num];
                charArray[num] = charArray[num2];
                charArray[num2] = temp;
                num++;
                num2--;
            }

            return new string(charArray);
        }

        public static string ReverseNormal2(string input)
        {
            char[] charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length / 2; i++)
            {
                char temp = charArray[i];
                charArray[i] = charArray[charArray.Length - i - 1];
                charArray[charArray.Length - i - 1] = temp;
            }
            return new string(charArray);
        }


        public static string ReverseNet(string input)
        {
            char[] temp = input.ToCharArray();
            Array.Reverse(temp);
            return new string(temp);
        }
    }
}
