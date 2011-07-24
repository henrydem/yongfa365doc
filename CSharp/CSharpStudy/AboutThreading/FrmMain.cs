using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AboutThreading
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBackgroundWorker frm = new FrmBackgroundWorker();
            frm.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Idle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmChouJiang frm = new FrmChouJiang();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmDataGridView frm = new FrmDataGridView();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmThreadUI frm = new FrmThreadUI();
            frm.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmThreadUI2 frm = new FrmThreadUI2();
            frm.ShowDialog();
        }





    }
}
