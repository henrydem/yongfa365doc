using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewDemo
{
    public partial class TreeViewForRolesDemo : Form
    {
        public TreeViewForRolesDemo()
        {
            InitializeComponent();
        }

        private void TreeViewForRolesDemo_Load(object sender, EventArgs e)
        {
            treeViewForRoles1.Fill(DBMaker.GetCity(), "ParentId=0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>("1,3,10,11".Split(','));
            treeViewForRoles1.Value = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = treeViewForRoles1.Value;

            MessageBox.Show(string.Join(",", list.ToArray()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataView dv = DBMaker.GetCity().DefaultView;
            StringBuilder sb = new StringBuilder();
            foreach (var item in treeViewForRoles1.Value)
            {
                sb.AppendFormat(" or Id = {0}", item);
            }
            dv.RowFilter = "1=2 " + sb.ToString();

            treeViewForRoles1.Fill(dv.ToTable(), "ParentId=0", treeView1);

        }
    }
}
