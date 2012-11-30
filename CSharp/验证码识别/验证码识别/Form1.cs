using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace 验证码识别
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("", "");
        }


        private void button1_Click(object sender, EventArgs e)
        {
           AboutUnCodeYongfa365();
        }



        private void AboutUnCodeYongfa365()
        {
            var code = new UnCodeYongfa365("http://www.yongfa365.com/Common/caaabbb.asp");
            flowLayoutPanel1.Controls.Add(new PictureBox() { Image = code.BmpSource });
            var time = DateTime.Now;
            var result = code.Get();
            label2.Text = (DateTime.Now - time).ToString();
            foreach (var item in result.Item3)
            {
                dataGridView1.Rows.Add(item);
            }
            label1.Text = result.Item1;
        }

    }
}
