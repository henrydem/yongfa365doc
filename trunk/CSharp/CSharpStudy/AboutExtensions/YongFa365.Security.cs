using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

//Update: 2010年12月26日16:24:22 
//TODO: 研究System.Security.Cryptography下的各种ServiceProvider
//TODO: 对比用AesServiceProvider加密 和 现在的加密有何不同，效率如何？
namespace YongFa365.Security
{
    #region 通用加密


    public static class Common
    {

        public static string ToSHA1(this string input)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            string result = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(input)));
            return result.Replace("-", "");
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

        /// <summary>
        /// MD5 按自己需要截取MD5的里的相关部分
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startIndex">起始字符位置（从0开始）</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string ToMD5(this string input, int startIndex, int length)
        {
            return input.To32bitMD5().Substring(startIndex, length);
        }
    }

    #endregion

    #region DES加密、解密
    /// <summary>
    /// DES加密解密
    /// </summary>
    public static class DES
    {
        /// <summary>
        /// 获取密钥
        /// </summary>
        private static string Key
        {
            get { return @"P@+#wG+Z"; }
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        private static string IV
        {
            get { return @"L%n67}G\Mk@k%:~Y"; }
        }


        /// <summary>
        /// DES加密
        /// 使用此类里硬编码的Key及IV
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>密文</returns>
        public static string DESEncrypt(this string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);

            return DESEncrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string DESEncrypt(this string input, string key)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(key.ToMD5(0, 8));
            byte[] rgbIV = Encoding.UTF8.GetBytes(key.ToMD5(0, 16));

            return DESEncrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>密文</returns>
        public static string DESEncrypt(this string input, string key, string iv)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            return DESEncrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rgbKey">密钥</param>
        /// <param name="rgbIV">向量</param>
        /// <returns>密文</returns>
        public static string DESEncrypt(this string input, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return DESEncrypt(buffer, rgbKey, rgbIV);
        }

        private static string DESEncrypt(byte[] buffer, byte[] rgbKey, byte[] rgbIV)
        {
            string encrypt = null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(buffer, 0, buffer.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return encrypt;
        }

        /// <summary>
        /// DES解密
        /// 使用此类里硬编码的Key及IV
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>明文</returns>
        public static string DESDecrypt(this string input)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);

            return DESDecrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string DESDecrypt(this string input, string key)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(key.ToMD5(0, 8));
            byte[] rgbIV = Encoding.UTF8.GetBytes(key.ToMD5(0, 16));

            return DESDecrypt(buffer, rgbKey, rgbIV);
        }


        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>明文</returns>
        public static string DESDecrypt(this string input, string key, string iv)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            return DESDecrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rgbKey">密钥</param>
        /// <param name="rgbIV">向量</param>
        /// <returns>明文</returns>
        public static string DESDecrypt(this string input, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return DESDecrypt(buffer, rgbKey, rgbIV);
        }

        private static string DESDecrypt(byte[] buffer, byte[] rgbKey, byte[] rgbIV)
        {
            string decrypt = null;
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, des.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(buffer, 0, buffer.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch { }
            des.Clear();

            return decrypt;
        }
    }

    #endregion

    #region AES加密、解密

    /// <summary>
    /// AES加密解密
    /// </summary>
    public static class AES
    {
        /// <summary>
        /// 获取密钥
        /// </summary>
        private static string Key
        {
            get { return @")O[NB]6,YF}+efcaj{+oESb9d8>Z'e9M"; }
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        private static string IV
        {
            get { return @"L+\~f4,Ir)b$=pkf"; }
        }



        /// <summary>
        /// AES加密
        /// 使用此类里硬编码的Key及IV
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(this string input)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);

            return AESEncrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="input">明文字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(this string input, string key)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(key.To32bitMD5());
            byte[] rgbIV = Encoding.UTF8.GetBytes(key.To16bitMD5());

            return AESEncrypt(buffer, rgbKey, rgbIV);
        }


        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(this string input, string key, string iv)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            return AESEncrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rgbKey">密钥</param>
        /// <param name="rgbIV">向量</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(this string input, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return AESEncrypt(buffer, rgbKey, rgbIV);
        }


        private static string AESEncrypt(byte[] buffer, byte[] rgbKey, byte[] rgbIV)
        {
            string encrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(buffer, 0, buffer.Length);
                        cStream.FlushFinalBlock();
                        encrypt = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return encrypt;
        }


        /// <summary>
        /// AES解密
        /// 使用此类里硬编码的Key及IV
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(this string input)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);

            return AESDecrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="input">密文字符串</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(this string input, string key)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(key.To32bitMD5());
            byte[] rgbIV = Encoding.UTF8.GetBytes(key.To16bitMD5());

            return AESDecrypt(buffer, rgbKey, rgbIV);
        }



        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(this string input, string key, string iv)
        {
            byte[] buffer = Convert.FromBase64String(input);
            byte[] rgbKey = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IV);
            return AESDecrypt(buffer, rgbKey, rgbIV);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="rgbKey">密钥</param>
        /// <param name="rgbIV">向量</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(this string input, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return AESDecrypt(buffer, rgbKey, rgbIV);
        }


        private static string AESDecrypt(byte[] buffer, byte[] rgbKey, byte[] rgbIV)
        {
            string decrypt = null;
            Rijndael aes = Rijndael.Create();
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(buffer, 0, buffer.Length);
                        cStream.FlushFinalBlock();
                        decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch { }
            aes.Clear();

            return decrypt;
        }


    }
    #endregion
}