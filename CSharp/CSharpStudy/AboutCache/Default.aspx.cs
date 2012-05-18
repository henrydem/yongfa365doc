using System;
using System.Collections.Generic;

namespace AboutCache
{
    public partial class Default : System.Web.UI.Page
    {
        protected Dictionary<string, TimeSpan> dict = new Dictionary<string, TimeSpan>();

        protected void Page_Load(object sender, EventArgs e)
        {

            Execute("ByStatic", () => { var a = DataCache.ByStatic; });
            Execute("BySmallCache", () => { var a = DataCache.BySmallCache; });
            Execute("ByCacheAs", () => { var a = DataCache.ByCacheAs; });

            GridView1.DataSource = dict;
            GridView1.DataBind();

        }
        private void Execute(string msg, Action act)
        {
            TimeSpan t = DateTime.Now.TimeOfDay;
            for (int i = 0; i < 1000000; i++)
            {
                act();
            }
            dict.Add(msg, DateTime.Now.TimeOfDay - t);
        }
    }
}