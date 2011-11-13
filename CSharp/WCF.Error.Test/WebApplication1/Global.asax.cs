using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            var ex1 = ex as HttpException;
            if (ex1 != null && ex1.GetHttpCode() != 500)
            {
                return;
            }
            if (System.Diagnostics.Debugger.IsAttached)//调试时显示详情
            {
                var ex2 = ex.GetBaseException() as System.ServiceModel.FaultException<System.ServiceModel.ExceptionDetail>;
                if (ex2 != null)
                {
                    //Response.Write(ex2.Detail);
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("<p><h2>Time:</h2>{0}</p>", DateTime.Now.ToString());
                    sb.AppendFormat("<p><h2>Message:</h2>{0}</p>", ex.Message.Replace("\r\n", "<br />"));
                    sb.AppendFormat("<p><h2>StackTrace:</h2>{0}</p", ex.StackTrace.Replace("\r\n", "<br />"));
                    sb.AppendFormat("<p><h2>Detail:</h2>{0}</p", ex2.Detail.ToString().Replace("\r\n", "<br />"));
                    Response.Write(sb);
                    Server.ClearError();
                }
            }



        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}