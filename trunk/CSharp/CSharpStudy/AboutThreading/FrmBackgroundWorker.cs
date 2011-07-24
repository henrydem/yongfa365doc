using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace AboutThreading
{
    public partial class FrmBackgroundWorker : Form
    {
        public FrmBackgroundWorker()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            toolStripProgressBar1.Maximum = 200;
            toolStripStatusLabel1.Text = string.Empty;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    break;
                }
                backgroundWorker1.ReportProgress(i, "正在处理：" + i);
                Thread.Sleep(20);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "完成";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void BackgroundWorker_Load(object sender, EventArgs e)
        {

        }


    }
}
