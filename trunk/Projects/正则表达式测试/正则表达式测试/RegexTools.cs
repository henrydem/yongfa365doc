using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;


namespace 正则表达式测试
{

    public partial class RegexTools : Form
    {
        public RegexTools()
        {
            InitializeComponent();
            AcceptButton = btnReplace;
            btnReplace.Focus();

        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            try
            {
                RegexOptions option = new RegexOptions();
                if (chkIgnoreCase.Checked && chkMultiline.Checked)
                {
                    option = RegexOptions.IgnoreCase | RegexOptions.Multiline;
                }
                else if (chkIgnoreCase.Checked)
                {
                    option = RegexOptions.IgnoreCase;
                }
                else if (chkMultiline.Checked)
                {
                    option = RegexOptions.Multiline;
                }
                txtD.Text = "";
                string str = "";
                foreach (Match m in Regex.Matches(txtSource.Text, cbxRegExp.Text, option))
                {
                    str += "匹配内容：" + m.Value + "\r\n";
                    for (int i = 1; i < m.Groups.Count; i++)
                    {
                        str += "$" + (i + 0) + ":" + m.Groups[i + 0].Value + "\r\n";
                    }
                    txtD.Text = str;

                }
            }
            catch { }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                RegexOptions option = new RegexOptions();
                if (chkIgnoreCase.Checked && chkMultiline.Checked)
                {
                    option = RegexOptions.IgnoreCase | RegexOptions.Multiline;
                }
                else if (chkIgnoreCase.Checked)
                {
                    option = RegexOptions.IgnoreCase;
                }
                else if (chkMultiline.Checked)
                {
                    option = RegexOptions.Multiline;
                }
                MatchCollection a = Regex.Matches(txtSource.Text, txtRegExp2.Text, RegexOptions.Multiline);
                txtD.Text = Regex.Replace(txtSource.Text, cbxRegExp.Text, txtRegExp2.Text, option);
            }
            catch { }
        }

        private void btnMatchCount_Click(object sender, EventArgs e)
        {
            RegexOptions option = new RegexOptions();
            if (chkIgnoreCase.Checked)
                option = RegexOptions.IgnoreCase;
            MessageBox.Show(Convert.ToString(Regex.Matches(txtSource.Text, cbxRegExp.Text, option).Count));
        }

        private void 从文件导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////////////////////////读文件操作////////////////////////   
            string html = "";
            string filename = "";

            //获取文件名   
            OpenFileDialog dl = new OpenFileDialog();
            dl.Title = "打开一个文本文件";
            dl.FileName = filename;
            dl.Filter = "所有文件(*.*)|*.*|文本文件 (*.txt)|*.txt;*.ini;*.sql";
            if (dl.ShowDialog() == DialogResult.OK)
            {
                filename = dl.FileName;
                StreamReader din = new StreamReader(filename, System.Text.Encoding.Default);
                while (din.Peek() > -1)
                {
                    html = html + din.ReadToEnd();
                }
                din.Close();

                //返回值
                txtSource.Text = html;
            }


        }

        private void 从网站导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "";
            OpenURL openurl = new OpenURL();
            openurl.ShowDialog();
            if (openurl.DialogResult == DialogResult.OK)
            {
                url = openurl.URL;
                if (IsUrl(url))
                {
                    txtSource.Text = YongFa365.CaiJi.CaiJi.GetHTML(url);
                }
            }

        }

        private void txtSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void txtD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        public static bool IsUrl(string source)
        {
            return Regex.IsMatch(source, @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$", RegexOptions.IgnoreCase);
        }

        private void 从文件导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            string filename = "";

            //获取文件名   
            OpenFileDialog dl = new OpenFileDialog();
            dl.Title = "打开 正则表达式 文本文件";
            dl.FileName = filename;
            dl.Filter = "所有文件(*.*)|*.*|文本文件 (*.txt)|*.txt;*.ini;*.sql";
            if (dl.ShowDialog() == DialogResult.OK)
            {
                filename = dl.FileName;
                StreamReader din = new StreamReader(filename, System.Text.Encoding.Default);
                cbxRegExp.Items.Clear();
                while (din.Peek() > -1)
                {
                    cbxRegExp.Items.Add(din.ReadLine());
                }
                din.Close();
            }


        }

        private void 还原默认数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbxRegExp.Items.Clear();
            this.cbxRegExp.Items.AddRange(new object[] {
            "\\s",
            "\\d",
            "\\w",
            "(.+?)",
            "================网络匹配===================",
            "<[^<>]+?>",
            "[a-zA-z]+://[^\\s]*",
            "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
            "\\d+\\.\\d+\\.\\d+\\.\\d+",
            "================电话，手机=================",
            "1[35]\\d{9}",
            "d{3,4}-?\\d{6,8}",
            "================中文=======================",
            "[\\u4e00-\\u9fa5]",
            "[^\\x00-\\xff]",
            "================排版=======================",
            "^[ \\t]*|[ \\t]*$"});

            cbxRegExp.Focus();
        }

        private void 柳永法yongfa365BlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Iexplore.exe", "http://www.yongfa365.com/");
        }

    }
}