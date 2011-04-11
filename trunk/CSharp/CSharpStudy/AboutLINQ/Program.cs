using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutLINQ
{
    //TODO:研究 http://blog.csdn.net/dayu027/archive/2009/01/06/3719719.aspx
    //TODO:研究 http://www.cnblogs.com/idior/archive/2005/09/18/239342.html
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = { 1, 2, 3 };

            //普通方法
            string[] arrStr1 = Array.ConvertAll(arrInt, new Converter<int, string>(IntToString));


            //匿名方法
            string[] arrStr2 = Array.ConvertAll(arrInt, delegate(int a) { return a.ToString(); });


            //Lambda表达式
            string[] arrStr3 = Array.ConvertAll(arrInt, a => { return a.ToString(); });


            List<Users> lst = new List<Users>() 
            {
                new Users(){ Age=1, UserName="axdf"},
                new Users(){ Age=2, UserName="axdf"},
                new Users(){ Age=3, UserName="axdf"},
                new Users(){ Age=14, UserName="axdf"},
            };


            //Lambda表达式
            List<int> lst2 = lst.ConvertAll(a => { return a.Age; });

            //可以进行组合得到你要的结果
            List<string> lst3 = lst.ConvertAll(a => { return string.Format("我是:{0} 今年:{1}", a.UserName, a.Age); });

            var temp1 = string.Join(",", lst.Select(a => a.UserName + a.Age.ToString()));

            //Lambda表达式
            List<int> lst4 = lst.Select(a => a.Age).ToList();


            lst2.RemoveAll(a => { return lst.Exists(b => b.Age == a); });
        }

        public static string IntToString(int i)
        {
            return i.ToString();
        }
    }


    class Users
    {
        public string UserName { get; set; }

        public int Age { get; set; }
    }
}
