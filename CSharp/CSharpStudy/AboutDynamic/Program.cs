using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace AboutDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic user = new ExpandoObject();
            user.UserName = "柳永法";
            user.Sex = "男";
            user.Birthday = DateTime.Now;
            user.Money = 123.456m;

            Console.WriteLine(user.UserName);

            dynamic user2 = new { UserName = "柳永法", Age = 28, Birthday = DateTime.Now };
            Console.WriteLine(user2.UserName);

            var user3 = new { UserName = "柳永法", Age = 28, Birthday = DateTime.Now };
            Console.WriteLine(user3.UserName);
        }
    }
}
