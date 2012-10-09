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

    public class Country
    {
        public int CountryID { get; set; } 
        public string CountryName { get; set; }
        public string CountryEnglishName { get; set; }
        public List<Province> ProvinceList { get; set; }
    }
    public class Province
    {

        public int CountryID { get; set; }
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceEnglishName { get; set; }
        public List<City> CityList { get; set; }
    }
    public class City
    {
        public int CountryID { get; set; }
        public int ProvinceID { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityEnglishName { get; set; }
    }
}
