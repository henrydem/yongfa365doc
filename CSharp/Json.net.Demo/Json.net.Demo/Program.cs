using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace Json.net.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 初始化
            var ht = new Hashtable();
            var dict = new Dictionary<Users, int>();
            var list = new List<Users>();

            for (int i = 0; i < 100; i++)
            {
                ht.Add("我是谁123@#！￥%&……\"……%*&" + i.ToString(), i);
                dict.Add(new Users() { Age = i, Birthday = DateTime.Now.AddHours(i), 姓名 = "柳 永法", Birthday2 = null }, i);
                list.Add(new Users() { Age = i, Birthday = DateTime.Now.AddHours(i), 姓名 = "柳 永法", Birthday2 = null });
            } 
            #endregion



            #region Hashtable
            {
                string cc = JsonConvert.SerializeObject(ht);
                Hashtable tc = JsonConvert.DeserializeObject(cc, typeof(Hashtable)) as Hashtable;
            }
            #endregion

            #region Hashtable Dictionary
            {
                string cc = JsonConvert.SerializeObject(ht);
                Hashtable tc = JsonConvert.DeserializeObject(cc, typeof(Hashtable)) as Hashtable;
                Dictionary<string, int> dict2 = JsonConvert.DeserializeObject(cc, typeof(Dictionary<string, int>)) as Dictionary<string, int>;
            } 
            #endregion

            #region List<Users>
            {
                string cc = JsonConvert.SerializeObject(list);
                var dict2 = JsonConvert.DeserializeObject(cc, typeof(List<Users>)) as List<Users>;
            } 
            #endregion

            #region Anonymous
            {
                var o = new
                {
                    a = 1,
                    b = "Hello, World!",
                    c = new[] { 1, 2, 3 },
                    d = new Dictionary<string, int> { { "x", 1 }, { "y", 2 } }
                };

                var json = JsonConvert.SerializeObject(o);

                var anonymous = new { a = 0, b = String.Empty, c = new int[0], d = new Dictionary<string, int>() };
                var o2 = JsonConvert.DeserializeAnonymousType(json, anonymous);

                Console.WriteLine(o2.b);
                Console.WriteLine(o2.c[1]);

                var o3 = JsonConvert.DeserializeAnonymousType(json, new { c = new int[0], d = new Dictionary<string, int>() });

                Console.WriteLine(o3.d["y"]);

            } 
            #endregion

            #region JObject
            {
                var o = new
                {
                    a = 1,
                    b = "Hello, World!",
                    c = new[] { 1, 2, 3 },
                    d = new Dictionary<string, int> { { "x", 1 }, { "y", 2 } }
                };

                var json = JsonConvert.SerializeObject(o);

                var o2 = JsonConvert.DeserializeObject(json) as JObject;

                Console.WriteLine((int)o2["a"]);
                Console.WriteLine((string)o2["b"]);
                Console.WriteLine(o2["c"].Values().Count());
                Console.WriteLine((int)o2["d"]["y"]);
            } 
            #endregion

            //TODO:目前有问题
            #region 自定义class在Dictionary  
            {
                string cc = JsonConvert.SerializeObject(dict);
                var dict2 = JsonConvert.DeserializeObject(cc, typeof(Dictionary<Users, int>)) as Dictionary<Users, int>;
            } 
            #endregion


        }
    }


    class Users
    {

        public int Age { get; set; }

        public string 姓名 { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime? Birthday2 { get; set; }

    }
}
