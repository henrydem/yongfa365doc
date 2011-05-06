using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;


namespace YongFa365.Web
{
    public static class Comm
    {
        #region DropDownList 扩展

        /// <summary>
        /// 选中DropDownList 值
        /// </summary>
        /// <param name="ddlst"></param>
        /// <param name="valuestr"></param>
        public static bool SelectedByValue(this DropDownList ddlst, string valuestr)
        {
            if (string.IsNullOrEmpty(valuestr))
            {
                return false;
            }
            int idx = ddlst.Items.IndexOf(ddlst.Items.FindByValue(valuestr));
            ddlst.SelectedIndex = idx;
            return idx != -1 ? true : false;
        }

        /// <summary>
        /// 填充数字
        /// </summary>
        /// <param name="ddlst"></param>
        /// <param name="startIndex">开始数字</param>
        /// <param name="endIndex">结束数字</param>
        /// <param name="defaultString">默认选中的数字字符</param>
        public static void Fill(this DropDownList ddlst, int startIndex, int endIndex, string defaultString)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                ddlst.Items.Add(i.ToString());
            }
            ddlst.SelectedByValue(defaultString);
        }

        public static void FillCityDemo(this DropDownList ddlst, string valuestr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("txtName", typeof(string)));
            dt.Columns.Add(new DataColumn("ParentId", typeof(int)));
            dt.Rows.Add(1, "北京", 0);
            dt.Rows.Add(2, "山西", 0);

            dt.Rows.Add(3, "朝阳区", 1);
            dt.Rows.Add(4, "海淀区", 1);

            dt.Rows.Add(5, "豆各庄", 3);
            dt.Rows.Add(6, "十里堡", 3);
            dt.Rows.Add(7, "中关村", 4);

            dt.Rows.Add(8, "运城地区", 2);
            dt.Rows.Add(9, "太原市", 2);
            dt.Rows.Add(10, "永济市", 8);
            dt.Rows.Add(11, "西文学", 10);
            dt.Rows.Add(12, "东文学", 10);
            dt.Rows.Add(13, "南文学", 10);

            ddlst.FillTree(dt, "Parentid=0", valuestr);
        }

        /// <summary>
        /// 填充并选中
        /// </summary>
        /// <param name="ddlst"></param>
        /// <param name="dt">前两列及顺序满足 value,text就可以，字段名不必与示例相同</param>
        /// <param name="selectedValue">选中的value</param>
        public static void Fill(this DropDownList ddlst, DataTable dt, string selectedValue)
        {
            ddlst.DataSource = dt;
            ddlst.DataTextField = dt.Columns[0].ColumnName;
            ddlst.DataValueField = dt.Columns[1].ColumnName;
            ddlst.DataBind();
            ddlst.SelectedByValue(selectedValue);

        }


        ///<summary>
        ///填充并选中树
        ///</summary>
        ///<param name="ddlst"></param>
        ///<param name="dt">前三列顺序要满足Id,Name,ParentId，字段名不必与示例相同</param>
        ///<param name="filterExpression">过滤表达式，如："ParentId=0"</param>
        ///<param name="selectedValue">选中的value</param>
        public static void FillTree(this DropDownList ddlst, DataTable dt, string filterExpression, string selectedValue)
        {
            ArrayList allItems = new ArrayList();
            DataRow[] rows = dt.Select(filterExpression);
            foreach (DataRow row in rows)
            {
                SubTree(dt, ref   allItems, row, string.Empty);
            }

            ListItem[] items = new ListItem[allItems.Count];
            allItems.CopyTo(items);
            ddlst.Items.Clear();
            ddlst.Items.AddRange(items);

            ddlst.SelectedByValue(selectedValue);
        }

        private static void SubTree(DataTable dt, ref   ArrayList items, DataRow parentRow, string curHeader)
        {
            ListItem newItem = new ListItem(curHeader + parentRow[1].ToString(), parentRow[0].ToString());

            items.Add(newItem);
            parentRow.Delete();

            DataRow[] rows = dt.Select(string.Format("[{0}]='{1}'", dt.Columns[2].ColumnName, newItem.Value));
            for (int i = 0; i < rows.Length - 1; i++)
            {
                SubTree(dt, ref items, rows[i], curHeader + new string((char)160, 4));
            }

            if (rows.Length > 0)
            {
                SubTree(dt, ref items, rows[rows.Length - 1], curHeader + new string((char)160, 4));
            }
        }



        private static void SubTree2(DataTable dt, ref   ArrayList items, DataRow parentRow, string curHeader)
        {
            ListItem newItem = new ListItem(curHeader + parentRow[1].ToString(), parentRow[0].ToString());
            items.Add(newItem);
            parentRow.Delete();

            DataRow[] rows = dt.Select(string.Format("[{0}]='{1}'", dt.Columns[2].ColumnName, newItem.Value));
            for (int i = 0; i < rows.Length - 1; i++)
            {
                SubTree2(dt, ref items, rows[i], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┣");
            }

            if (rows.Length > 0)
            {
                SubTree2(dt, ref items, rows[rows.Length - 1], curHeader.Replace("┣", "┃").Replace("┗", "┣") + "┗");
            }
        }

        #endregion



        /// <summary>
        /// 获取GridView的主键值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static T GetKey<T>(this GridView gv, int rowIndex)
        {
            T key = (T)gv.DataKeys[rowIndex].Value;
            return key;
        }



        /// <summary>
        ///  查找指定类型的控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public static List<T> FindControls<T>(this Control control) where T : Control
        {
            Action<Control, List<T>> findhelper = null;
            findhelper = (ctl, list) =>
            {
                if (ctl is T)
                {
                    list.Add((T)ctl);
                }
                if (ctl.HasControls())
                {
                    foreach (Control c in ctl.Controls)
                    {
                        findhelper(c, list);
                    }
                }
            };
            List<T> controls = new List<T>();
            findhelper(control, controls);
            return controls;
        }



        public static bool SafeRequest(string str)
        {
            str = HttpContext.Current.Request[str];
            if (!string.IsNullOrEmpty(str))
            {
                string p = "'|Select|Update|Delete|insert|Count|(drop table)|truncate|Asc|Mid|char|xp_cmdshell|(exec master)|(net localgroup administrators)|And|(net user)|Or";
                MatchCollection matches = Regex.Matches(str, p, RegexOptions.IgnoreCase);
                if (matches.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }


        public static string GetComeIP()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            sb.Append(",");
            sb.Append(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return sb.ToString();
            //string userip1,userip2;
            //userip1 = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //userip2 = Request.ServerVariables["REMOTE_ADDR"];
            //if (string.IsNullOrEmpty(userip))
            //{
            //    userip = Request.ServerVariables["REMOTE_ADDR"];
            //}
            //if (string.IsNullOrEmpty(userip))
            //{
            //    return "";
            //}
            //else
            //{
            //    return userip;
            //}
        }


        public static string SafeTrim(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                return input.Trim();
            }
        }

        /// <summary>
        /// 取得网站的RootURL,结果有加"/"
        /// 如：https://www.yongfa365.com:1234/abc.aspx?a=1b=2
        /// 结果：https://www.yongfa365.com:1234/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetRootURL(this Uri input)
        {

            return input.AbsoluteUri.Replace(input.PathAndQuery, "/");
        }

        /// <summary>
        /// 取得网站根路径
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hasPathChar"></param>
        /// <returns></returns>
        public static string GetSiteRootURL(this HttpRequest input, bool hasPathChar = true)
        {
            return input.Url.AbsoluteUri.Replace(
                input.Url.PathAndQuery,
                hasPathChar ? "/" : ""
                );
        }

        /// <summary>
        /// 取得应用程序根url 如：https://www.yongfa365.com/ApplicationName/
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hasPathChar">是否在末尾带"/"</param>
        /// <returns></returns>
        public static string GetApplicationURL(this HttpRequest input, bool hasPathChar = true)
        {
            return input.Url.AbsoluteUri.Replace(
                input.Url.PathAndQuery,
                input.ApplicationPath + (hasPathChar ? "/" : "")
                );

        }




        /// <summary>
        /// 让页面不缓存, 一般用于 Page.OnPreRender 中, 注意,如果在设置这个后,做了 Response.Redirect , 设置不起作用
        /// </summary>
        /// <param name="response"></param>
        public static void NoCache(this HttpResponse response)
        {
            if (null == response) throw new ArgumentNullException("response");
            response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            response.Cache.SetNoStore();
            response.Cache.SetCacheability(HttpCacheability.NoCache);
        }




        ///// <summary>
        ///// 消息類型
        ///// </summary>
        //public enum ShowMessageType
        //{
        //    /// <summary>
        //    /// 一般
        //    /// </summary>
        //    Info,
        //    /// <summary>
        //    /// 錯誤
        //    /// </summary>
        //    Error,
        //    /// <summary>
        //    /// 警告
        //    /// </summary>
        //    Warnning
        //}

        //public static class ShowMessage
        //{

        //    /// <summary>
        //    /// 顯示資訊頁面 Message.aspx， 並終止當前頁面
        //    /// </summary>
        //    /// <param name="msg"></param>
        //    /// <param name="title"></param>
        //    /// <param name="type"></param>
        //    /// <param name="redirect">返回頁面</param>
        //    public static void Message(this HttpResponse response, string msg, string title = "", ShowMessageType type = ShowMessageType.Info, string redirect = "")
        //    {
        //        response.Redirect(string.Format("~/Message.aspx?m={0}&tt={1}&t={2}&redirect={3}",
        //            HttpUtility.UrlEncode(msg),
        //            HttpUtility.UrlEncode(title),
        //            type,
        //            HttpUtility.UrlEncode(redirect)),
        //        true);
        //    }
        //}

    }
}