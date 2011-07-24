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
    public partial class FrmDataGridView : Form
    {
        public FrmDataGridView()
        {
            InitializeComponent();
        }

        #region ThreadPool

        WaitCallback waitCall;

        private void button1_Click(object sender, EventArgs e)
        {
            waitCall = new WaitCallback(Calc);
            button1.Enabled = false;
            ThreadPool.SetMinThreads(3, 1000);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ThreadPool.QueueUserWorkItem(waitCall, dataGridView1.Rows[i]);
                dataGridView1[3, i].Value = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                dataGridView1.Rows.Add(i, i * 13, null, false, false);
            }
        }

        void Calc(object obj)
        {
            Thread.Sleep(2000);
            DataGridViewRow drv = obj as DataGridViewRow;
            dataGridView1[2, drv.Index].Value = Convert.ToInt32(drv.Cells[0].Value) + Convert.ToInt32(drv.Cells[1].Value);
            dataGridView1[4, drv.Index].Value = true;

        }

        #endregion



        #region Thread
        Thread[] t;
        int threadCount = 5;

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            t = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                t[i] = new Thread(Calc2);
                t[i].IsBackground = true;
                t[i].Start();
            }
        }

        void Calc2(object obj)
        {
            bool have = true;
            int NowId = -1;

            while (have)
            {
                have = false;

                lock (dataGridView1)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (!Convert.ToBoolean(dataGridView1[3, i].Value))
                        {
                            dataGridView1[3, i].Value = true;
                            NowId = i;
                            have = true;
                            break;
                        }
                    }
                }

                if (have)
                {
                    Random rnd = new Random();
                    Thread.Sleep(rnd.Next(1, 6000));
                    dataGridView1[2, NowId].Value =
                                                        Convert.ToInt32(dataGridView1[0, NowId].Value)
                                                        +
                                                        Convert.ToInt32(dataGridView1[1, NowId].Value);
                    dataGridView1[4, NowId].Value = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i].Abort();
            }
        }
        #endregion


    }
}
