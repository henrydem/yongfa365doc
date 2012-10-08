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

namespace SilverlightDemos.Controls
{
    public partial class TreeViewPage : UserControl
    {
        public TreeViewPage()
        {
            InitializeComponent();
            countryTree.ItemsSource = SilverlightDB.SilverlightDB.MyCountries ;
        }
    }
}
