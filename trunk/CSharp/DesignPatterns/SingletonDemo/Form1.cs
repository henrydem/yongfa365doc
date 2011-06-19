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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //FrmToolBox frm = new FrmToolBox();  //不能这么调用

            FrmToolBox frm = FrmToolBox.Instance;
            frm.MdiParent = this;
            frm.Show();

        }

        private void 打开工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmToolBox frm = FrmToolBox.Instance;
            frm.MdiParent = this;
            frm.Show();

        }
    }
}
