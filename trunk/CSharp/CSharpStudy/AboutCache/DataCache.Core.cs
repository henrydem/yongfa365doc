using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Linq;
using System.ComponentModel;

namespace AboutCache
{

    public enum CacheKeys
    {
        [Description("正常Cache")]
        NormalCache,

        [Description("小Cache")]
        SmallCache,

        [Description("其它Cache")]
        OtherCache,
        OnlyTestCache
    }

    public class CacheInfo
    {
        public string Key { get; set; }
        public string Desc { get; set; }
        public int? Count { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public TimeSpan? BuildTime { get; set; }
        public bool HasValue
        {
            get
            {
                return CreateTime.HasValue || HttpRuntime.Cache[Key] != null;
            }
        }
    }


    public static partial class DataCache
    {
        /// <summary>
        /// 实时取缓存
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CacheInfo> GetCacheList()
        {
            var query = from item in AllKeyName
                        let cache = item.Key.GetValue<CacheInfo>() ?? new CacheInfo() { Key = item.Key.GetName(), Desc = item.Key.GetDescription() }
                        select cache;

            return query;
        }

        //第一次调用时便加载到静态变量里，以后不用再执行此操作，提速
        public static readonly Dictionary<CacheKeys, Tuple<string, string>> AllKeyName = FillAllKeyName();
        private static Dictionary<CacheKeys, Tuple<string, string>> FillAllKeyName()
        {
            var dict = new Dictionary<CacheKeys, Tuple<string, string>>();
            foreach (var item in Enum.GetValues(typeof(CacheKeys)))
            {
                var key = (CacheKeys)item;
                var keyName = Enum.GetName(typeof(CacheKeys), item);

                var obj = Attribute.GetCustomAttribute(typeof(CacheKeys).GetField(keyName), typeof(DescriptionAttribute)) as DescriptionAttribute;
                var desc = obj == null ? null : (obj as DescriptionAttribute).Description;

                dict.Add(key, new Tuple<string, string>("DataCache_" + keyName, desc));
            }
            return dict;
        }



        public static bool NoCache(this CacheKeys input)
        {
            return HttpRuntime.Cache[input.GetName()] == null;
        }



        public static string GetName(this CacheKeys input)
        {
            return AllKeyName[input].Item1;
        }

        public static string GetDescription(this CacheKeys input)
        {
            return AllKeyName[input].Item2;
        }

        public static T GetValue<T>(this CacheKeys input)
        {
            if (HttpRuntime.Cache[input.GetName()] is T)
            {
                return (T)HttpRuntime.Cache[input.GetName()];
            }
            else
            {
                return default(T);
            }

        }

        public static List<T> Get<T>(CacheKeys key, Action action, ref List<T> value, int expireSeconds)
        {
            if (key.NoCache())
            {
                var startTime = DateTime.Now;
                action();
                var cacheInfo = new CacheInfo
                {
                    Key = CacheKeys.SmallCache.GetName(),
                    Desc = CacheKeys.SmallCache.GetDescription(),
                    Count = value.Count,
                    CreateTime = DateTime.UtcNow,
                    ExpireTime = DateTime.UtcNow.AddSeconds(expireSeconds),
                    BuildTime = (DateTime.Now - startTime)
                };

                HttpRuntime.Cache.Insert(cacheInfo.Key, cacheInfo, null, cacheInfo.ExpireTime.Value, Cache.NoSlidingExpiration);
            }
            return value;
        }

        public static void Clear(string key = null, bool isClearAll = false)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                HttpRuntime.Cache.Remove(key);
            }
            if (isClearAll)
            {
                foreach (var item in AllKeyName)
                {
                    HttpRuntime.Cache.Remove(item.Value.Item1);
                }
            }

        }
    }

}
