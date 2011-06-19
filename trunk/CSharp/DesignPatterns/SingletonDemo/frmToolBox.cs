using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SingletonDemo
{
    public partial class FrmToolBox : Form
    {
        private static readonly FrmToolBox instance = new FrmToolBox();

        public static FrmToolBox Instance { get { return instance; } }

        private FrmToolBox()
        {
            InitializeComponent();
        }



        private void FrmToolBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }
    }
}
