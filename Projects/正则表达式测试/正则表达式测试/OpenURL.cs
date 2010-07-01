using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 正则表达式测试
{
    public partial class OpenURL : Form
    {
        public OpenURL()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;

        }
        public string URL
        {
            get { return txtURL.Text; }
            set { txtURL.Text = value; }
        }

        private void OpenURL_Load(object sender, EventArgs e)
        {
            this.Top -= 150;
            this.Left -= 40;
        }



    }
}