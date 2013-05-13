using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace RouteSection
{
    class Program
    {
        static void Main(string[] args)
        {
            RouteConfigManager.RegisterRoutes();
            Console.WriteLine(RouteTable.Routes.Count);
        }
    }


    public static class RouteConfigManager
    {
        public static void RegisterRoutes()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var section = ConfigurationManager.GetSection("RouteConfigSection") as RouteConfigSection;

            if (section == null || section.Routings.Count == 0)
            {
                return;
            }

            foreach (RouteConfigElement route in section.Routings)
            {
                if (route.Type == "clear")
                {
                    routes.Clear();
                }
                else if (route.Type == "ignore")
                {
                    routes.IgnoreRoute(route.Url, route.Constraints.Value);
                }
                else if (route.Type == "map")
                {

                    routes.Add(route.Name, new Route
                        (
                        route.Url, 
                        route.Defaults.Value, 
                        route.Constraints.Value, 
                        route.DataTokens.Value, 
                        GetInstanceOfRouteHandler(route)
                        )
                        );
                }
            }

        }

        private static IRouteHandler GetInstanceOfRouteHandler(RouteConfigElement route)
        {
            IRouteHandler routeHandler;

            if (string.IsNullOrEmpty(route.RouteHandlerType))
            {
                routeHandler = new MvcRouteHandler();
            }
            else
            {
                try
                {
                    Type routeHandlerType = Type.GetType(route.RouteHandlerType);
                    routeHandler = Activator.CreateInstance(routeHandlerType) as IRouteHandler;
                }
                catch (Exception e)
                {
                    throw new ApplicationException(
                                 string.Format("Can't create an instance of IRouteHandler {0}", route.RouteHandlerType),
                                 e);
                }

            }

            return routeHandler;
        }
    }


    public class RouteConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("routes", IsDefaultCollection = false)]
        public RouteConfigElementCollection Routings { get { return (RouteConfigElementCollection)base["routes"]; } }
    }


    public class RouteConfigElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RouteConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RouteConfigElement)element).Name;
        }
    }


    public class RouteConfigElement : ConfigurationElement
    {
        #region 配置節設置，設定檔中有不能識別的元素、屬性時，使其不報錯

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            return true;
        }

        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            return true;
        }
        #endregion

        /// <summary>
        /// 操作类型，支持clear ignore map
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("defaults", IsRequired = false)]
        public RouteConfigChildElement Defaults
        {
            get { return (RouteConfigChildElement)this["defaults"]; }
            set { this["defaults"] = value; }
        }

        [ConfigurationProperty("constraints", IsRequired = false)]
        public RouteConfigChildElement Constraints
        {
            get { return (RouteConfigChildElement)this["constraints"]; }
            set { this["constraints"] = value; }
        }

        [ConfigurationProperty("dataTokens", IsRequired = false)]
        public RouteConfigChildElement DataTokens
        {
            get { return (RouteConfigChildElement)this["dataTokens"]; }
            set { this["dataTokens"] = value; }
        }

        [ConfigurationProperty("routeHandlerType", IsRequired = false)]
        public string RouteHandlerType
        {
            get { return (string)this["routeHandlerType"]; }
            set { this["routeHandlerType"] = value; }
        }
    }


    public class RouteConfigChildElement : ConfigurationElement
    {
        private RouteValueDictionary _Value = new RouteValueDictionary();

        public RouteValueDictionary Value
        {
            get { return this._Value; }
        }

        protected override bool OnDeserializeUnrecognizedAttribute(string name, string value)
        {
            if (value == "UrlParameter.Optional")
            {
                _Value.Add(name, UrlParameter.Optional);
            }
            else
            {
                _Value.Add(name, value);
            }

            return true;
        }
    }




}