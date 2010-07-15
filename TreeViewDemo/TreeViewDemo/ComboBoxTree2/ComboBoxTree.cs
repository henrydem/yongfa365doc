using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace YongFa365.Winform.UserControls
{
    public partial class ComboBoxTree : UserControl
    {
        public ComboBoxTree()
        {
            InitializeComponent();
        }

        private Size _size;
        private int _value=-1;

        #region 通过属性选择器给Text及Value赋值
        [Browsable(true), Category("ComboboxTree"), Description("获取或设置Value"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }


        [Browsable(true), Category("ComboboxTree"), Description("获取或设置Text"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        } 
        #endregion

        #region 各种事件
        private void ComboboxTree_Load(object sender, EventArgs e)
        {
            _size = this.Size = comboBox1.Size;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            treeView1.Select();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
            {
                return;
            }
            this.Value = Convert.ToInt32(treeView1.SelectedNode.Tag);
            comboBox1.Text = this.Text = treeView1.SelectedNode.Text;

            treeView1.Visible = false;
            this.Size = _size;
            this.SendToBack();
        }

        private void treeView1_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Size = new Size(200, 200);
            treeView1.Visible = true;
        }

        private void ComboboxTree_Leave(object sender, EventArgs e)
        {
            this.Size = _size;
            treeView1.Visible = false;
            this.SendToBack();
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            this.Size = _size;
        } 

        #endregion



        #region 填充Tree

        /// <summary>
        /// 填充Tree
        /// </summary>
        /// <param name="filterExpression">起始数据筛选方法如:"ParentId=0"</param>
        /// <param name="dt">格式，三列，Id,Name,ParentId,只要顺序一样就可以了</param>
        public void Fill(DataTable dt, string filterExpression)
        {
            TreeView treeview = treeView1;
            treeview.Nodes.Clear();

            //每个树的最上边添加一个：==请选择==
            TreeNode Node0 = new TreeNode();
            Node0.Text = "==请选择==";
            Node0.Tag = -1;
            treeview.Nodes.Add(Node0);

            DataTable temptbl = dt.Copy();
            DataView viewinfo = new DataView(temptbl);
            viewinfo.RowFilter = filterExpression;

            if (viewinfo.Count > 0)
            {
                foreach (DataRowView myRow in viewinfo)
                {
                    TreeNode Node1 = new TreeNode();
                    Node1.Text = myRow[1].ToString();
                    Node1.Tag = myRow[0];
                    treeview.Nodes.Add(Node1);
                    TraverseNode(Node1, Convert.ToInt32(myRow[0]), myRow, dt);
                }
            }

            if (treeview.Nodes.Count > 0)
            {
                treeview.ExpandAll();
            }

        }

        private void TraverseNode(TreeNode ParentNode, int ParentID, DataRowView ParentDV, DataTable dt)
        {
            DataTable temptbl = dt.Copy();
            DataView viewinfo = new DataView(temptbl);
            viewinfo.RowFilter = temptbl.Columns[2].ColumnName + " = " + ParentID;
            foreach (DataRowView myRow in viewinfo)
            {
                TreeNode myNode = new TreeNode();
                myNode.Text = myRow[1].ToString();
                myNode.Tag = myRow[0];
                ParentNode.Nodes.Add(myNode);
                TraverseNode(myNode, Convert.ToInt32(myRow[0]), myRow, dt);
            }
        }
        
        #endregion
    }
}
