using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;

namespace AboutCustomConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nSingleTagSectionHandler:");
            var dicSingleTagSectionHandler = ConfigurationManager.GetSection("SingleTagSectionHandler") as IDictionary;
            foreach (DictionaryEntry item in dicSingleTagSectionHandler)
            {
                Console.WriteLine("Key:{0} Value:{1}", item.Key, item.Value);
            }


            Console.WriteLine("\r\nDictionarySectionHandler:");
            var dictDictionarySectionHandler = ConfigurationManager.GetSection("DictionarySectionHandler") as IDictionary;
            foreach (string key in dictDictionarySectionHandler.Keys)
            {
                Console.WriteLine("Key:{0} Value:{1}", key, dictDictionarySectionHandler[key]);
            }



            Console.WriteLine("\r\nNameValueSectionHandler:");
            var dictNameValueCollection = ConfigurationManager.GetSection("NameValueSectionHandler") as NameValueCollection;
            foreach (string key in dictNameValueCollection.Keys)
            {
                Console.WriteLine("Key:{0} Value:{1}", key, dictNameValueCollection[key]);
            }




            Console.WriteLine("\r\nMyBlogSection:");
            var myBlogSection = ConfigurationManager.GetSection("MyBlogSection") as MyBlogSection;
            foreach (Blog item in myBlogSection.Blogs)
            {
                Console.WriteLine("Key:{0} Value:{1}", item.UserName, item.BlogUrl);
            }

            Console.WriteLine("\r\nMySiteSection:");
            var mySiteSection = ConfigurationManager.GetSection("MySiteSection") as MySiteSection;
            Console.WriteLine(mySiteSection.CnBlogs.BlogUrl);
            Console.WriteLine(mySiteSection.YongFa365.BlogUrl);


        }
    }

    #region MyBlogSection

    public class MyBlogSection : ConfigurationSection
    {
        [ConfigurationProperty("blogs", IsDefaultCollection = false)]
        public Blogs Blogs { get { return (Blogs)base["blogs"]; } }
    }

    //[ConfigurationCollection(typeof(Blogs),AddItemName="add")]
    public class Blogs : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Blog();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Blog)element).UserName;
        }
    }

    public class Blog : ConfigurationElement
    {
        #region 配置節設置，設定檔中有不能識別的元素、屬性時，使其不報錯
        /// <summary>
        /// 遇到未知屬性時，不報錯
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            //return base.OnDeserializeUnrecognizedAttribute(name, value);
            return true;
        }

        /// <summary>
        /// 遇到未知元素時，不報錯
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            //return base.OnDeserializeUnrecognizedElement(elementName, reader);
            return true;
        }
        #endregion

        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName { get { return this["UserName"].ToString(); } }

        [ConfigurationProperty("BlogUrl", IsRequired = true)]
        public string BlogUrl { get { return this["BlogUrl"].ToString(); } }

        [ConfigurationProperty("Hits", IsRequired = true)]
        public int Hits { get { return (int)this["Hits"]; } }

    }
    #endregion


    #region MySiteSection

    public class MySiteSection : ConfigurationSection
    {
        [ConfigurationProperty("cnblogs", IsDefaultCollection = false)]
        public Blog CnBlogs { get { return (Blog)base["cnblogs"]; } }

        [ConfigurationProperty("yongfa365", IsDefaultCollection = false)]
        public Blog YongFa365 { get { return (Blog)base["yongfa365"]; } }
    }


    #endregion




}
