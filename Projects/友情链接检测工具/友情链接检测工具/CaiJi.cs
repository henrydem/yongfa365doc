//using System;
//using System.Text;
//using YongFa365.CaiJi;

//namespace 采集测试
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string[] urls = {
//                "http://www.yongfa365.com",
//                "http://www.cbdcn.com",
//                "http://www.csdn.net",
//                "http://www.sina.com",
//                "http://www.tom.com",
//            };

//            string html = "";

//            html = CaiJi.GetHtmlSource("http://www.yongfa365.com", "", "utf-8", "", "");
//            Console.Write(html);
//            Console.ReadKey();

//            html = CaiJi.GetHtmlSource("http://www.yongfa365.com", Encoding.Default);
//            Console.Write(html);
//            Console.ReadKey();

//            html = CaiJi.GetHtmlSource("http://www.baidu.com/");
//            Console.Write(html);
//            Console.ReadKey();

//            html = CaiJi.GetHtmlSource("http://www.tom.com", "utf-8");
//            Console.Write(html);
//            Console.ReadKey();

//            foreach (string url in urls)
//            {
//                Console.Write(CaiJi.GetHTML(url));
//                Console.ReadKey();
//            }

//        }
//    }
//}

//using YongFa365.CaiJi;
namespace YongFa365.CaiJi
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Net;


    /// <summary>
    /// 柳永法采集类
    /// </summary>
    public class CaiJi
    {
        /// <summary>
        /// 取得url 的 HttpWebResponse 供其它函数调用
        /// </summary>
        /// <param name="url">网页地址，eg:"http://www.yongfa365.com/" </param>
        /// <returns></returns>
        private static HttpWebResponse GetResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)";
            request.Accept = "text/html";
            request.Referer = url;
            request.KeepAlive = true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return (response);
        }



        /// <summary>
        /// 取得网页源码
        /// </summary>
        /// <param name="url">网页地址，eg: "http://www.yongfa365.com/" </param> 
        /// <param name="charset">网页编码，eg: Encoding.UTF8</param>
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url, Encoding charset)
        {
            //处理内容
            string html = "";
            try
            {
                HttpWebResponse response = GetResponse(url);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, charset);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return html;
        }

        /// <summary>
        /// 取得网页源码
        /// 对于带BOM的网页很有效，不管是什么编码都能正确识别
        /// </summary>
        /// <param name="url">网页地址，eg: "http://www.yongfa365.com/" </param> 
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url)
        {
            return GetHtmlSource(url, Encoding.Default);
        }


        /// <summary>
        /// 取得网页源码
        /// </summary>
        /// <param name="url">网页地址，eg:"http://www.yongfa365.com/" </param> 
        /// <param name="charset">网页编码，eg:"utf-8"</param>
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url, string charset)
        {
            //编码处理 
            Encoding nowCharset;
            try
            {
                if (charset == "" || charset == null)
                {
                    nowCharset = Encoding.Default;
                }
                else
                {
                    nowCharset = Encoding.GetEncoding(charset);
                }
            }
            catch (Exception)
            {

                nowCharset = Encoding.Default;
            }

            //处理内容
            return GetHtmlSource(url, nowCharset);
        }
    }
}