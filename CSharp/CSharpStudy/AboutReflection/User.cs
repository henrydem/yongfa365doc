using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AboutReflection
{
    class User
    {
        public const bool IsPreson = true;
        public const string Remark = "备注";

        [Description("姓名")]
        public string UserName { get; set; }

        [Description("年龄")]
        public int Age { get; set; }

        public string Sex { get; set; }

        public string 普通方法(string userName, int age)
        {
            UserName = userName;
            Age = age;
            return string.Format("姓名：{0},年龄:{1}", UserName, age);
        }


        public static string 静态方法(string userName, int age)
        {
            return string.Format("static 姓名：{0},年龄:{1}", userName, age);
        }

        private bool Clear()
        {
            return true;
        }
    }
}
