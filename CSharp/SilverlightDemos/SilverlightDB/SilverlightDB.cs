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
    public class SilverlightDB
    {
        public static List<Country> MyCountries
        {
            get
            {
                var lst = new List<Country>();
                lst.Add(new Country { CountryName = "中国" });
                lst.Add(new Country { CountryName = "日本" });
                lst.Add(new Country { CountryName = "美国" });
                lst[1].ProvinceList = new List<Province> { new Province { ProvinceName = "东京" } };
                lst[0].ProvinceList = new List<Province>
                        {
                            new Province
                            { 
                                ProvinceName="山西",
                                CityList=new List<City>
                                {
                                    new City{ CityName="太原"},
                                    new City{ CityName="运城"},
                                }
                            },
                            new Province
                            { 
                                ProvinceName="深圳",
                                CityList=new List<City>
                                {
                                    new City{ CityName="罗湖"},
                                    new City{ CityName="龙岗"},
                                }
                            },
                            new Province
                            { 
                                ProvinceName="北京",
                                CityList=new List<City>
                                {
                                    new City{ CityName="朝阳"},
                                    new City{ CityName="顺义"},
                                }
                            },
                    };

                return lst;
            }
        }
    }
}
