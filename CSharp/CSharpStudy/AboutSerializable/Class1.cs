using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using YongFa365.Serialization;

namespace AboutSerializable
{
    class Class1
    {
        public void Run()
        {
            {
                var cls = new MyClass { DateTimes = new List<DateTime> { DateTime.Now, DateTime.Now } };
                var result1 = SerializeHelper.ToXml3(cls);
                Debug.WriteLine("\r\n\r\n{0}\r\n\r\n",(object)result1);

            }
            {
                var cls = new MyClass2 { DateTimes = new List<DateTime> { DateTime.Now, DateTime.Now } };
                var result1 = SerializeHelper.ToXml3(cls);
                Debug.WriteLine("\r\n\r\n{0}\r\n\r\n", (object)result1);
            }

            {
                var cls = new MyClass3 { DateTimes = new List<DateTime> { DateTime.Now, DateTime.Now } };
                var result1 = SerializeHelper.ToXml3(cls);
                Debug.WriteLine("\r\n\r\n{0}\r\n\r\n", (object)result1);
            }
        }
    }

    public class MyClass
    {
        public List<DateTime> DateTimes { get; set; }
    }

    public class MyClass2
    {
        [XmlElement("DateTime.XmlElement")]
        public List<DateTime> DateTimes { get; set; }
    }

    public class MyClass3
    {
        [XmlArray("DateTime.XmlArray")]
        [XmlArrayItem("DateTime.XmlArrayItem")]
        public List<DateTime> DateTimes { get; set; }
    }


}
