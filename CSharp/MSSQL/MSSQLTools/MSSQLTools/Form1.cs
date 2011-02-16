using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ApplicationBlocks.Data;

namespace MSSQLTools
{
    public partial class Form1 : Form
    {
        private readonly string sql = @"
SELECT  db.name  Name,
        dbfile.groupid ID,
        dbfile.name LName 
FROM    master..sysdatabases db
        RIGHT JOIN master..sysaltfiles dbfile ON db.dbid = dbfile.dbid
";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string strBackUp = "";
            string strRestore = "";
            string strBroker = "";

            var ds = SqlHelper.ExecuteDataset(cbxConn.Text, CommandType.Text, sql, null);
            var data = new List<DATA>();
            foreach (DataRowView item in ds.Tables[0].DefaultView)
            {
                data.Add(new DATA()
                {
                    ID = item["ID"].ToString(),
                    Name = item["Name"].ToString(),
                    LName = item["LName"].ToString(),
                });
            }
            var query = data.GroupBy(p => p.Name);
            var lstDBName = new List<string>(cbxdbName.Text.Trim().Split('|'));
            foreach (var item in query)
            {
                if (!lstDBName.Contains(item.Key))
                {
                    continue;
                }
                string bak = string.Format(@"E:\DataBackup\DevDBInstance\Manual\{1}.{0}.bak", item.Key, strDate);
                strBackUp += "\r\n" + string.Format(@"backup database {0} to disk='{1}'", item.Key, bak);
                strRestore += "\r\n\r\n" + string.Format(@"RESTORE DATABASE {0} FROM DISK = '{1}' WITH ", item.Key, bak);
                strBroker += "\r\n" + string.Format("ALTER DATABASE {0} SET ENABLE_BROKER;", item.Key);
                
                foreach (var item2 in item)
                {
                    strRestore += "\r\n" + string.Format(@"MOVE '{0}' TO 'D:\Data\MSSQL10_50.TESTDBINSTANCE\MSSQL\DATA\{1}',", item2.LName, item2.ID == "1" ? item.Key + ".mdf" : item.Key + "_Log.ldf");
                }
                strRestore += " STATS = 10, REPLACE\n\n\n";
            }

            txtOK.Text = strBackUp + "\r\n\r\n\r\n\r\n" + strRestore + "\r\n\r\n\r\n\r\n" + strBroker;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxConn.SelectedIndex = 0;
            cbxdbName.SelectedIndex = 0;
        }


    }


    public class DATA
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
    }
}
