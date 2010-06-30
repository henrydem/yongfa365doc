using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = ClassLibrary1.DBMaker.人员表();
        ExcelHelper.ExportByWeb(dt, "人员信息", DateTime.Now.ToString("yyyy-MM-dd") + "人员信息.xls");


    }
}
