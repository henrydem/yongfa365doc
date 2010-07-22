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
    public partial class ComboboxTreeDemo : Form
    {
        public ComboboxTreeDemo()
        {
            InitializeComponent();
        }

        private void ComboboxTreeDemo_Load(object sender, EventArgs e)
        {
            comboboxTree1.Fill(DBMaker.GetCity(), "ParentId=0");
            comboBoxTree2.Fill(DBMaker.GetCity(), "ParentId=0");
        }
    }
}
