using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformControlsDemo
{
    public partial class FrmCommon : Form
    {
        public FrmCommon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = string.Format("Value:{0},Text:{1}\n在VS里没Text属性的智能提示，但可以调用", numericUpDown1.Value, numericUpDown1.Text);
            MessageBox.Show(str);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore", linkLabel1.Text);
            System.Diagnostics.Process.Start("firefox", linkLabel1.Text);
            System.Diagnostics.Process.Start("chrome", linkLabel1.Text);
        }


    }
}
