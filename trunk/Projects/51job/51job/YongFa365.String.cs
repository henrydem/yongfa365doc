using System.Collections.Generic;
using System.Text;
using System;
using System.Text.RegularExpressions;

namespace YongFa365.String
{
    public static class GetString
    {
        public static string GetOne(this string input, string strBegin, string strEnd)
        {
            //@"(?<cnt>[\s\S]+?)"
            return GetOne(input, strBegin + @"([\s\S]+?)" + strEnd);
        }

        public static string GetOne(this string input, string pattern)
        {
            Match match = Regex.Match(input, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetList(this string input, string strBegin, string strEnd)
        {
            return GetList(input, strBegin + @"([\s\S]+?)" + strEnd);
        }

        public static List<string> GetList(this string input, string pattern)
        {
            List<string> list = new List<string>();
            MatchCollection matchs = Regex.Matches(input, pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                list.Add(match.Groups[1].Value);
            }
            return list;
        }

        public static List<string> GetImages(this string input)
        {
            return GetList(input, "<img.+?src=[\"']*([^\\s]+?)[\"']*(\\s|>)");
        }


        public static Dictionary<string, string> GetLinks(this string input)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string strLink = "";
            MatchCollection matchs = Regex.Matches(input, "<a[^<>]+href\\s*=\\s*[\"']*([^<>\"' ]+/*)[\"']*[^<>]*?>([\\s\\S]+?)</a>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                strLink = match.Groups[1].Value;
                while (strLink.EndsWith("/"))
                {
                    strLink.Substring(0, strLink.Length - 1);
                }
                if (!dict.ContainsKey(strLink))
                {
                    dict.Add(strLink, match.Groups[2].Value);
                }
            }
            return dict;
        }


        public static string Truncate(this string input, int length)
        {
            int len = input.Length;
            int i;

            for (i = 0; i < length && i < len; i++)
            {
                if ((int)input[i] > 0xFF)
                {
                    --length;
                }
            }

            if (length < i)
            {
                length = i;
            }
            else if (length > len)
            {
                length = len;
            }

            return input.Substring(0, length);
        }

        public static string GetRnd()
        {
            return System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public static string GetSafeFileName(this string input)
        {
            return input.Replace('/', '.')
                        .Replace(':', '.')
                        .Replace('*', '.')
                        .Replace('?', '.')
                        .Replace('"', '.')
                        .Replace('<', '.')
                        .Replace('>', '.')
                        .Replace('|', '.')
                        .Replace('\\', '.')
                        .Replace('\r', '.')
                        .Replace('\n', '.');
        }

        public static string Md5(this string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5").ToLower().Substring(8, 16);
        }

        public static string Md5All(this string input)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(input, "MD5");
        }

        public static string DelHTML(this string input)
        {
            return Regex.Replace(input, @"<[\s\S]+?>", "", RegexOptions.Compiled);
        }

        public static string DelHTML2(this string input)
        {
            input = Regex.Replace(input, @"<(style|script|object|frameset)[\s\S]+?</\1>", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            input = Regex.Replace(input, "<.+?>", "", RegexOptions.Compiled);
            return input;
        }

        #region 日文处理，在ACCESS里查询时，如果有日文就会出错
        /// <summary>
        /// 日文替换成HTML编码
        /// 问题：执行时间长，效率低
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns></returns>
        public static string Japanese2HtmlCode(this string input)
        {
            string[] japanese = new string[] { "ガ", "ギ", "グ", "ア", "ゲ", "ゴ", "ザ", "ジ", "ズ", "ゼ", "ゾ", "ダ", "ヂ", "ヅ", "デ", "ド", "バ", "パ", "ビ", "ピ", "ブ", "プ", "ベ", "ペ", "ボ", "ポ", "ヴ" };
            string[] htmlcode = new string[] { "460", "462", "463", "450", "466", "468", "470", "472", "474", "476", "478", "480", "482", "485", "487", "489", "496", "497", "499", "500", "502", "503", "505", "506", "508", "509", "532" };
            for (int i = 0; i < japanese.Length; i++)
            {
                input = input.Replace(japanese[i], "&#12" + htmlcode[i]);
            }
            return input;
        }

        /// <summary>
        /// 删除所有日文
        /// 问题：执行时间长，效率低
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns></returns>
        public static string JapaneseDelete(this string input)
        {
            return Regex.Replace(input, "[\u3040-\u309F\u30A0-\u30FF]", "", RegexOptions.Compiled);
        }
        #endregion

        #region 全角半角转换
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToSBC(this string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }


        /// <summary> 转半角的函数(DBC case) </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion

        #region 把字符串复制N次
        /// <summary>
        /// 把字符串复制N次
        /// </summary>
        /// <param name="count">复制次数</param>
        /// <param name="input">要复制的字符串</param>
        /// <returns></returns>
        public static string CopyMore(this string input, int count)
        {
            StringBuilder sb = new StringBuilder(count);
            for (int i = 0; i < count; i++)
            {
                sb.Append(input);
            }
            return sb.ToString();
        }

        #endregion


    }

}