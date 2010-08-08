using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            ServiceReference1.WebService1SoapClient myClient = new ServiceReference1.WebService1SoapClient();
            string str = myClient.HelloWorld();
            Console.WriteLine(str);

            int a, b;
            a = 100;
            b = 200;
            Console.WriteLine("a:{0},b:{1}", a, b);
            myClient.Swap(ref a, ref b);
            Console.WriteLine("a:{0},b:{1}", a, b);
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("==============DataTable===================");
            DataTable dt = myClient.GetDataTable();
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item[1]);
            }
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("==============GetListMyClass===================");
            ServiceReference1.MyClass[]  list = myClient.GetListMyClass();
            foreach (var item in list)
            {
                Console.WriteLine(item.姓名);
            }
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("==============List===================");
            string[] list2 = myClient.GetList();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            /////////////////////////////////////////////////////////////////
            Console.WriteLine("==============深圳天气===================");
            WeatherWebService.WeatherWebServiceSoapClient weather = new WeatherWebService.WeatherWebServiceSoapClient("WeatherWebServiceSoap12");
            string[] 深圳天气 = weather.getWeatherbyCityName("深圳");

            foreach (var item in 深圳天气)
            {
                Console.WriteLine(item);
            }



        }
    }
}
