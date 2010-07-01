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
    class CaiJi
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
        /// <param name="url">网页地址，eg:"http://www.yongfa365.com/" </param> 
        /// <param name="charset">网页编码，eg:"utf-8"</param>
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url, string charset)
        {
            //编码处理 
            Encoding nowCharset;
            if (charset == "" || charset == null)
            {
                nowCharset = Encoding.Default;
            }
            else
            {
                nowCharset = Encoding.GetEncoding(charset);
            }

            //处理内容
            string html = "";
            try
            {
                HttpWebResponse response = GetResponse(url);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, nowCharset);
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
            //处理内容
            string html = "";
            try
            {
                HttpWebResponse response = GetResponse(url);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.Default);
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
        /// 最智能的HTML获取方法，可以解决大多编码问题
        /// 柳永法 2008年7月4日 完成
        /// </summary>
        /// <param name="url">要获取的网址</param>
        /// <returns></returns>
        public static string GetHTML(string url)
        {
            string html = "";
            string charset = "";
            Encoding encode;
            StreamReader reader;


            HttpWebResponse response = GetResponse(url);

            //把 网页流 放到 内存流 里,因为只有放到内存流里才能Seek，
            //如果直接用GetResponseStream就得取两次网页。
            MemoryStream stream = new MemoryStream();
            byte[] buffer = new byte[0x400];
            Stream responseStream = response.GetResponseStream();
            for (int i = responseStream.Read(buffer, 0, buffer.Length); i > 0; i = responseStream.Read(buffer, 0, buffer.Length))
            {
                stream.Write(buffer, 0, i);
            }
            responseStream.Close();

            //从 内存流 里用默认编码读出数据
            stream.Seek(0L, SeekOrigin.Begin);
            html = new StreamReader(stream, Encoding.Default).ReadToEnd();

            //分析网页编码，顺序是,网页-->head-->default
            //这里需要改进，try...catch效率很低，而在这还嵌套呢
            try
            {
                charset = Regex.Match(html, "charset=[\"']*([^\",']+)").Groups[1].Value;
                encode = Encoding.GetEncoding(charset);
            }
            catch
            {
                try
                {
                    string header = response.GetResponseHeader("Content-Type");
                    charset = Regex.Match(header, "charset=[\"']*([^\",']+)").Groups[1].Value;
                    encode = Encoding.GetEncoding(charset);
                }
                catch
                {
                    charset = "gb2312";
                    encode = Encoding.GetEncoding(charset);
                }
            }


            html = "";

            stream.Seek(0L, SeekOrigin.Begin);
            reader = new StreamReader(stream, encode);
            html = reader.ReadToEnd();

            return html;
        }


        /// <summary>
        /// 取得网页源码
        /// </summary>
        /// <param name="url">网页地址，eg:"http://www.yongfa365.com/" </param>
        /// <param name="referer">网页来源，可空</param>
        /// <param name="charset">网页编码，eg:"utf-8"，可空</param>
        /// <param name="cookiedomain">如：www.yongfa365.com，没有http://等 </param>
        /// <param name="cookie">cookie字符串，如：webBrowser1.Document.Cookie;</param>
        /// <returns>返回网页源文件</returns>
        public static string GetHtmlSource(string url, string referer, string charset, string cookiedomain, string cookie)
        {
            //编码处理 
            Encoding nowCharset;
            if (charset == "" || charset == null)
            {
                nowCharset = Encoding.Default;
            }
            else
            {
                nowCharset = Encoding.GetEncoding(charset);
            }

            //来源为空时，来源用url
            if (referer == "" || referer == null)
            {
                referer = url;
            }

            //cookiedomain如果为空就自动判断
            if (cookiedomain == "" || cookiedomain == null)
            {
                cookiedomain = Regex.Match(url, @"https*://([^\/]+)").Groups[1].Value;
            }

            //取 cookie，如果是大理操作，应该把cookie放到外边，让他生成一次就行了，而不是每次都要执行
            CookieContainer myCookieContainer = new CookieContainer();
            string[] cookstr = cookie.Split(';');
            foreach (string str in cookstr)
            {
                if (str.IndexOf("=") > 1)
                {
                    string[] cookieNameValue = str.Split('=');
                    Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                    ck.Domain = cookiedomain;//必须写对 
                    myCookieContainer.Add(ck);
                }
            }

            //处理内容
            string html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Get";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)";
                request.Accept = "text/html";
                request.Referer = referer;
                request.KeepAlive = true;
                request.CookieContainer = myCookieContainer;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, nowCharset);
                html = reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return html;
        }
    }
}