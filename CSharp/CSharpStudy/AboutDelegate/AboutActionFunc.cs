using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AboutDelegate
{
    class AboutActionFunc
    {
        public static void Run()
        {
            Action<int, int> ActionCalc = (a, b) => { Console.WriteLine(a + b); };
            ActionCalc(1, 2);



            Func<int, int, int> FuncCalc = (a, b) => { return a + b; };
            Console.WriteLine(FuncCalc(1, 2));


            Func<Users, int, string, Users> FuncUsers = (u, age, username) =>
            {
                u.Age = age;
                u.UserName = username;
                return u;
            };

            var users = FuncUsers(new Users(), 28, "柳");

        }

    }

    class Users
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }

}
