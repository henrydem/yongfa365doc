using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using YongFa365.CaiJi;
using GooglePageRank;


namespace FriendsLinks
{
    public partial class FriendsLinks : Form
    {

        public FriendsLinks()
        {
            InitializeComponent();
        }

        private void btnGetURL_Click(object sender, EventArgs e)
        {

            if (CheckInput())
            {
                dataGridView1.Rows.Clear();
                BuildDG();
            }


        }

        private void btnCheckURL_Click(object sender, EventArgs e)
        {
            CheckLinks();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.RowCount; i++)
            {
                this.dataGridView1.Rows[i].Cells["blFlag"].Value = !Convert.ToBoolean(this.dataGridView1.Rows[i].Cells["blFlag"].Value);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                System.Diagnostics.Process.Start("Iexplore.exe", this.dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void wwwChiZonecnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMyURL.Text = "http://www.chizone.cn";
            txtS.Text = "http://www.dazhaxie.org.cn";
            txtD.Text = "http://www.0771eat.cn/";

        }

        private void wwwyongfa365comToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMyURL.Text = "http://www.yongfa365.com/BlogLinks.html";
            txtS.Text = "http://www.cnblogs.com/";
            txtD.Text = "http://www.gupiaoji.com/";
        }

        private void FriendsLinks_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidth = 30;
        }

