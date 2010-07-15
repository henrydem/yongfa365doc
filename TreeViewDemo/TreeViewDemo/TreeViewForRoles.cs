using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YongFa365.Winform.UserControls
{
    public partial class TreeViewForRoles : UserControl
    {

        List<string> _value;
        public List<string> Value
        {
            get
            {
                _value.Clear();
                GetChecked(treeView1.Nodes);
                return _value;
            }
            set
            {
                Checked(treeView1.Nodes,value);
            }
        }



        public TreeViewForRoles()
        {
            InitializeComponent();
            _value = new List<string>();
        }

        private void Checked(TreeNodeCollection nodes,List<string> list)
        {
            foreach (TreeNode item in nodes)
            {
                if (list.Contains(item.Tag.ToString()))
                {
                    item.Checked = true;
                }
                Checked(item.Nodes,list);
            }

        }


        private void GetChecked(TreeNodeCollection nodes)
        {
            foreach (TreeNode item in nodes)
            {
                if (item.Checked)
                {
                    _value.Add(item.Tag.ToString());
                }
                GetChecked(item.Nodes);
            }
        }

        /// <summary>
        /// 填充Tree
        /// </summary>
        /// <param name="filterExpression">起始数据筛选方法如:"ParentId=0"</param>
        /// <param name="dt">格式，三列，Id,Name,ParentId,只要顺序一样就可以了</param>
        public void Fill(DataTable dt, string filterExpression)
        {
            Fill(dt, filterExpression, treeView1);

        }

        /// <summary>
        /// 填充Tree
        /// </summary>
        /// <param name="filterExpression">起始数据筛选方法如:"ParentId=0"</param>
        /// <param name="dt">格式，三列，Id,Name,ParentId,只要顺序一样就可以了</param>
        /// <param name="treeview">TreeView</param>
        public void Fill(DataTable dt, string filterExpression, TreeView treeview)
        {
            treeview.Nodes.Clear();
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



        private void treeView1_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node);
                CheckAllParentNodes(e.Node);
            }
        }


        private void CheckAllChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = treeNode.Checked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node);
                }
            }
        }


        private void CheckAllParentNodes(TreeNode treeNode)
        {
            TreeNode node = treeNode;

            if (node.Checked)
            {
                while (node.Parent != null)
                {
                    node.Parent.Checked = true;
                    node = node.Parent;
                }
            }
            else
            {
                while (node.Parent != null)
                {
                    node = node.Parent;
                    node.Checked = false;
                    foreach (TreeNode item in node.Nodes)
                    {
                        if (item.Checked)
                        {
                            node.Checked = true;
                            break;
                        }
                    }
                    CheckAllParentNodes(node);
                }
            }
        }
    }
}
