using System;
using System.Collections.Generic;
using System.Linq;

namespace AboutCache
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            var a = DataCache.BySmallCache;
            var b = DataCache.ByNormalCache;
            var c = DataCache.ByOtherCache;
            GridView2.DataSource = DataCache.GetCacheList();
            GridView2.DataBind();




        }


    }
}