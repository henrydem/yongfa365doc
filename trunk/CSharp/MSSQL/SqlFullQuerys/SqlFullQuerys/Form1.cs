using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace SqlFullQuerys
{
    public partial class Form1 : Form
    {
        string sqlconnectionstring = "";
        public Form1()
        {
            InitializeComponent();
        }

        void FillConn()
        {
            if (checkBox2.Checked)
            {
                sqlconnectionstring = "Data Source="+textBox1.Text+";Initial Catalog=master;Integrated Security=True";
            }
            else
            {
        sqlconnectionstring = "Data Source =" +
                this.textBox1.Text + ";User ID=" +
                this.textBox2.Text + ";Password=" +
                this.textBox3.Text + ";initial Catalog=" +
                "master" ;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillConn();
            this.comboBox1.Items.Clear();
            try
            {
                using (SqlConnection mycon = new SqlConnection(sqlconnectionstring))
                {
                    SqlCommand mycmd = mycon.CreateCommand();
                    mycmd.CommandText = "select name from sys.databases ";
                    SqlDataAdapter myda = new SqlDataAdapter(mycmd);
                    DataTable dt = new DataTable();
                    myda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.comboBox1.Items.Add(dr[0].ToString());
                    }
                }

                this.button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int commandcount = 0;
            FillConn();

            string ftext = this.textBox4.Text;

            if (ftext == "")
                return;

            string sqlcmdstring = "";
            Hashtable htsqlcmds = new Hashtable();

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

                sqlcmdstring = "select name from sys.columns where object_id=(select object_id from sys.tables where name='"+dr[0].ToString()+"')";
                try
                {
                    //using (SqlConnection mycon = new SqlConnection(sqlconnectionstring))
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
                        SetProcess("收集SQL语句: 表[" + dr[0].ToString() + "] - 列[" + mydr[0].ToString() + "]");
                        commandcount++;
                        string sqlcmd;
                        if (!checkBox1.Checked)
                            sqlcmd = "SELECT " + mydr[0].ToString() + " FROM [" + dr[0].ToString() +
                                "] WHERE " + mydr[0].ToString() + " = N'" + ftext + "'";
                        else
                            sqlcmd = "SELECT " + mydr[0].ToString() + " FROM [" + dr[0].ToString() +
                                "] WHERE " + mydr[0].ToString() + " like N'%" + ftext + "%'";

                        htsqlcmds.Add(commandcount, sqlcmd);

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

            DataTable dtresult=new DataTable();
            dtresult.Columns.Add("sqlcommand");

            cur = 1;
            foreach (DictionaryEntry de in htsqlcmds)
            {
                Application.DoEvents();
                GC.Collect();

                SetProcess(cur, commandcount);
                cur++;
                SetProcess("执行SQL语句: "+de.Value.ToString());
                try {
                    //using (SqlConnection mycon = new SqlConnection(sqlcmdstring))
                    {
                        mycmd.CommandText = de.Value.ToString();

                        SqlDataReader mydr = mycmd.ExecuteReader();

                        //bool rb = mydr.Read();
                        //if (rb)
                        if(mydr.HasRows)
                        {
                            DataRow dnew = dtresult.NewRow();
                            dnew[0] = de.Value.ToString();
                            dtresult.Rows.Add(dnew);

                            this.dataGridView1.DataSource = dtresult;

                            this.dataGridView1.AutoResizeColumns();
                            //for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                            //{
                            //    this.dataGridView1.Rows[i].Selected = false;
                            //}
                            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Selected = true;
                    
                        }

                        mydr.Close();
                    }
                }
                catch
                {
                    continue;
                }
            }
            
            #endregion

            myconn.Close();

            MessageBox.Show("Ok!");
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

        private void SetProcess(string msg)
        {
            this.label7.Text = msg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            button3_Click(sender, e);
        }
    }
}