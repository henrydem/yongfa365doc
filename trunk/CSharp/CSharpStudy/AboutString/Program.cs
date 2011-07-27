using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
//from http://www.cnblogs.com/zhiyuanf/archive/2009/04/04/1429559.html
namespace AboutString
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = "abc".Equals("ABC");
            bool b = "abc".Equals("ABC", StringComparison.OrdinalIgnoreCase);
             //new StringCompare();
           TruncateTest.StartTest();
        }
    }

}
