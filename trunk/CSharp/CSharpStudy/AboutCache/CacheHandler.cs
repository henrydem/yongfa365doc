﻿using System;
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
                    Clear(context.Request["key"]);
                    break;
                case "ClearAll":
                    ClearAll();
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
                    string.Format("@{0}|{1}|{2}|{3}|{4}|{5}",
                    item.Key, item.CreateTime, item.ExpireTime, item.BuildTime, item.Count, item.HasCache)
                    );
            }
        }

        private void Clear(string key)
        {
            HttpRuntime.Cache[key] = null;
        }

        private void ClearAll()
        {
            DataCache.AllKey.ForEach(item =>
            {
                HttpRuntime.Cache[item] = null;
            });
        }
    }


}
