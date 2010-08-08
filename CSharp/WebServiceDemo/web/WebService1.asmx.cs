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
    [WebService(Namespace = "http://www.yongfa365.com/",Name="柳永法的WebServiceDemo", Description = "仅仅是测试一下，看他显示在哪里,我是<a href='http://www.yongfa365.com'>柳永法</a>")]
    // 默认是这个，但有重载时，会出错，所以改下
    // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(MessageName = "OnlyShow", Description = @"
如果只是string，那么一个方法会多出四个类似这样的类：<br />
HelloWorldRequest<br />
HelloWorldRequestBody<br />
HelloWorldResponse<br />
HelloWorldResponseBody<br />
如果有10个方法就会生成4*10个上面这样的情况，郁闷要死，<br />
加了这个用到DataTable的方法就不会出现这些类了，研究很久才试出来
")]
        public void OnlyShow(DataTable dt)
        {
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(MessageName = "HelloWorld2", Description = "如果有重载要使用MessageName改变名称")]
        public string HelloWorld(string str)
        {
            return "Hello World";
        }


        [WebMethod(Description = "一行语句，不使用中间变量交换两个int的值")]
        public void Swap(ref int a, ref int b)
        {
            b = a ^ b ^ (a = b);
        }

        [WebMethod]
        public List<string> GetList()
        {
            return Lib.DBMaker.GetList();
        }

        [WebMethod(Description = "DataTable是可以序列化的，加上TableName")]
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
