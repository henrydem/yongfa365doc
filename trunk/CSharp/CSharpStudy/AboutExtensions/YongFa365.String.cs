using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace YongFa365.String
{
    /// <summary>
    /// 从字符串里按格式取出相关内容
    /// </summary>
    public static class 字符串处理
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

        /// <summary>
        /// 按字节截取字符串，双字节取一半时用"."替换
        /// 光速截取，速度惊人
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length">字节数</param>
        /// <returns></returns>
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
                return input.Substring(0, length) + ".";
            }
            else
            {
                return input.Substring(0, length);
            }
        }

        /// <summary>
        /// 从右向左取length个字符
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string input, int length)
        {
            if (string.IsNullOrEmpty(input) || input.Length < length)
            {
                return input;
            }
            else
            {
                return input.Substring(input.Length - length);
            }
        }

        /// <summary>
        /// 从左向右取length个字符
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string input, int length)
        {
            if (string.IsNullOrEmpty(input) || input.Length < length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length);
            }
        }

        /// <summary>
        /// 调用正则表达式替换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换成什么，可使用后向引用等，如$1</param>
        /// <returns></returns>
        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }


        /// <summary>
        /// 删除所有html标记
        /// <>及里边的内容
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DelHTML(this string input)
        {
            return Regex.Replace(input, @"<[\s\S]+?>", "", RegexOptions.Compiled);
        }

        /// <summary>
        /// 删除成对的html及不可见数据，
        /// 如：style,script,frameset里的内容
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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


        public static string DateTimeString
        {
            get
            {
                return System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
            }
        }



    }


    /// <summary>
    /// String转成别的类型
    /// </summary>
    public static class 字符串转换及判断相关
    {

        #region String转换为Int

        /// <summary>
        /// 转为Int如果不成功则返回-110意思是“报警”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt(this string input)
        {
            return input.ToInt(-110);
        }

        public static int ToInt(this string input, int defaultValue)
        {
            int temp;
            return int.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static int? ToIntOrNull(this string input)
        {
            int temp;
            return int.TryParse(input, out temp) ? temp : default(int?);
        }

        #endregion


        #region String转换为Decimal

        /// <summary>
        /// 转为Decimal如果不成功则返回-110意思是“报警”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Decimal ToDecimal(this string input)
        {
            return input.ToDecimal(-110);
        }

        public static Decimal ToDecimal(this string input, Decimal defaultValue)
        {
            Decimal temp;
            return Decimal.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static Decimal? ToDecimalOrNull(this string input)
        {
            Decimal temp;
            return Decimal.TryParse(input, out temp) ? temp : default(Decimal?);
        }

        #endregion


        #region String转换为long

        /// <summary>
        /// 转为long如果不成功则返回-110意思是“报警”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static long Tolong(this string input)
        {
            return input.Tolong(-110);
        }

        public static long Tolong(this string input, long defaultValue)
        {
            long temp;
            return long.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static long? TolongOrNull(this string input)
        {
            long temp;
            return long.TryParse(input, out temp) ? temp : default(long?);
        }

        #endregion


        #region String转换为float

        /// <summary>
        /// 转为float如果不成功则返回-110意思是“报警”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static float Tofloat(this string input)
        {
            return input.Tofloat(-110);
        }

        public static float Tofloat(this string input, float defaultValue)
        {
            float temp;
            return float.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static float? TofloatOrNull(this string input)
        {
            float temp;
            return float.TryParse(input, out temp) ? temp : default(float?);
        }

        #endregion


        #region String转换为Double

        /// <summary>
        /// 转为Double如果不成功则返回-110意思是“报警”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Double ToDouble(this string input)
        {
            return input.ToDouble(-110);
        }

        public static Double ToDouble(this string input, Double defaultValue)
        {
            Double temp;
            return Double.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static Double? ToDoubleOrNull(this string input)
        {
            Double temp;
            return Double.TryParse(input, out temp) ? temp : default(Double?);
        }

        #endregion


        #region String转换为Byte

        /// <summary>
        /// 不成功时会返回一个Byte的最大值255
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Byte ToByte(this string input)
        {
            return input.ToByte(255);
        }

        public static Byte ToByte(this string input, Byte defaultValue)
        {
            Byte temp;
            return Byte.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static Byte? ToByteOrNull(this string input)
        {
            Byte temp;
            return Byte.TryParse(input, out temp) ? temp : default(Byte?);
        }
        #endregion


        #region String转换为DateTime


        public static DateTime ToDateTime(this string input)
        {
            return input.ToDateTime(new DateTime(1900, 1, 1));
        }

        public static DateTime ToDateTime(this string input, DateTime defaultValue)
        {
            DateTime temp;
            return DateTime.TryParse(input, out temp) ? temp : defaultValue;
        }

        public static DateTime? ToDateTimeOrNull(this string input)
        {
            DateTime temp;
            return DateTime.TryParse(input, out temp) ? temp : default(DateTime?);
        }

        #endregion


        #region OtherTransform

        /// <summary>
        /// 用指定连接符连接字符串列表所有元素
        /// </summary>
        /// <param name="input">字符串列表</param>
        /// <param name="separator">连接符</param>
        /// <returns></returns>
        public static string ToString(this List<string> input, string separator)
        {
            if (input == null)
            {
                return string.Empty;
            }
            return string.Join(separator, input);
        }

        /// <summary>
        /// 转成一般常用格式 yyyy-MM-dd
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToStringNormal(this DateTime input)
        {
            return input.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 16位，低8位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string To16bitMD5(this string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(input)), 4, 8);
            return result.Replace("-", "");
        }

        /// <summary>
        /// 32位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string To32bitMD5(this string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string result = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(input)));
            return result.Replace("-", "");
        }


        public static string ToSHA1(this string input)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            string result = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(input)));
            return result.Replace("-", "");
        }


        /// <summary>
        /// 转为了Guid,失败时转为Guid.Empty
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string input)
        {
            Guid temp;
            return Guid.TryParse(input, out temp) ? temp : Guid.Empty;
        }

        /// <summary>
        /// 转成合法文件名，替换非法文件名字符为空
        /// TODO:此算法效率不高，每次都产生新的字符串，但目前够用。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSafeFileName(this string input)
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

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToCamel(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? "" : input[0].ToString().ToLower() + input.Substring(1);
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToPascal(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? "" : input[0].ToString().ToUpper() + input.Substring(1);
        }


        /// <summary>
        /// 没值时返回null，有值时正常返回
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToNull(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? null : input;
        }

        /// <summary>
        /// 没值时返回string.Empty，有值时正常返回
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToEmpty(this string input)
        {
            return string.IsNullOrWhiteSpace(input) ? string.Empty : input;
        }



        public static T To<T>(this string input, T defaultValue = default(T)) where T : struct
        {
            if (input.IsNullOrWhiteSpace())
            {
                return defaultValue;
            }
            var temp = Convert.ChangeType(input, typeof(T));
            return temp is T ? (T)temp : defaultValue;
        }


        public static bool Is<T>(this string input) where T : struct
        {
            if (input.IsNullOrWhiteSpace())
            {
                return false;
            }
            var temp = Convert.ChangeType(input, typeof(T));
            return temp is T;
        }
        #endregion


        #region Is系列

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }


        public static bool IsInt(this string input)
        {
            int temp;
            return int.TryParse(input, out temp);
        }

        public static bool IsDecimal(this string input)
        {
            Decimal temp;
            return Decimal.TryParse(input, out temp);
        }


        public static bool IsDateTime(this string input)
        {
            DateTime temp;
            return DateTime.TryParse(input, out temp);
        }


        public static bool IsByte(this string input)
        {
            Byte temp;
            return Byte.TryParse(input, out temp);
        }

        /// <summary>
        /// 正则表达式判断，效率要求较高时甚用
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatch(this string input, string pattern)
        {
            return input == null ? false : Regex.IsMatch(input, pattern);
        }


        #endregion


        #region In Between系列
        //ScottGu In扩展
        //public static bool In(this object o, IEnumerable c)
        //{
        //    foreach (object i in c)
        //    {
        //        if (i.Equals(o)) return true;
        //    }
        //    return false;
        //}

        //ScottGu In扩展 改进
        public static bool In<T>(this T t, params T[] c)
        {
            return c.Any(i => i.Equals(t));
        }

        public static bool In<T>(this T t, IEnumerable<T> c)
        {
            return c.Any(i => i.Equals(t));
        }


        public static bool IsBetween<T>(this T input, T lowerBound, T upperBound, bool includeLowerBound = false, bool includeUpperBound = false) where T : IComparable<T>
        {
            if (null == input) throw new ArgumentNullException("input");

            var lowerCompareResult = input.CompareTo(lowerBound);
            var upperCompareResult = input.CompareTo(upperBound);

            return
                (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        public static bool IsBetween<T>(this T input, T lowerBound, T upperBound, IComparer<T> comparer, bool includeLowerBound = false, bool includeUpperBound = false)
        {
            if (null == input || null == comparer) throw new ArgumentNullException(null == input ? "input" : "comparer");

            var lowerCompareResult = comparer.Compare(input, lowerBound);
            var upperCompareResult = comparer.Compare(input, upperBound);

            return
                (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }


        #endregion


        #region IDictionary
        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static IDictionary<TKey, TValue> TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (!dict.ContainsKey(key)) dict.Add(key, value);
            return dict;
        }
        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

        /// <summary>
        /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary>
        /// 向字典中批量添加键值对
        /// </summary>
        /// <param name="replaceExisted">如果已存在，是否替换</param>
        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }
        #endregion

    }

    public static class ChineseStringUtility
    {
        //http://www.cnblogs.com/fmxyw/archive/2010/02/26/1674447.html
        internal const int LOCALE_SYSTEM_DEFAULT = 0x0800;
        internal const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        internal const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int LCMapString(int Locale, int dwMapFlags, string lpSrcStr, int cchSrc, [Out] string lpDestStr, int cchDest);

        /// <summary>
        /// 转为简体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSimplified(this string input)
        {
            string target = new string(' ', input.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_SIMPLIFIED_CHINESE, input, input.Length, target, input.Length);
            return target;
        }

        /// <summary>
        /// 转为繁体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToTraditional(this string input)
        {
            string target = new string(' ', input.Length);
            int ret = LCMapString(LOCALE_SYSTEM_DEFAULT, LCMAP_TRADITIONAL_CHINESE, input, input.Length, target, input.Length);
            return target;
        }
    }
}