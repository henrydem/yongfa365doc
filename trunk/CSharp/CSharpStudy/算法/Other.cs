using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 算法
{
    class Other
    {
        public static void Tree(string dir)
        {
            foreach (string item in Directory.GetFiles(dir))
            {
                Console.WriteLine(item);
            }
            foreach (string item in Directory.GetDirectories(dir))
            {
                Tree(item);
            }
        }
    }
}
