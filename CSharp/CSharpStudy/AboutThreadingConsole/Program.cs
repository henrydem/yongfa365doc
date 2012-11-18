using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutThreadingConsole
{
    class Program
    {
        //http://www.cnblogs.com/huangxincheng/category/368987.html
        static void Main()
        {
            //AboutNet4.Run();
           // AboutThread.RunSuccess();

            StockConcurrent cls = new StockConcurrent();
            cls.Run();
        }
    }
}
