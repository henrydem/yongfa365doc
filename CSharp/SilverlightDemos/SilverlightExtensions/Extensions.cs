using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightExtensions
{
    public static class Extensions
    {

        public static void BindSource(this DataPager dataPager, int totalCount, int pageSize)
        {
            var list = new List<int>(totalCount);
            for (int i = 0; i < totalCount; i++) list.Add(i);
            dataPager.Source = new PagedCollectionView(list)
            {
                PageSize = pageSize
            };
        }


    }
}
