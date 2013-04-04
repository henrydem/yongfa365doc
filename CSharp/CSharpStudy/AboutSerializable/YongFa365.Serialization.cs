using System;
using System.IO;
using System.Runtime.Serialization;
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
        public static string ToXml<T>(T item)
        {
            var serializer = new XmlSerializer(item.GetType());
            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
        /// </summary>
        public static string ToXml2<T>(T item)
        {
            var serializer = new XmlSerializer(item.GetType());

            //在XML序列化时去除默认命名空间xmlns:xsd和xmlns:xsi
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add("", "");

            var sb = new StringBuilder();
            using (var writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item, xmlns);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 在XML序列化后 xml代码更好看
        /// </summary>
        public static string ToXml3<T>(T item)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(item.GetType());
                var xmlns = new XmlSerializerNamespaces();
                xmlns.Add("", "");
                serializer.Serialize(stream, item, xmlns);
                return Encoding.UTF8.GetString(stream.GetBuffer());
            }
        }

        public static T FromXml<T>(string str)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new XmlTextReader(new StringReader(str)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        #endregion

        #region BinaryFormatter
        public static string ToBinary<T>(T item)
        {
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                var bytes = ms.ToArray();
                var sb = new StringBuilder();
                foreach (var bt in bytes)
                {
                    sb.Append(string.Format("{0:X2}", bt));
                }
                return sb.ToString();
            }
        }

        public static T FromBinary<T>(string str)
        {
            var intLen = str.Length / 2;
            var bytes = new byte[intLen];
            for (var i = 0; i < intLen; i++)
            {
                var ibyte = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                bytes[i] = (byte)ibyte;
            }
            var formatter = new BinaryFormatter();
            using (var ms = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion

        #region SoapFormatter
        public static string ToSoap<T>(T item)
        {
            var formatter = new SoapFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

        public static T FromSoap<T>(string str)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            var formatter = new SoapFormatter();
            using (var ms = new MemoryStream())
            {
                xmlDoc.Save(ms);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion


        #region DataContractSerializer XML
        public static string DataContractSerializerToXML<T>(T item)
        {
            var serializer = new DataContractSerializer(item.GetType());
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T DataContractSerializerFromXML<T>(string str) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
        #endregion


        #region DataContractJsonSerializer json
        public static string DataContractSerializerToJson<T>(T item)
        {
            var serializer = new DataContractJsonSerializer(item.GetType());
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T DataContractSerializerFromJson<T>(string str) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
        #endregion

    }
}
