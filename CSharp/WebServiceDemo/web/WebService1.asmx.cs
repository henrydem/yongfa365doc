using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Lib;

namespace web
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://www.yongfa365.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public void OnlyShow(DataTable dt)
        {
            //如果只是string，那么一个方法会多出四个类似这样的类：
            //HelloWorldRequest
            //HelloWorldRequestBody
            //HelloWorldResponse
            //HelloWorldResponseBody
            //如果有10个方法就会生成4*10个上面这样的情况，郁闷要死，
            //加了这个用到DataTable的方法就不会出现这些类了，研究很久才试出来
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
     

        [WebMethod]
        public void Swap(ref int a, ref int b)
        {
            b = a ^ b ^ (a = b);
        }

        [WebMethod]
        public List<string> GetList()
        {
            return Lib.DBMaker.GetList();
        }

        [WebMethod]
        public DataTable GetDataTable()
        {
            DataTable dt = Lib.DBMaker.GetDataTable();
            dt.TableName = "哈哈";
            return dt;
        }

        [WebMethod]
        public List<MyClass> GetListMyClass()
        {
            return Lib.DBMaker.GetListMyClass();
        }
    }
}
