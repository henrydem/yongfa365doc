using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace TreeViewDemo
{
    public static class TreeViewExtensions
    {
        /// <summary>
        /// 填充Tree
        /// </summary>
        /// <param name="filterExpression">起始数据筛选方法如:"ParentId=0"</param>
        /// <param name="dt">格式，三列，Id,Name,ParentId,只要顺序一样就可以了</param>
        /// <param name="treeview">TreeView</param>
        public static void Fill(this TreeView treeview,DataTable dt, string filterExpression)
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

        private static void TraverseNode(TreeNode ParentNode, int ParentID, DataRowView ParentDV, DataTable dt)
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

    }
}
