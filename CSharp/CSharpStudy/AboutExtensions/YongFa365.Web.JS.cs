using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace YongFa365.Web.JS
{

    /// <summary>
    /// 生成客户端的js,如alert();close();window.location
    /// </summary>
    public static class JS
    {
        public static void Alert(this Page page, string csName, string csText)
        {
            ClientScriptManager cs = page.ClientScript;
            Type cstype = page.GetType();

            if (!cs.IsClientScriptBlockRegistered(cstype, csName))
            {
                cs.RegisterStartupScript(cstype, csName, csText, true);
            }
        }
        public static void Alert(this Page page, string csText)
        {
            Alert(page, "csName", "alert('" + csText + "');");
        }


        public static void Alert(string msg)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>alert('" + msg + "');</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 提示并跳转到新网址
        /// </summary>
        /// <param name="msg">提示信息</param>
        /// <param name="url">目标网址</param>
        public static void AlertTo(string msg, string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>alert('" + msg + "');window.location='" + url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 直接跳转
        /// </summary>
        /// <param name="url">目标网址</param>
        public static void To(string url)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>window.location='" + url + "';</script>");
            System.Web.HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 提示并关闭
        /// </summary>
        /// <param name="msg">提示信息</param>
        public static void AlertClose(string msg)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>alert('" + msg + "');window.close()</script>");
            System.Web.HttpContext.Current.Response.End();
        }
        /// <summary>
        /// window.open
        /// </summary>
        /// <param name="url">网址</param>
        public static void NewOpen(string url)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>window.open('" + url + "','_blank','width=300,height=300');</script>");
        }

        /// <summary>
        /// window.open
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static void NewOpen(string url, int width, int height)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript' type='text/javascript'>window.open('" + url + "','_blank','width=" + width + ",height=" + height + "');</script>");
        }

        /// <summary>
        /// 返回onclick信息
        /// </summary>
        /// <param name="msg">要显示的信息</param>
        /// <returns></returns>
        public static string Confirm(string msg)
        {
            return "return confirm('" + msg + "')";
        }

        /// <summary>
        /// 返回onclick的删除信息
        /// </summary>
        /// <returns></returns>
        public static string Confirm()
        {
            return "return confirm('确定要删除吗?')";
        }

        /// <summary>
        /// 返回onclick的关闭
        /// </summary>
        /// <returns></returns>
        public static string Close()
        {
            return "return window.close()";
        }

        /// <summary>
        /// 返回onclick的打印
        /// </summary>
        /// <returns></returns>
        public static string Print()
        {
            return "return window.print()";
        }


    }
}