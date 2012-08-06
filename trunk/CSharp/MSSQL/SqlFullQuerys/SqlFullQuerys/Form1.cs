using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using System.Linq;
using System.Data.Linq;


namespace SqlFullQuerys
{


    public partial class Form1 : Form
    {
        string sqlconnectionstring = "";
        List<Info> Data = new List<Info>();


        public Form1()
        {
            InitializeComponent();
        }




        private void SetProcess(int cur, int max)
        {
            if (cur > max)
                max = cur;
            this.progressBar1.Maximum = max;
            this.progressBar1.Value = cur;

        }

        private void SetProcess2(int cur, int max)
        {
            if (cur > max)
                max = cur;
            this.progressBar2.Maximum = max;
            this.progressBar2.Value = cur;

        }

        private void SetProcess(string msg, string dbname)
        {
            this.label7.Text = msg;
            lblDBName.Text = dbname;
        }




        private void btnQuery_Click(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now.TimeOfDay;


            if (!cbxDBName.Text.StartsWith("0"))
            {
                Run(cbxDBName.Text);
            }
            else
            {
                var dbnames = cbxDBName.DataSource as List<string>;
                Data.Clear();
                dbnames.ForEach(p => Run(p));
            }


            MessageBox.Show("Ok!" + (DateTime.Now.TimeOfDay - t));
        }

        private void Run(string dbname)
        {
            txtLogs.Text = "";
            int commandcount = 0;
            sqlconnectionstring = "Data Source=" + txtDbInstance.Text + ";Initial Catalog=" + dbname + ";Integrated Security=True";


            string ftext = this.txtKey.Text;

            if (ftext == "")
                return;

            string sqlcmdstring = "";
            Dictionary<int, Info> htsqlcmds = new Dictionary<int, Info>();
            DataTable dttables = new DataTable();
            DataTable dtcolumns = new DataTable();

            sqlcmdstring = "select name from sys.tables";
            try
            {
                using (SqlConnection mycon = new SqlConnection(sqlconnectionstring))
                {
                    SqlCommand mycmd1 = mycon.CreateCommand();
                    mycmd1.CommandText = sqlcmdstring;
                    SqlDataAdapter myda = new SqlDataAdapter(mycmd1);
                    myda.Fill(dttables);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

            int tablescount = dttables.Rows.Count;

            int cur = 1;

            SqlConnection myconn = new SqlConnection(sqlconnectionstring);
            myconn.Open();
            SqlCommand mycmd = myconn.CreateCommand();
            mycmd.CommandTimeout = 0;
            #region prepare sql commands
            foreach (DataRow dr in dttables.Rows)
            {
                SetProcess(cur, tablescount);
                cur++;

                GC.Collect();

                sqlcmdstring = "select name from sys.columns where object_id=(select object_id from sys.tables where name='" + dr[0].ToString() + "')";
                try
                {
                    mycmd.CommandText = sqlcmdstring;
                    SqlDataReader mydr = mycmd.ExecuteReader();
                    int rcount = 100;
                    int cur1 = 1;
                    while (mydr.Read())
                    {
                        Application.DoEvents();

                        if (cur1 > rcount)
                            rcount += 100;

                        SetProcess2(cur1, rcount);
                        cur1++;
                        SetProcess("收集SQL语句: 表[" + dr[0].ToString() + "] - 列[" + mydr[0].ToString() + "]", dbname);
                        commandcount++;
                        string sqlcmd;
                        if (!chkLike.Checked)
                            sqlcmd = string.Format("select [{0}] from [{1}].dbo.[{2}] where {0} = N'%{3}%'", mydr[0], dbname, dr[0], ftext);
                        else
                            sqlcmd = string.Format("select [{0}] from [{1}].dbo.[{2}] where {0} like N'%{3}%'", mydr[0], dbname, dr[0], ftext);

                        htsqlcmds.Add(commandcount, new Info { FieldName = mydr[0].ToString(), Query = sqlcmd });

                    }
                    mydr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                }
            }
            #endregion

            SetProcess2(100, 100);

            #region Excute commands


            cur = 1;
            txtLogs.Text += string.Format("========================{0}========================\r\n", dbname);
            foreach (var item in htsqlcmds)
            {
                Application.DoEvents();
                GC.Collect();

                SetProcess(cur, commandcount);
                cur++;
                string msg = item.Value.Query;
                SetProcess(msg, dbname);
                txtLogs.Text+=string.Format("\r\n{0}", msg);

                try
                {

                    mycmd.CommandText = item.Value.Query;

                    SqlDataReader mydr = mycmd.ExecuteReader();

                    if (mydr.HasRows)
                    {
                        Data.Add(new Info { DBName = dbname, FieldName = item.Value.FieldName, Query = item.Value.Query });
                        Fill();
                    }

                    mydr.Close();

                }
                catch
                {
                    continue;
                }
            }

            #endregion

            myconn.Close();
        }

        private void Fill()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Data;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.AutoResizeColumns();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (chkUseWindows.Checked)
            {
                sqlconnectionstring = string.Format("Data Source={0};Initial Catalog=master;Integrated Security=True"
                    , txtDbInstance.Text);
            }
            else
            {
                sqlconnectionstring = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}"
                    , txtDbInstance.Text.Trim()
                    , txtDBName.Text.Trim()
                    , txtUserName.Text.Trim()
                    , txtPassword.Text.Trim()
                    );
            }

            this.cbxDBName.Items.Clear();
            try
            {
                using (SqlConnection mycon = new SqlConnection(sqlconnectionstring))
                {
                    SqlCommand mycmd = mycon.CreateCommand();
                    mycmd.CommandText = "select name from sys.databases ";
                    SqlDataAdapter myda = new SqlDataAdapter(mycmd);
                    DataTable dt = new DataTable();
                    myda.Fill(dt);
                    List<string> lst = new List<string>();
                    lst.Add("0.全部");
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Add(dr[0].ToString());

                    }
                    lst.Sort();
                    this.cbxDBName.DataSource = lst;
                }

                this.btnLogin.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void chkUseWindows_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            txtUserName.ReadOnly = txtPassword.ReadOnly = txtDBName.ReadOnly = chk.Checked;
        }

    }
    public class Info
    {
        public string DBName { get; set; }
        public string FieldName { get; set; }
        public string Query { get; set; }
    }

}