namespace GooglePageRank
{
    using System;
    using System.Text.RegularExpressions;
    using YongFa365.CaiJi;

    #region CheckSum
    internal class CheckSum
    {
        private uint GOOGLE_MAGIC = 0xe6359a60;

        private uint[] c32to8bit(uint[] arr32)
        {
            uint[] numArray = new uint[(arr32.GetLength(0) * 4) + 3];
            for (int i = 0; i < arr32.GetLength(0); i++)
            {
                for (int j = i * 4; j <= ((i * 4) + 3); j++)
                {
                    numArray[j] = arr32[i] & 0xff;
                    arr32[i] = this.zeroFill(arr32[i], 8);
                }
            }
            return numArray;
        }

        public string CalculateChecksum(string sURL)
        {
            uint num = this.GoogleCH("info:" + sURL);
            num = ((num / 7) << 2) | ((num % 13) & 7);
            uint[] numArray = new uint[20];
            numArray[0] = num;
            for (int i = 1; i < 20; i++)
            {
                numArray[i] = numArray[i - 1] - 9;
            }
            num = this.GoogleCH(this.c32to8bit(numArray), 80);
            return string.Format("6{0}", num);
        }

        public string CalculateChecksumOld(string sURL)
        {
            uint num = this.GoogleCH("info:" + sURL);
            return ("6" + Convert.ToString(num));
        }

        private uint GoogleCH(string sURL)
        {
            return this.GoogleCH(sURL, 0);
        }

        private uint GoogleCH(string url, uint length)
        {
            uint[] numArray = new uint[url.Length];
            for (int i = 0; i < url.Length; i++)
            {
                numArray[i] = url[i];
            }
            return this.GoogleCH(numArray, length, this.GOOGLE_MAGIC);
        }

        private uint GoogleCH(uint[] url, uint length)
        {
            return this.GoogleCH(url, length, this.GOOGLE_MAGIC);
        }

        private uint GoogleCH(uint[] url, uint length, uint init)
        {
            uint b;
            if (length == 0)
            {
                length = (uint)url.Length;
            }
            uint a = b = 0x9e3779b9;
            uint c = init;
            int index = 0;
            uint num5 = length;
            uint[] numArray = new uint[3];
            while (num5 >= 12)
            {
                a += ((url[index] + (url[index + 1] << 8)) + (url[index + 2] << 0x10)) + (url[index + 3] << 0x18);
                b += ((url[index + 4] + (url[index + 5] << 8)) + (url[index + 6] << 0x10)) + (url[index + 7] << 0x18);
                c += ((url[index + 8] + (url[index + 9] << 8)) + (url[index + 10] << 0x10)) + (url[index + 11] << 0x18);
                numArray = this.mix(a, b, c);
                a = numArray[0];
                b = numArray[1];
                c = numArray[2];
                index += 12;
                num5 -= 12;
            }
            c += length;
            switch (num5)
            {
                case 1:
                    a += url[index];
                    break;

                case 2:
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 3:
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 4:
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 5:
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 6:
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 7:
                    b += url[index + 6] << 0x10;
                    b += url[index + 5] << 8;
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 8:
                    b += url[index + 7] << 0x18;
                    b += url[index + 6] << 0x10;
                    b += url[index + 5] << 8;
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 9:
                    c += url[index + 8] << 8;
                    b += url[index + 7] << 0x18;
                    b += url[index + 6] << 0x10;
                    b += url[index + 5] << 8;
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 10:
                    c += url[index + 9] << 0x10;
                    c += url[index + 8] << 8;
                    b += url[index + 7] << 0x18;
                    b += url[index + 6] << 0x10;
                    b += url[index + 5] << 8;
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;

                case 11:
                    c += url[index + 10] << 0x18;
                    c += url[index + 9] << 0x10;
                    c += url[index + 8] << 8;
                    b += url[index + 7] << 0x18;
                    b += url[index + 6] << 0x10;
                    b += url[index + 5] << 8;
                    b += url[index + 4];
                    a += url[index + 3] << 0x18;
                    a += url[index + 2] << 0x10;
                    a += url[index + 1] << 8;
                    a += url[index];
                    break;
            }
            return this.mix(a, b, c)[2];
        }

        private uint[] mix(uint a, uint b, uint c)
        {
            a -= b;
            a -= c;
            a ^= this.zeroFill(c, 13);
            b -= c;
            b -= a;
            b ^= a << 8;
            c -= a;
            c -= b;
            c ^= this.zeroFill(b, 13);
            a -= b;
            a -= c;
            a ^= this.zeroFill(c, 12);
            b -= c;
            b -= a;
            b ^= a << 0x10;
            c -= a;
            c -= b;
            c ^= this.zeroFill(b, 5);
            a -= b;
            a -= c;
            a ^= this.zeroFill(c, 3);
            b -= c;
            b -= a;
            b ^= a << 10;
            c -= a;
            c -= b;
            c ^= this.zeroFill(b, 15);
            return new uint[] { a, b, c };
        }

        private uint zeroFill(uint a, int b)
        {
            uint num = 0x80000000;
            if (Convert.ToBoolean(num & a))
            {
                a = a >> 1;
                a &= ~num;
                a |= 0x40000000;
                a = a >> (b - 1);
                return a;
            }
            a = a >> b;
            return a;
        }
    }

    #endregion

    #region PageRank
    public class PageRank
    {
        private const string PAGERANK_LINK = "http://toolbarqueries.google.com/search?client=navclient-auto&googleip=O;937&ie=UTF-8&oe=UTF-8&features=Rank";

        public static string CheckPR(string m_Url)
        {
            string text = "http://toolbarqueries.google.com/search?client=navclient-auto&googleip=O;937&ie=UTF-8&oe=UTF-8&features=Rank&ch=" + OutputCheckSum(m_Url, 1) + "&q=info:" + m_Url;
            string text2 = CaiJi.GetHtmlSource(text);
            if (text2.Length < 20)
            {
                Regex regex = new Regex("Rank_(?:[0-9]):(?:[0-9]):(?<PageRank>[0-9]+)");
                string value = regex.Match(text2).Groups["PageRank"].ToString();

                value = value.Length == 0 ? "0" : value;
                return value;
            }
            return "-1";
        }

        public static string OutputCheckSum(string m_Url, int m_Version)
        {
            string text = string.Empty;
            CheckSum sum = new CheckSum();
            switch (m_Version)
            {
                case 0:
                    return sum.CalculateChecksumOld(m_Url);

                case 1:
                    return sum.CalculateChecksum(m_Url);
            }
            return text;
        }

        public static string GetGooglePR(string prurl)
        {
            try
            {
                string pr;
                if (prurl.Length < 4)
                {
                    return "ÍøÖ·´íÎó";
                }

                pr = PageRank.CheckPR(prurl);

                if (pr == "0" || pr == "-1")
                {
                    pr = PageRank.CheckPR(Regex.Match(prurl, "http://([^/]+)").Groups[1].Value);
                }

                if ((pr == "0" || pr == "-1") && prurl.Length > 0 && prurl.Substring(prurl.Length - 1) == "/")
                {
                    prurl = prurl.Substring(0, prurl.Length - 1);
                    pr = PageRank.CheckPR(prurl);
                }
                return pr;
            }
            catch (Exception e)
            {
                return "¼ì²â³ö´í:" + e.Message;
            }
        }
    }

    #endregion

}

