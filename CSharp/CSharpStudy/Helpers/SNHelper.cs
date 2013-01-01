using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Helpers
{
    public enum SNType
    {
        Default,
        Fare,
        FareList,
        Markup
    }


    /// <summary>
    /// ID计划使用有序long,首先想到的是DateTime.Now.Ticks。
    /// 但短时间内产生大量数肯定不能直接调他，所以需要改造下。
    /// 1秒内有1000万个Tick,如:
    /// Console.WriteLine((DateTime.Now.Date.AddSeconds(1) - DateTime.Now.Date).Ticks);
    /// 此类便做的这事。1秒内至少可以产生100万个不重复数。
    /// </summary>
    public class SNHelper
    {
        class SNLockValue
        {
            public object ObjLock { get; set; }
            public long Ticks { get; set; }
        }

        static Dictionary<SNType, SNLockValue> dict = new Dictionary<SNType, SNLockValue>();

        static SNHelper()
        {
            foreach (SNType item in Enum.GetValues(typeof(SNType)))
            {
                dict.Add(item, new SNLockValue { ObjLock = new object(), Ticks = DateTime.Now.Ticks });
            }
        }

        public static long GetNextTick(SNType type = SNType.Default)
        {
            lock (dict[type].ObjLock)
            {
                while (true)
                {
                    if (dict[type].Ticks + 1 < DateTime.Now.Ticks)
                    {
                        return ++dict[type].Ticks;
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }

}
