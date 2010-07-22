using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace NPOI_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            DataTable dt = ClassLibrary1.DBMaker.人员表();
            sp.Stop();
            MessageBox.Show("获取数据到DataTable用时：" + sp.ElapsedMilliseconds + "ms");

            sp.Reset();
            sp.Start();
            dataGridView1.DataSource = dt;
            sp.Stop();
            MessageBox.Show("dataGridView1加载DataTable用时：" + sp.ElapsedMilliseconds + "ms");

            sp.Reset();
            sp.Start();
            ExcelHelper.Export(dt,"人员详情", DateTime.Now.ToString("yyyyMMddHHmmssfff")+".xls");
            sp.Stop();
            MessageBox.Show("DataTable导出到Excel用时：" + sp.ElapsedMilliseconds + "ms");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
               dataGridView1.DataSource= ExcelHelper.Import(dlg.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            DataTable dt = ClassLibrary1.DBMaker.人员表();
            sp.Stop();
            MessageBox.Show("获取数据到DataTable用时：" + sp.ElapsedMilliseconds + "ms");

            sp.Reset();
            sp.Start();
            dataGridView1.DataSource = dt;
            sp.Stop();
            MessageBox.Show("dataGridView1加载DataTable用时：" + sp.ElapsedMilliseconds + "ms");

            sp.Reset();
            sp.Start();
            ExcelHelper.ExportEasy(dt, DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls");
            sp.Stop();
            MessageBox.Show("DataTable导出到Excel用时：" + sp.ElapsedMilliseconds + "ms");
        }
    }
}
