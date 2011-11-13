using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CtripSZ.Frameworks.Extends;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //情景1 一般页面错误
            //dynamic i = 0;
            //string.Format("You entered: {0}", 1 / i);


            //情景2 wcf调用出错
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            client.Using(() =>
            {
                var result = client.GetData(11111);
            });


            //WCFHelper.Using<ServiceReference1.Service1Client>((item) => {
            //   var re= item.GetData(1);
            //});

        }
    }
}