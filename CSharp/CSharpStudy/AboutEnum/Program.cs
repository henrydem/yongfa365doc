using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumNoFlags enumNoFlags001 = EnumNoFlags.Blank;
            EnumNoFlags enumNoFlagsUnion = EnumNoFlags.Blank | EnumNoFlags.Blue;
            EnumNoFlags enumNoFlags002 = enumNoFlags001 | enumNoFlagsUnion;
            EnumNoFlags enumNoFlags003 = enumNoFlags001 & enumNoFlagsUnion;


            EnumWithFlags enumWithFlags001 = EnumWithFlags.Blank;
            EnumWithFlags enumWithFlagsUnion = EnumWithFlags.Blank | EnumWithFlags.Blue;
            EnumWithFlags enumWithFlags002 = enumWithFlags001 | enumWithFlagsUnion;
            EnumWithFlags enumWithFlags003 = enumWithFlags001 & enumWithFlagsUnion;

            foreach (var item in Enum.GetNames(typeof(EnumNoFlags)))
            {
                Console.WriteLine(item);
            }
            foreach (int item in Enum.GetValues(typeof(EnumNoFlags)))
            {
                Console.WriteLine(item);
            }

            foreach (byte item in Enum.GetValues(typeof(EnumWithType)))
            {
                Console.WriteLine(item);
            }

            var a = enumNoFlags001.GetType().Name + "_" + Enum.GetName(typeof(EnumWithType), 1);

        }




        /// <summary>
        /// 没有Flags
        /// </summary>
        enum EnumNoFlags
        {
            Red = 1,
            Green = 2,
            Blank = 4,
            Blue = 8,
        }


        /// <summary>
        /// 有Flags
        /// </summary>
        [Flags]
        enum EnumWithFlags
        {
            Red = 1,
            Green = 2,
            Blank = 4,
            Blue = 8,
        }

        /// <summary>
        /// 设定类型为byte,对应SQL数据库里的 tinyint
        /// </summary>
        enum EnumWithType : byte
        {
            Red = 1,
            Green = 2,
            Blank = 4,
            Blue = 8,
        }

    }
}