        private void 柳永法yongfa365BlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Iexplore.exe", "http://www.yongfa365.com/");
        }
        void BuildDG()
        {
            Regex re;
            string Pattern;

            //取本站的链接并筛选出友情链接块
            string tempstr = CaiJi.GetHtmlSource(txtMyURL.Text);

            Pattern = "<a[^<>]+href\\s*=\\s*[\"']*" + txtS.Text + @"[\s\S]+" + txtD.Text + "[^<>]*?>[\\s\\S]+?</a>";
            re = new Regex(Pattern, RegexOptions.IgnoreCase);
            Match match = re.Match(tempstr);
            tempstr = match.Value;

            //从友情链接块里取出链接地址及链接名称
            Pattern = "<a[^<>]+href\\s*=\\s*[\"']*([^<>\"' ]+/*)[\"']*[^<>]*?>([\\s\\S]+?)</a>";
            re = new Regex(Pattern, RegexOptions.IgnoreCase);
            MatchCollection matchs = re.Matches(tempstr);

            foreach (Match m in matchs)
            {
                this.dataGridView1.Rows.Add(m.Groups[2].Value, m.Groups[1].Value);
            }
        }
        void CheckLinks()
        {
            int n = 8;
            Thread[] Threads;
            //声名下载线程，这是C#的优势，即数组初始化时，不需要指定其长度，可以在使用时才指定。
            //这个声名应为类级，这样也就为其它方法控件它们提供了可能
            ThreadStart startThreadProc = new ThreadStart(ThreadProc);
            //线程起始设置：即每个线程都执行DownLoad()

            Threads = new Thread[n];//为线程申请资源，确定线程总数
            for (int i = 0; i < n; i++)//开启指定数量的线程数
            {
                Threads[i] = new Thread(startThreadProc);//指定线程起始设置
                Threads[i].Start();//逐个开启线程
            }

            for (int i = 0; i < n; i++)//开启指定数量的线程数
            {
                Threads[i].Join();
            }
            MessageBox.Show("操作完成");

        }
        bool CheckInput()
        {
            txtMyURL.Text = Regex.Replace(txtMyURL.Text.Trim(), "(.+)/$", "$1");
            txtD.Text = Regex.Replace(txtD.Text.Trim(), "(.+)/$", "$1");
            txtS.Text = Regex.Replace(txtS.Text.Trim(), "(.+)/$", "$1");

            if (!Regex.IsMatch(txtMyURL.Text, "http://.+") || !Regex.IsMatch(txtS.Text, "http://.+") || !Regex.IsMatch(txtD.Text, "http://.+"))
            {
                MessageBox.Show("输入不合法，请核查");
                txtMyURL.Focus();
                return false;
            }
            return true;

        }


        public void ThreadProc()
        {
            try
            {
                bool flags = false;
                string tempstr = "";
                string myurl = txtMyURL.Text.Trim();
                string mydomain;
                if (myurl.Substring(myurl.Length - 1) == "/")
                {
                    myurl = myurl.Substring(0, myurl.Length - 1);
                }
                mydomain = myurl;
                mydomain = Regex.Match(mydomain, "http://[^/]+").Value;

                //友情链接检测工具http://regexlib.com/RETester.aspx
                //<a[^<>]+href\s*=\s*["']*([^"' ]*)["']*[^<>]*?>([\s\S]+?)</a>
                // <a[\s\S]*?href=("(?<href>[^"]*)"|'(?<href>[^']*)'|(?<href>[^>\s]*))[^>]*?>(?<title>[\s\S]*?)</a>   
                // @"<a[\s\S]*?href=(""(?<href>[^""]*)""|'(?<href>[^']*)'|(?<href>[^>\s]*))[^>]*?>(?<title>[\s\S]*?)</a>",RegexOptions.IgnoreCase   |   RegexOptions.Compiled);   
                //string pattion = "<a[^<>]+href\\s*=\\s*[\"']*(" + mydomain + "/*)[\"']*[^<>]*?>([\\s\\S]+?)</a>";
                //string pattion = @"<a[\s\S]+?href=(""[^""]*"")|('[^']*')|([^>\s]*)[^>]*?>[\s\S]*?</a>";

                string pattion = "<a[^<>]+href\\s*=\\s*[\"']*(\"" + mydomain + "/*\")|('" + mydomain + "/*')|(" + mydomain + "/*)[^<>]*?>([\\s\\S]+?)</a>";

                for (int i = 0; i < this.dataGridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(this.dataGridView1.Rows[i].Cells["blFlag"].Value) != true)
                    {
                        flags = true;
                        string nowurl;

                        this.dataGridView1.Rows[i].Cells["blFlag"].Value = !Convert.ToBoolean(this.dataGridView1.Rows[i].Cells["blFlag"].Value);

                        nowurl = Convert.ToString(this.dataGridView1.Rows[i].Cells["txtWebURL"].Value).ToLower();
                        tempstr = CaiJi.GetHtmlSource(nowurl);



                        if (Regex.IsMatch(tempstr, pattion, RegexOptions.IgnoreCase))
                        {
                            this.dataGridView1.Rows[i].Cells["txtStatus"].Value = "正常";
                        }
                        else
                        {
                            this.dataGridView1.Rows[i].Cells["txtStatus"].Value = "不正常";
                        }
                        if (chkPR.Checked)
                        {
                            this.dataGridView1.Rows[i].Cells["txtPR"].Value = PageRank.GetGooglePR(nowurl);

                        }

                    }
                }

                if (flags)
                {
                    ThreadProc();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void 保存当前方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = GetTrueFileName(txtMyURL.Text);
            WriteFile(filename + ".txt", txtMyURL.Text + "|" + txtS.Text + "|" + txtD.Text);

        }



        private void 载入解决方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string allTxt = ReadFile("");
            if (allTxt.Length > 5)
            {
                string[] allTxts = allTxt.Split('|');
                txtMyURL.Text = allTxts[0];
                txtS.Text = allTxts[1];
                txtD.Text = allTxts[2];
            }

        }

        public string GetTrueFileName(string filename)
        {
            filename = filename.Replace("\\", "＼");
            filename = filename.Replace("/", "／");
            filename = filename.Replace(":", "：");
            filename = filename.Replace("*", "＊");
            filename = filename.Replace("?", "？");
            filename = filename.Replace("\"", "”");
            filename = filename.Replace("<", "＜");
            filename = filename.Replace(">", "＞");
            filename = filename.Replace("|", "｜");
            return filename;
        }

        /// <summary>
        /// winform 读文件 by www.yongfa365.com
        /// </summary>
        /// <param name="filename">默认读取的文件名</param>
        /// <returns></returns>
        public string ReadFile(string filename)
        {
            ////////////////////////读文件操作////////////////////////
            string html = "";
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "打开一个文本文件";
            dlg.FileName = filename;
            dlg.Filter = "所有文件(*.*)|*.*|文本文件 (*.txt)|*.txt;*.ini;*.sql";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                StreamReader din = new StreamReader(filename, System.Text.Encoding.Default);
                while (din.Peek() > -1)
                {
                    html = html + din.ReadToEnd();
                }
                din.Close();
            }
            return html;
        }

        /// <summary>
        /// winform 写文件 by www.yongfa365.com
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="content">文件内容</param>
        public void WriteFile(string filename, string content)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "请选择保存路径";
            dlg.Filter = "所有文件(*.*)|*.*|文本文件 (*.txt)|*.txt;*.ini;*.sql";
            dlg.FileName = filename;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = dlg.FileName;
                StreamWriter dout = new StreamWriter(filename);
                dout.Write(content);
                //必须写下边这句，关闭当前流，不然输入的文本文件内容不全，只有半截。
                dout.Close();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}