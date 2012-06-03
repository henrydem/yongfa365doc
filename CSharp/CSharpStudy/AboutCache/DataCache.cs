using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Linq;

namespace AboutCache
{

    public static partial class DataCache
    {

        public static List<DateTime> ByNormalCache
        {
            get
            {
                if (CacheKeys.NormalCache.NoCache())
                {
                    var data = Fill();
                    HttpRuntime.Cache.Insert(CacheKeys.NormalCache.GetName(), data, null, DateTime.UtcNow.AddHours(1), Cache.NoSlidingExpiration);
                    return data;
                }
                else
                {
                    return CacheKeys.NormalCache.GetValue<List<DateTime>>();
                }
            }
        }



        private static List<DateTime> _BySmallCache = null;
        public static List<DateTime> BySmallCache
        {
            get
            {
                return DataCache.Get<DateTime>(CacheKeys.SmallCache, () => { _BySmallCache = Fill(); }, ref _BySmallCache, 1);
            }
        }



        private static List<DateTime> _ByOtherCache = null;
        public static List<DateTime> ByOtherCache
        {
            get
            {
                if (CacheKeys.OtherCache.NoCache())
                {
                    var startTime = DateTime.Now;
                    _ByOtherCache = Fill();
                    var cacheInfo = new CacheInfo
                    {
                        Key = CacheKeys.OtherCache.GetName(),
                        Count = _ByOtherCache.Count,
                        CreateTime = DateTime.UtcNow,
                        ExpireTime = DateTime.UtcNow.AddSeconds(1),
                        BuildTime = (DateTime.Now - startTime)
                    };

                    HttpRuntime.Cache.Insert(cacheInfo.Key, cacheInfo, null, cacheInfo.ExpireTime.Value, Cache.NoSlidingExpiration);
                }
                return _ByOtherCache;
            }
        }



        private static List<DateTime> Fill()
        {
            var lst = new List<DateTime>();
            for (int i = 0; i < 1000000; i++)
            {
                lst.Add(DateTime.Now.AddMilliseconds(i));
            }
            return lst;
        }

    }
}
