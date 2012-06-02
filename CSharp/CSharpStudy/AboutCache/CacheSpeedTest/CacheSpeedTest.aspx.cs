using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AboutCache
{
    public partial class CacheSpeedTest1 : System.Web.UI.Page
    {
        protected Dictionary<string, TimeSpan> dict = new Dictionary<string, TimeSpan>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Execute("ByStatic", () => { var a = CacheSpeedTest.ByStatic; });
            Execute("BySmallCache", () => { var a = CacheSpeedTest.BySmallCache; });
            Execute("ByNormalCache", () => { var a = CacheSpeedTest.ByNormalCache; });

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