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
using System.Linq;

namespace SilverlightDB
{
    public partial class SilverlightDB
    {
        public static List<Country> MyCountries
        {
            get
            {
                ALLCountry.ForEach(ct =>
                {
                    ct.ProvinceList = ALLProvince.Where(p => p.CountryID == ct.CountryID).ToList();

                });

                ALLCountry.ForEach(ct =>
                {
                    ct.ProvinceList.ForEach(p => p.CityList = ALLCity.Where(c => c.ProvinceID == p.ProvinceID).ToList());
                });

                return ALLCountry;
            }
        }


    }
}
