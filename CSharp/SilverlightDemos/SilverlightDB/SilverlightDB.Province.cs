using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace SilverlightDB
{
    public partial class SilverlightDB
    {
        private static List<Province> _ALLProvince;
        public static List<Province> ALLProvince
        {
            get
            {
                if (_ALLProvince != null)
                {
                    return _ALLProvince;
                }

                var lst = _ALLProvince=new List<Province>();
                lst.Add(new Province { CountryID = 1, ProvinceID = 1, ProvinceName = "北京", ProvinceEnglishName = "Beijing" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 2, ProvinceName = "上海", ProvinceEnglishName = "Shanghai" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 3, ProvinceName = "天津", ProvinceEnglishName = "Tianjin" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 4, ProvinceName = "重慶", ProvinceEnglishName = "Chongqing" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 5, ProvinceName = "黑龍江", ProvinceEnglishName = "Heilongjiang" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 6, ProvinceName = "吉林", ProvinceEnglishName = "Jilin" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 7, ProvinceName = "遼寧", ProvinceEnglishName = "Liaoning" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 8, ProvinceName = "河北", ProvinceEnglishName = "Hebei" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 9, ProvinceName = "河南", ProvinceEnglishName = "Henan" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 10, ProvinceName = "山東", ProvinceEnglishName = "Shandong" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 11, ProvinceName = "山西", ProvinceEnglishName = "Shanxi" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 12, ProvinceName = "陜西", ProvinceEnglishName = "Shanxi" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 13, ProvinceName = "甘肅", ProvinceEnglishName = "Gansu" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 14, ProvinceName = "寧夏", ProvinceEnglishName = "Ningxia" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 15, ProvinceName = "江蘇", ProvinceEnglishName = "Jiangsu" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 16, ProvinceName = "浙江", ProvinceEnglishName = "Zhejiang" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 17, ProvinceName = "安徽", ProvinceEnglishName = "Anhui" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 18, ProvinceName = "江西", ProvinceEnglishName = "Jiangxi" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 19, ProvinceName = "福建", ProvinceEnglishName = "Fujian" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 20, ProvinceName = "湖北", ProvinceEnglishName = "Hubei" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 21, ProvinceName = "湖南", ProvinceEnglishName = "Hunan" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 22, ProvinceName = "四川", ProvinceEnglishName = "Sichuan" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 23, ProvinceName = "廣東", ProvinceEnglishName = "Guangdong" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 24, ProvinceName = "廣西", ProvinceEnglishName = "Guangxi" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 25, ProvinceName = "云南", ProvinceEnglishName = "Yunnan" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 26, ProvinceName = "貴州", ProvinceEnglishName = "Guizhou" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 27, ProvinceName = "青海", ProvinceEnglishName = "Qinghai" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 28, ProvinceName = "內蒙古", ProvinceEnglishName = "Neimenggu" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 29, ProvinceName = "新疆", ProvinceEnglishName = "Xinjiang" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 30, ProvinceName = "西藏", ProvinceEnglishName = "Xizang" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 31, ProvinceName = "海南", ProvinceEnglishName = "Hainan" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 32, ProvinceName = "香港", ProvinceEnglishName = "Hongkong" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 33, ProvinceName = "澳門", ProvinceEnglishName = "Macao" });
                lst.Add(new Province { CountryID = 1, ProvinceID = 53, ProvinceName = "臺灣", ProvinceEnglishName = "Taiwan" });
                return lst;
            }
        }
    }
}
