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

namespace SilverlightDemos.Layout
{
    public partial class ByGrid : UserControl
    {
        public ByGrid()
        {
            InitializeComponent();
            SilverlightExtensions.MouseEventHelper.SetMouseDoubleClick(splitter, new MouseButtonEventHandler(OnGridSplitterDoubleClick));
        }

        private void OnGridSplitterDoubleClick(object sender, MouseButtonEventArgs e)
        {
            leftCol.Width = new GridLength(leftCol.Width.Value == 150 ? 10 : 150);
        }
    }
}
namespace SilverlightDemos
{
    public partial class Union
    {
        public UserControl ByGrid = new Layout.ByGrid();
    }
}
