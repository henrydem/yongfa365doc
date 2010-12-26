using System;
using System.Text.RegularExpressions;
namespace YongFa365.Validator
{
    /// <summary>
    /// RegExp Soruce:   http://regexlib.com/DisplayPatterns.aspx
    /// Author:柳永法 yongfa365 http://www.yongfa365.com/ yongfa365@qq.com
    /// Intro:验证 网址，IP，邮箱，电话，手机，数字，英文，日期，身份证，邮编，
    /// 原则上是中国通用，因为各种场合不一样所以有特殊情况肯定要自己再手写，这里只能是提供一些通用的验证，追求太完美是不现实的。
    /// Version: 1.5
    /// PutTime: 2008-6-5
    /// LastModi:2010年12月26日16:42:45
    /// </summary>
    /// 
    public static class Validator
    {

        #region 验证邮箱
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmail(this string input)
        {
            return Regex.IsMatch(input, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", RegexOptions.IgnoreCase);
        }
        public static bool HasEmail(this string input)
        {
            return Regex.IsMatch(input, @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 验证网址
        /// <summary>
        /// 验证网址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsUrl(this string input)
        {
            return Regex.IsMatch(input, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        }
        public static bool HasUrl(this string input)
        {
            return Regex.IsMatch(input, @"(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?", RegexOptions.IgnoreCase);
        }
        #endregion



        #region 验证手机号
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobile(this string input)
        {
            return Regex.IsMatch(input, @"^1[35]\d{9}$", RegexOptions.IgnoreCase);
        }
        public static bool HasMobile(this string input)
        {
            return Regex.IsMatch(input, @"1[35]\d{9}", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 验证IP
        /// <summary>
        /// 验证IP
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIP(this string input)
        {
            return Regex.IsMatch(input, @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$", RegexOptions.IgnoreCase);
        }
        public static bool HasIP(this string input)
        {
            return Regex.IsMatch(input, @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 验证身份证是否有效
        /// <summary>
        /// 验证身份证是否有效
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIDCard(this string input)
        {
            if (input.Length == 18)
            {
                bool check = IsIDCard18(input);
                return check;
            }
            else if (input.Length == 15)
            {
                bool check = IsIDCard15(input);
                return check;
            }
            else
            {
                return false;
            }
        }

        public static bool IsIDCard18(this string input)
        {
            long n = 0;
            if (long.TryParse(input.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(input.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(input.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = input.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = input.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != input.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        public static bool IsIDCard15(this string input)
        {
            long n = 0;
            if (long.TryParse(input, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(input.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = input.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
        #endregion





        #region 是不是中国电话，格式010-85849685
        /// <summary>
        /// 是不是中国电话，格式010-85849685
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsTel(this string input)
        {
            return Regex.IsMatch(input, @"^\d{3,4}-?\d{6,8}$", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 邮政编码 6个数字
        /// <summary>
        /// 邮政编码 6个数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPostCode(this string input)
        {
            return Regex.IsMatch(input, @"^\d{6}$", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 中文
        /// <summary>
        /// 中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChinese(this string input)
        {
            return Regex.IsMatch(input, @"^[\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
        }
        public static bool hasChinese(this string input)
        {
            return Regex.IsMatch(input, @"[\u4e00-\u9fa5]+", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 验证是不是正常字符 字母，数字，下划线的组合
        /// <summary>
        /// 验证是不是正常字符 字母，数字，下划线的组合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNormalChar(this string input)
        {
            return Regex.IsMatch(input, @"[\w\d_]+", RegexOptions.IgnoreCase);
        }
        #endregion

    }
}