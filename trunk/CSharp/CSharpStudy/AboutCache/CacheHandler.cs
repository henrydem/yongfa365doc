using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;
using System.Linq;

namespace AboutCache
{

    public class CacheHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var type = context.Request["type"] ?? "";
            switch (type)
            {
                case "Clear":
                    DataCache.Clear(context.Request["key"]);
                    break;
                case "ClearAll":
                    DataCache.Clear(null, true);
                    break;
                case "GetList":
                    GetList(context);
                    break;
                default:
                    break;
            }

        }

        private void GetList(HttpContext context)
        {
            context.Response.AddHeader("", "");
            foreach (var item in DataCache.GetCacheList())
            {
                context.Response.Write(
                    string.Format("@{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                    item.Key, item.Desc, item.Count, item.CreateTime, item.ExpireTime, item.BuildTime, item.HasValue)
                    );
            }
        }


    }


}
