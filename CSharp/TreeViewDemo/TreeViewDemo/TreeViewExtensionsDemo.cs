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
    public partial class TreeViewExtensionsDemo : Form
    {
        public TreeViewExtensionsDemo()
        {
            InitializeComponent();
        }

        private void TreeViewExtensionsDemo_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Fill(DBMaker.GetCity(), "ParentId=0");
        }


    }
}
