using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightDB;
using SilverlightExtensions;

namespace SilverlightDemos.Controls
{
    public partial class DataGridPagerPage : UserControl
    {
        List<Country> DB;

        public DataGridPagerPage()
        {
            InitializeComponent();
            DB = SilverlightDB.SilverlightDB.ALLCountry.Take(100).ToList();
            Bind();
        }


        private void Bind()
        {
            int count = DB.Count;

            //dataGrid1.ItemsSource = DB.Skip(dataPager1.PageIndex * dataPager1.PageSize).Take(dataPager1.PageSize).ToList();

            //考虑数据量减少的情况
            var newPageIndex = dataPager1.GetNewPageIndex(count);
            dataGrid1.ItemsSource = DB.Skip(newPageIndex * dataPager1.PageSize).Take(dataPager1.PageSize).ToList();

            dataPager1.BindSource(count);


        }


        private void dataPager1_PageIndexChanged_1(object sender, EventArgs e)
        {
            if (dataPager1.IsNeedStopPageIndexChanged())
            {
                return;
            }
            Bind();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB = SilverlightDB.SilverlightDB.ALLCountry.Take(100).ToList();
            Bind();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DB = SilverlightDB.SilverlightDB.ALLCountry.Take(60).ToList();
            Bind();
        }
    }
}
