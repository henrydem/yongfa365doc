using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace Windows服务器安全设置
{
    public partial class MSSQL : Form
    {

        public MSSQL()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            EventLog log = new EventLog("Application", ".", "MSSQLSERVER");
            Dictionary<string, Int32> dict = new Dictionary<string, Int32>();
            Regex re = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            foreach (EventLogEntry item in log.Entries)
            {
                if (item.Source != log.Source || item.EntryType != EventLogEntryType.FailureAudit)
                {
                    continue;
                }
                Match match = re.Match(item.Message);
                if (match.Success)
                {
                    if (dict.ContainsKey(match.Value))
                    {
                        dict[match.Value]++;
                    }
                    else
                    {
                        dict.Add(match.Value, 1);
                    }
                }

            }
            foreach (var item in dict)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
            }
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);

            MessageBox.Show("OK");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventLog log = new EventLog("Application", ".");
            log.Clear();
            MessageBox.Show("OK");
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(256);
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sb.AppendFormat("netsh ipsec static add filter filterlist=$filterlist$ srcaddr={0} dstaddr=Me dstport=0 protocol=ANY\n", dataGridView1[0, i].Value);
            }
            string sss = string.Format(@"
netsh ipsec static add policy name=$policy$

netsh ipsec static add filterlist name=$filterlist$

{0}

netsh ipsec static add filteraction name=$filteraction$ action=block

netsh ipsec static add rule name=$rule$ policy=$policy$ filterlist=$filterlist$ filteraction=$filteraction$

netsh ipsec static set policy name=$policy$ assign=y

", sb.ToString());

            richTextBox1.Text = sss
                .Replace("$filterlist$", txtFilterList.Text)
                .Replace("$policy$", txtPolicy.Text)
                .Replace("$filteraction$", txtFilterAction.Text)
                .Replace("$rule$", txtRule.Text)
                ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText=="")
            {
                richTextBox1.SelectAll();
            }
            File.WriteAllText("temp.cmd", richTextBox1.SelectedText.Replace("\n","\r\n"),Encoding.Default);
            Process.Start("temp.cmd");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            初始化();
        }

        void 初始化()
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                richTextBox1.Top -= panel1.Height;
                richTextBox1.Height += panel1.Height;
            }
            else
            {
                panel1.Visible = true;
                richTextBox1.Top += panel1.Height;
                richTextBox1.Height -= panel1.Height;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            初始化();

            try
            {
                DataSet ds = new DataSet("yongfa365");
                ds.ReadXml("ipsec.xml");
                txtFilterList.Text = ds.Tables[0].DefaultView[0]["filterlist"].ToString();
                txtPolicy.Text = ds.Tables[0].DefaultView[0]["policy"].ToString();
                txtFilterAction.Text = ds.Tables[0].DefaultView[0]["filteraction"].ToString();
                txtRule.Text = ds.Tables[0].DefaultView[0]["rule"].ToString();

            }
            catch 
            {

            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet("yongfa365");
           DataTable dt= ds.Tables.Add();
           dt.Columns.Add("filterlist");
           dt.Columns.Add("policy");
           dt.Columns.Add("filteraction");
           dt.Columns.Add("rule");

           dt.Rows.Add(txtFilterList.Text.Trim(), txtPolicy.Text.Trim(), txtFilterAction.Text.Trim(), txtRule.Text.Trim());
           ds.WriteXml("ipsec.xml");
           MessageBox.Show("OK");
        }
    }
}
