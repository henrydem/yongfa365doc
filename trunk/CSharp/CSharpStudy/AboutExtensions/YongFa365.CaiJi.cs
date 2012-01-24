using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;

//TODO： System.Net.Cookie及System.Web.HttpCookie不一样，需要研究
namespace YongFa365.CaiJi
{
    public class HttpClient
    {
        public static string Get(string url)
        {
            return Get(url, Encoding.Default, null, UserAgent.IE7, url);
        }

        public static string Get(string url, string charset)
        {
            Encoding nowCharset;

            if (string.IsNullOrEmpty(charset))
            {
                nowCharset = Encoding.Default;
            }
            else
            {
                try
                {
                    nowCharset = Encoding.GetEncoding(charset);
                }
                catch (Exception)
                {
                    nowCharset = Encoding.Default;
                }
            }

            return Get(url, nowCharset, null, UserAgent.IE7, url);
        }

        public static string Get(string url, Encoding encoding, string cookies, UserAgent userAgent, string referer)
        {
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Get";
                request.Accept = "text/html";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = dictUserAgent[userAgent];
                request.Referer = referer;
                request.KeepAlive = true;
                request.Headers.Add("Cookie", cookies);

                response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
                //using (var stream = response.GetResponseStream())
                //{
                //    using (var reader = new StreamReader(stream, encoding))
                //    {
                //        return reader.ReadToEnd();
                //    }
                //}
            }
            catch
            {
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="cookies"></param>
        /// <param name="userAgent"></param>
        /// <param name="referer"></param>
        /// <param name="data">要提交的数据"username=yongfa365&password=12345" 如果有中文请先HttpUtility.UrlEncode下</param>
        public static string Post(string url, string data, Encoding encoding, string cookies, string referer = null, string userAgent = null)
        {
            try
            {
                var datas = encoding.GetBytes(data);

                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = userAgent;
                request.Referer = referer;
                request.KeepAlive = true;
                request.Headers.Add("Cookie", cookies);

                request.ContentLength = datas.Length;
                request.GetRequestStream().Write(datas, 0, datas.Length);

                //request.GetResponse();

                return new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream(), encoding).ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        //public CookieCollection GetCookieCollection(string url, string cookie)
        //{
        //    CookieCollection cookies = new CookieCollection();
        //    string cookiedomain = null;

        //    Match match = Regex.Match(url, @"https*://([^\/]+)");
        //    if (match.Success)
        //    {
        //        cookiedomain = match.Groups[1].Value;
        //    }
        //    else
        //    {
        //        return cookies;
        //    }


        //    string[] cookstr = cookie.Split(';');
        //    foreach (string str in cookstr)
        //    {
        //        if (str.IndexOf("=") > 1)
        //        {
        //            string[] cookieNameValue = str.Split('=');
        //            Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
        //            ck.Domain = cookiedomain;//必须写对 
        //            cookies.Add(ck);
        //        }
        //    }

        //    return cookies;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">登录地址</param>
        /// <param name="data">要提交的数据，可能会用到：HttpUtility.UrlEncode,str.Replace(" ","%20")</param>
        /// <param name="encoding">数据要进行什么编码，以及用什么编码返回</param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string Login(string url, string data, Encoding encoding, out string cookies, string referer = null, string userAgent = null)
        {
            HttpWebResponse response = null;
            try
            {
                var datas = encoding.GetBytes(data);

                var cookieContainer = new CookieContainer();

                var request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = userAgent;
                request.Referer = referer;
                request.KeepAlive = true;
                request.CookieContainer = cookieContainer;
                request.GetRequestStream().Write(datas, 0, datas.Length);

                response = (HttpWebResponse)request.GetResponse();

                cookies = cookieContainer.GetCookieHeader(request.RequestUri);

                return new StreamReader(response.GetResponseStream(), encoding).ReadToEnd();
            }
            catch
            {
                cookies = null;
                return null;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

        }

        /// <summary>
        /// 最智能的HTML获取方法，可以解决大多编码问题
        /// 柳永法 2008年7月4日 完成
        /// 2010-6-8，测试期，不可用于真实项目，效率及资源释放情况未解决
        /// </summary>
        /// <param name="url">要获取的网址</param>
        /// <returns></returns>
        public static string GetHTML(string url)
        {
            string html = "";
            string charset = "";
            Encoding encode;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)";
            request.Accept = "text/html";
            request.Referer = url;
            request.KeepAlive = true;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

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

            stream.Seek(0L, SeekOrigin.Begin);
            html = new StreamReader(stream, encode).ReadToEnd();

            return html;
        }

        static Dictionary<UserAgent, string> dictUserAgent = new Dictionary<UserAgent, string>();

        static HttpClient()
        {
            dictUserAgent.Add(UserAgent.IE7, "Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+5.1;+CIBA;+.NET+CLR+2.0.50727)");
            dictUserAgent.Add(UserAgent.Chrome, "Mozilla/5.0+(Windows;+U;+Windows+NT+5.1;+en-US)+AppleWebKit/532.0+(KHTML,+like+Gecko)+Chrome/3.0.195.27+Safari/532.0");
            dictUserAgent.Add(UserAgent.Sosospider, "Sosospider+(+http://help.soso.com/webspider.htm)");
            dictUserAgent.Add(UserAgent.Baiduspider, "Baiduspider+(+http://www.baidu.com/search/spider.htm)");
            dictUserAgent.Add(UserAgent.Googlebot, "Mozilla/5.0+(compatible;+Googlebot/2.1;++http://www.google.com/bot.html)");
            dictUserAgent.Add(UserAgent.Opera, "Opera/9.80+(Windows+NT+6.1;+U;+zh-cn)+Presto/2.2.15+Version/10.01");
            dictUserAgent.Add(UserAgent.Alexa, "Mozilla/4.0+(compatible;+MSIE+6.0;+Windows+NT+5.1;+SV1;+Alexa+Toolbar)");
        }
        public enum UserAgent
        {
            IE7,
            Chrome,
            Sosospider,
            Baiduspider,
            Googlebot,
            Opera,
            Alexa,
        }
        public enum HttpVerb
        {
            GET,
            POST,
            HEAD,
        }

    }


    #region 通过Uri取WebBrowser的完整Cookie,即包含HttpOnly的Cookie
    internal sealed class NativeMethods
    {
        #region enums

        public enum ErrorFlags
        {
            ERROR_INSUFFICIENT_BUFFER = 122,
            ERROR_INVALID_PARAMETER = 87,
            ERROR_NO_MORE_ITEMS = 259
        }

        public enum InternetFlags
        {
            INTERNET_COOKIE_HTTPONLY = 8192, //Requires IE 8 or higher
            INTERNET_COOKIE_THIRD_PARTY = 131072,
            INTERNET_FLAG_RESTRICTED_ZONE = 16
        }

        #endregion

        #region DLL Imports

        [SuppressUnmanagedCodeSecurity, SecurityCritical, DllImport("wininet.dll", EntryPoint = "InternetGetCookieExW", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        internal static extern bool InternetGetCookieEx([In] string Url, [In] string cookieName, [Out] StringBuilder cookieData, [In, Out] ref uint pchCookieData, uint flags, IntPtr reserved);

        #endregion
    }


    public class WebBrowserFullCookie
    {

        [SecurityCritical]
        public static string GetCookieInternal(Uri uri, bool throwIfNoCookie)
        {
            uint pchCookieData = 0;

            string url = UriToString(uri);

            uint flag = (uint)NativeMethods.InternetFlags.INTERNET_COOKIE_HTTPONLY;

            //Gets the size of the string builder
            if (NativeMethods.InternetGetCookieEx(url, null, null, ref pchCookieData, flag, IntPtr.Zero))
            {
                pchCookieData++;

                StringBuilder cookieData = new StringBuilder((int)pchCookieData);

                //Read the cookie
                if (NativeMethods.InternetGetCookieEx(url, null, cookieData, ref pchCookieData, flag, IntPtr.Zero))
                {
                    DemandWebPermission(uri);

                    return cookieData.ToString();
                }
            }

            int lastErrorCode = Marshal.GetLastWin32Error();

            if (throwIfNoCookie || (lastErrorCode != (int)NativeMethods.ErrorFlags.ERROR_NO_MORE_ITEMS))
            {
                throw new Win32Exception(lastErrorCode);
            }

            return null;
        }

        private static void DemandWebPermission(Uri uri)
        {
            string uriString = UriToString(uri);

            if (uri.IsFile)
            {
                string localPath = uri.LocalPath;

                new FileIOPermission(FileIOPermissionAccess.Read, localPath).Demand();
            }
            else
            {
                new WebPermission(NetworkAccess.Connect, uriString).Demand();
            }
        }

        private static string UriToString(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            UriComponents components = (uri.IsAbsoluteUri ? UriComponents.AbsoluteUri : UriComponents.SerializationInfoString);

            return new StringBuilder(uri.GetComponents(components, UriFormat.SafeUnescaped), 2083).ToString();
        }
    }


    #endregion
}