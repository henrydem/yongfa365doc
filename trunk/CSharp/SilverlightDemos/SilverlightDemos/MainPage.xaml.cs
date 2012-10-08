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
using System.Reflection;

namespace SilverlightDemos
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();


            var layout = new TreeViewItem { Header = "布局", IsExpanded = true };
            leftTree.Items.Add(layout);
            Union controls = new Union();
            controls.GetType().GetFields().ToList().ForEach(item => {
                layout.Items.Add(new TreeViewItem { Header = item.Name });

            });
            leftTree.SelectedItemChanged += leftTree_SelectedItemChanged;
        }

        void leftTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            MessageBox.Show((e.NewValue as TreeViewItem).Header.ToString());
        }

    }
}
