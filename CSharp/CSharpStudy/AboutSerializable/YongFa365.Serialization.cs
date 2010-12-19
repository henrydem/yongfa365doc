using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

//http://msdn.microsoft.com/zh-cn/library/2baksw0z.aspx
//http://msdn.microsoft.com/zh-cn/library/7ay27kt9.aspx

namespace YongFa365.Serialization
{
    class SerializeHelper
    {
        #region XmlSerializer
        public string ToXml<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(item.GetType());
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
        /// </summary>
        public string ToXml2<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(item.GetType());

            //在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add("", "");

            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item, xmlns);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 在XML序列化后 xml代码更好看
        /// </summary>
        public string ToXml3<T>(T item)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(item.GetType());
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add("", "");
                serializer.Serialize(stream, item, xmlns);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        public T FromXml<T>(string str)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new StringReader(str)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        #endregion

        #region BinaryFormatter
        public string ToBinary<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                byte[] bytes = ms.ToArray();
                StringBuilder sb = new StringBuilder();
                foreach (byte bt in bytes)
                {
                    sb.Append(string.Format("{0:X2}", bt));
                }
                return sb.ToString();
            }
        }

        public T FromBinary<T>(string str)
        {
            int intLen = str.Length / 2;
            byte[] bytes = new byte[intLen];
            for (int i = 0; i < intLen; i++)
            {
                int ibyte = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                bytes[i] = (byte)ibyte;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion

        #region SoapFormatter
        public string ToSoap<T>(T item)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

        public T FromSoap<T>(string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                xmlDoc.Save(ms);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion


        #region JsonSerializer
        public string ToJson<T>(T item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public T FromJson<T>(string str) where T : class
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
        #endregion

    }
}
