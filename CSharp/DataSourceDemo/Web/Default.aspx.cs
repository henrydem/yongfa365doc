using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib;
//GridView1.DataSource 支持很广泛
//IList,IListSource,IBuildList,IBuildListView,IEnumerable
namespace Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataSource = DBMaker.GetStrings();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetList();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetIEnumerable();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetListMyClass();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetDictionary();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetDataTable();
            //GridView1.DataBind();

            //GridView1.DataSource = DBMaker.GetDataTable().DefaultView;
            //GridView1.DataBind();
        }
    }
}