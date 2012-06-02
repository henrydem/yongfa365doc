using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Linq;

namespace AboutCache
{

    public class CacheSpeedTest
    {

        private static Cache Cache = HttpRuntime.Cache;

        public static List<DateTime> ByStatic = Fill();




        private static List<DateTime> _BySmallCache;
        public static List<DateTime> BySmallCache
        {
            get
            {
                if (Cache["SmallCache.Has"] == null)
                {
                    _BySmallCache = Fill();
                    Cache.Insert("SmallCache.Has", true, null, DateTime.UtcNow.AddHours(1), Cache.NoSlidingExpiration);
                }
                return _BySmallCache;
            }
        }


        public static List<DateTime> ByNormalCache
        {
            get
            {
                if (Cache["ByNormalCache"] == null)
                {
                    Cache.Insert("ByNormalCache", Fill(), null, DateTime.UtcNow.AddHours(1), Cache.NoSlidingExpiration);
                }
                return Cache["ByNormalCache"] as List<DateTime>;
            }
        }



        private static List<DateTime> Fill()
        {
            var lst = new List<DateTime>();
            for (int i = 0; i < 10000000; i++)
            {
                lst.Add(DateTime.Now.AddMilliseconds(i));
            }
            return lst;
        }

    }

}
