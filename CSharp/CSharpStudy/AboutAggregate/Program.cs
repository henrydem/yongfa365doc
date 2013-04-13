using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutAggregate
{
    class Program
    {
        static void Main(string[] args)
        {

            var lst = new List<int> { 1, 2, 3 };
            //这里使用total说的过去
            var result1 = lst.Aggregate((total, next) => total + next);
            //以下两个使用total就说不过去了
            var result2 = lst.Aggregate(0, (total, next) => total + next);
            var result3 = lst.Aggregate(0, (total, next) => total + next, x => x % 2 == 0 ? "能被2整除" : "不能被2整除");

            var lstStr = new List<string> { "1", "11", "111" };
            //这里确实应该使用accumulate
            var result4 = lstStr.Aggregate(0, (accumulate, next) => accumulate + next.Length);
            var result5 = lstStr.Aggregate(0, (accumulate, next) => accumulate + next.Length, x => x % 2 == 0 ? "总长度能被2整除" : "总长度不能被2整除");

            //综上所述，accumulate及total最好都统一叫：result,或者(r,n)即：(result,next)

        }
    }
}
