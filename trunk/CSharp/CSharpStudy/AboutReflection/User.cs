using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutReflection
{
    class User
    {
        public const bool IsPreson = true;
        public const string Remark = "备注";

        public string 姓名 { get; set; }
        public int 年龄 { get; set; }
        public string 性别 { get; set; }

        public string 普通方法(string XingMing, int Age)
        {
            姓名 = XingMing;
            年龄 = Age;
            return string.Format("姓名：{0},年龄:{1}", 姓名, 年龄);
        }


        public static string 静态方法(string XingMing, int Age)
        {
            return string.Format("static 姓名：{0},年龄:{1}", XingMing, Age);
        }

        private bool Clear()
        {
            return true;
        }
    }
}
