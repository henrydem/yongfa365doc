using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

using YongFa365.CaiJi;
using YongFa365.String;


namespace _51job
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadColumns();
            加载默认ToolStripMenuItem.PerformClick();
        }



        private void 加载默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>() 
            {
                "VS2005","VS2010","VS2008","多线程","VisualStudio","Visual Studio","ASP.net",".net winform",".net C#","MVC","WebService","三层架构","多层架构",
                "Linq","Linq to sql","ORM","NHibernate","WCF","WPF","OOP","OOA",
                "SQLServer","SQL Server","MSSQL","SQL2000","SQL2005","SQL2008","Mysql","SQLite","Access","Oracle",
                "IIS","服务器安全","邮件服务器","FTP","DNS",
                "正则表达式","CRM","水晶报表",".net 报表",
                "WF","workflow",".nwt OA",".net HR",".net CRM",".net 工作流","Viso","PowerDesigner","uml",
                ".net 项目经理","CTO","架构师",".net 主管",
            };
            foreach (var item in list)
            {
                dgv1.Rows.Add(item);
            }
        }




        private void 开始分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadPool.SetMinThreads(10, 1000);
            for (int i = 0; i < dgv1.RowCount - 1; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    int idx = Convert.ToInt32(obj);
                    for (int j = 1; j < dgv1.ColumnCount; j++)
                    {
                        string url = string.Format("http://search.51job.com/list/{0},%2B,%2B,%2B,%2B,%2B,{1},2,%2B.html?lang=c&stype=1",
                             dgv1.Columns[j].Name, HttpUtility.UrlEncode(dgv1[0, idx].Value.ToString(), Encoding.Default));
                        dgv1[j, idx].Value = Convert.ToInt32(HttpClient.Get(url).GetOne("jobid_count.+?(\\d+)"));
                    }


                }, i);
            }


        }


        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                string url = string.Format("http://search.51job.com/list/{0},%2B,%2B,%2B,%2B,%2B,{1},2,%2B.html?lang=c&stype=1",
                             dgv1.Columns[e.ColumnIndex].Name, HttpUtility.UrlEncode(dgv1[0, e.RowIndex].Value.ToString(), Encoding.Default));
                System.Diagnostics.Process.Start("Iexplore.exe", url);
            }
        }

        private void job全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadColumnsFrom51job();
        }

        private void 精选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadColumns();
        }

        void LoadColumns()
        {
            dgv1.Columns.Clear();
            //dgv1.Columns.Add("0000", "关键词");
            //dgv1.Columns.Add("0400", "深圳");
            //dgv1.Columns.Add("0302", "广州");
            //dgv1.Columns.Add("0100", "北京");
            //dgv1.Columns.Add("0200", "上海");

            dgv1.Columns.Add("0000", "关键词");
            dgv1.Columns.Add(MakeLinkColumn("0400", "深圳"));
            dgv1.Columns.Add(MakeLinkColumn("0302", "广州"));
            dgv1.Columns.Add(MakeLinkColumn("0100", "北京"));
            dgv1.Columns.Add(MakeLinkColumn("0200", "上海"));



            for (int i = 1; i < dgv1.ColumnCount; i++)
            {
                dgv1.Columns[i].ValueType = typeof(int);
                //dgv1.Columns[i].Width = 55;
            }
        }


        void LoadColumnsFrom51job()
        {

            dgv1.Columns.Clear();
            dgv1.Columns.Add("0000", "关键词");

            string body = HttpClient.Get("http://www.51job.com/default.php").GetOne("areacname", "clearboth");
            if (body == null)
            {
                MessageBox.Show("连不上51job");
                return;
            }
            foreach (Match item in Regex.Matches(body, "area=(?<area>\\d+)\">(?<cnt>\\S+)</a>"))
            {
                dgv1.Columns.Add(item.Groups["area"].Value, item.Groups["cnt"].Value);
            }

            for (int i = 1; i < dgv1.ColumnCount; i++)
            {
                dgv1.Columns[i].ValueType = typeof(int);
                dgv1.Columns[i].Width = 55;
            }
        }

        DataGridViewLinkColumn MakeLinkColumn(string name, string headText)
        {
            DataGridViewLinkColumn dg = new DataGridViewLinkColumn();
            dg.Name = name;
            dg.HeaderText = headText;
            return dg;
        }

        private void 加载从文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.txt|文本文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] str = File.ReadAllLines(dlg.FileName);
                foreach (var item in str)
                {
                    dgv1.Rows.Add(item);
                }
            }
        }

        private void 保存到文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.txt|文本文件";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string[] ok = new string[dgv1.RowCount];
                for (int i = 0; i < dgv1.RowCount - 1; i++)
                {
                    ok[i] = dgv1[0, i].Value.ToString();
                }
                File.WriteAllLines(dlg.FileName, ok); ;
            }
        }

    }

}
