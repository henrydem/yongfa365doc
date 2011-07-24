using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AboutThreading
{
    public partial class FrmChouJiang : Form
    {
        private Int32 intCount;
        public FrmChouJiang()
        {
            InitializeComponent();
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            while (intCount != 0 && !backgroundWorker1.CancellationPending)
            {
                backgroundWorker1.ReportProgress(1, rnd.Next(0, intCount));
                Thread.Sleep(1);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Int32 intIndex = Convert.ToInt32(e.UserState);
            if (intIndex > -1)
            {
                textBox1.Text = listBox1.Items[intIndex].ToString();
            }
        }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox2.Items.Add(textBox1.Text);
                listBox1.Items.Remove(textBox1.Text);
                intCount = listBox1.Items.Count;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (string item in txtS.Text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries))
            {
                listBox1.Items.Add(item);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";
        }

        private void btnOpt_Click(object sender, EventArgs e)
        {
            if (btnOpt.Text == "开始")
            {
                textBox1.Text = "";
                intCount = listBox1.Items.Count;
                backgroundWorker1.RunWorkerAsync();
                btnOpt.Text = "停止";
            }
            else
            {
                backgroundWorker1.CancelAsync();
                btnOpt.Text = "开始";
            }
        }
    }
}
