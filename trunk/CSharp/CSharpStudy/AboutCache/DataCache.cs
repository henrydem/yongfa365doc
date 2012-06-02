using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Linq;

namespace AboutCache
{

    public class DataCache
    {
        #region All Cache

        //Cache里只放一个简单的内容
        private static List<DateTime> _BySmallCache = null;
        public static List<DateTime> BySmallCache
        {
            get
            {
                if (HttpRuntime.Cache[CacheKeys.Key_SmallCache] == null)
                {
                    var startTime = DateTime.Now;
                    _BySmallCache = Fill();
                    var cacheInfo = new CacheInfo
                    {
                        Key = CacheKeys.Key_SmallCache,
                        Count = _BySmallCache.Count,
                        CreateTime = DateTime.UtcNow,
                        ExpireTime = DateTime.UtcNow.AddHours(1),
                        BuildTime = (DateTime.Now - startTime)
                    };

                    HttpRuntime.Cache.Insert(cacheInfo.Key, cacheInfo, null, cacheInfo.ExpireTime.Value, Cache.NoSlidingExpiration);
                }
                return _BySmallCache;
            }
        }

        public static List<DateTime> ByNormalCache
        {
            get
            {

                if (HttpRuntime.Cache[CacheKeys.Key_NormalCache] == null)
                {
                    var data = Fill();
                    HttpRuntime.Cache.Insert(CacheKeys.Key_NormalCache, data, null, DateTime.UtcNow.AddHours(1), Cache.NoSlidingExpiration);
                    return data;
                }
                else
                {
                    return HttpRuntime.Cache[CacheKeys.Key_NormalCache] as List<DateTime>;
                }
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

        #endregion


        #region Cache Extend
        public static IEnumerable<CacheInfo> GetCacheList()
        {
            var query = from key in AllKey
                        let cache = (HttpRuntime.Cache[key] as CacheInfo) ?? new CacheInfo() { Key = key }
                        select cache;

            return query;

        }

        public static readonly List<string> AllKey = FillAllKey();
        private static List<string> FillAllKey()
        {
            var lst = new List<string>();
            var fields = typeof(CacheKeys).GetFields();
            foreach (var field in fields)
            {
                if (!field.IsInitOnly)
                {
                    lst.Add(field.GetValue(field.Name).ToString());
                }
            }
            return lst;
        }
        #endregion
    }




    public class CacheInfo
    {
        public string Key { get; set; }
        public int? Count { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public TimeSpan? BuildTime { get; set; }
        public bool HasCache { get { return CreateTime.HasValue || HttpRuntime.Cache[Key] != null; } }
    }


    public class CacheKeys
    {
        public const string Key_SmallCache = "SmallCache";
        public const string Key_NormalCache = "NormalCache";
    }
}
