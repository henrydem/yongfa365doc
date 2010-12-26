using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace YongFa365.Winform
{
    public static class WinformExtensions
    {
        #region DataGridViewExtensions
        /// <summary>
        /// 获取 dgv.CurrentRow 中columnName列的值
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="dgv"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static T GetValue<T>(this DataGridView dgv, string columnName)
        {
            return (T)dgv[columnName, dgv.CurrentRow.Index].Value;
        }

        /// <summary>
        /// 获取 dgv.CurrentRow 中columnName列的值
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="dgv"></param>
        /// <param name="columnIndex">列索引</param>
        /// <returns></returns>
        public static T GetValue<T>(this DataGridView dgv, int columnIndex)
        {
            return (T)dgv[columnIndex, dgv.CurrentRow.Index].Value;
        }

        /// <summary>
        /// DataGridView 转为 DataTable
        /// 原理：dgv.DataSource as DataTable 或 遍历赋值
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this DataGridView dgv)
        {
            DataTable dt = null;
            dt = dgv.DataSource as DataTable;
            if (dt != null)
            {
                return dt;
            }
            else
            {
                dt = new DataTable();
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    dt.Columns.Add(dgv.Columns[i].HeaderText, dgv.Columns[i].ValueType);
                }

                int rowCount = dgv.AllowUserToAddRows ? dgv.Rows.Count - 1 : dgv.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        dr[j] = dgv.Rows[i].Cells[j].Value;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }
        #endregion

        #region ComboBoxExtensions

        public static void SelectedByValue(this ComboBox cbx, object obj)
        {
            if (cbx.DataSource == null)
            {
                //非绑定时
                cbx.SelectedItem = obj;
            }
            else
            {
                object preValue = cbx.SelectedValue;
                //绑定时直接查找
                cbx.SelectedValue = obj;
                if (cbx.SelectedValue == null)
                {
                    //查不到保持原控件值不变
                    cbx.SelectedValue = preValue;
                }
            }
        }

        public static void SelectedByText(this ComboBox cbx, object obj)
        {
            if (cbx.DataSource == null)
            {
                //非绑定时
                cbx.SelectedItem = obj;
            }
            else
            {
                //绑定时
                cbx.Text = obj.ToString();
            }
        }

        /// <summary>
        /// 填充并选中
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="dt">
        /// 前两列及顺序满足 value,text就可以，字段名不必与示例相同
        /// "select ID=-1,txtName='==请选择==' union select Id,txtName from SysPara where ParentId={0} order by id
        /// </param>
        /// <param name="selectedValue">选中的value</param>
        public static void Fill(this ComboBox cbx, DataTable dt, string selectedValue)
        {
            cbx.DataSource = dt;
            cbx.DisplayMember = dt.Columns[1].ColumnName;
            cbx.ValueMember = dt.Columns[0].ColumnName;
            cbx.SelectedByValue(selectedValue);
        }

        /// <summary>
        /// 填充数字
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="startIndex">开始数字</param>
        /// <param name="endIndex">结束数字</param>
        /// <param name="defaultString">默认选中的数字字符</param>
        public static void Fill(this ComboBox cbx, int startIndex, int endIndex, string defaultString)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                cbx.Items.Add(i.ToString());
            }
            cbx.SelectedByValue(defaultString);
        }


        public static void FillCityDemo(this ComboBox cbx, object valuestr)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("txtName", typeof(string)));
            dt.Columns.Add(new DataColumn("ParentId", typeof(int)));
            dt.Rows.Add(1, "北京", 0);
            dt.Rows.Add(2, "山西", 0);

            dt.Rows.Add(3, "朝阳区", 1);
            dt.Rows.Add(4, "海淀区", 1);

            dt.Rows.Add(5, "豆各庄", 3);
            dt.Rows.Add(6, "十里堡", 3);
            dt.Rows.Add(7, "中关村", 4);

            dt.Rows.Add(8, "运城地区", 2);
            dt.Rows.Add(9, "太原市", 2);
            dt.Rows.Add(10, "永济市", 8);
            dt.Rows.Add(11, "西文学", 10);
            dt.Rows.Add(12, "东文学", 10);
            dt.Rows.Add(13, "南文学", 10);

            cbx.FillTree(dt, "Parentid=0", valuestr);
        }
        /// <summary>
        /// 填充并选中树
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="dt">前三列顺序要满足Id,Name,ParentId，字段名不必与示例相同</param>
        /// <param name="filterExpression">过滤表达式，如："ParentId=0"</param>
        /// <param name="selectedValue">选中的value</param>
        public static void FillTree(this ComboBox cbx, DataTable dt, string filterExpression, object selectedValue)
        {
            DataTable dtOK = dt.Clone();
            DataRow[] rows = dt.Select(filterExpression);
            foreach (DataRow row in rows)
            {
                SubTree(dt, ref dtOK, row, string.Empty);
            }

            cbx.DataSource = dtOK;
            cbx.DisplayMember = dtOK.Columns[1].ColumnName;
            cbx.ValueMember = dtOK.Columns[0].ColumnName;

            cbx.DropDownWidth = 100;
            cbx.SelectedByValue(selectedValue);
        }

        private static void SubTree(DataTable dt, ref DataTable dtOK, DataRow parentRow, string curHeader)
        {
            dtOK.Rows.Add(parentRow[0], curHeader + parentRow[1]);
            DataRow[] rows = dt.Select(string.Format("[{0}]='{1}'", dt.Columns[2].ColumnName, parentRow[0]));
            parentRow.Delete();

            for (int i = 0; i < rows.Length - 1; i++)
            {
                SubTree(dt, ref dtOK, rows[i], curHeader + "  ");
            }

            if (rows.Length > 0)
            {
                SubTree(dt, ref dtOK, rows[rows.Length - 1], curHeader + "  ");
            }
        }


        ///// <summary>
        ///// 填充并选中树
        ///// </summary>
        ///// <param name="cbx"></param>
        ///// <param name="dt">前三列顺序要满足Id,Name,ParentId，字段名不必与示例相同</param>
        ///// <param name="filterExpression">过滤表达式，如："ParentId=0"</param>
        ///// <param name="selectedValue">选中的value</param>
        //public static void FillTree(this ComboBox cbx, DataTable dt, string filterExpression, object selectedValue)
        //{
        //    Dictionary<object, object> allItems = new Dictionary<object, object>();
        //    DataRow[] rows = dt.Select(filterExpression);
        //    foreach (DataRow row in rows)
        //    {
        //        SubTree(dt, ref   allItems, row, string.Empty);
        //    }

        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = allItems;

        //    cbx.DataSource = bs;
        //    cbx.DisplayMember = "Key";
        //    cbx.ValueMember = "Value";

        //    cbx.DropDownWidth = 200;
        //    cbx.SelectedByValue(selectedValue);
        //}

        //private static void SubTree(DataTable dt, ref   Dictionary<object, object> items, DataRow parentRow, string curHeader)
        //{
        //    items.Add(curHeader + parentRow[1], parentRow[0]);
        //    DataRow[] rows = dt.Select(string.Format("[{0}]='{1}'", dt.Columns[2].ColumnName, parentRow[0]));
        //    parentRow.Delete();

        //    for (int i = 0; i < rows.Length - 1; i++)
        //    {
        //        SubTree(dt, ref items, rows[i], curHeader + "  ");
        //    }

        //    if (rows.Length > 0)
        //    {
        //        SubTree(dt, ref items, rows[rows.Length - 1], curHeader + "  ");
        //    }
        //} 
        #endregion

        /// <summary>
        /// DataTable 行列互换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DataTable Pivot(this DataTable input)
        {
            DataTable output = new DataTable();

            //标题的位置不变
            output.Columns.Add(input.Columns[0].ColumnName.ToString());

            foreach (DataRow item in input.Rows)
            {
                string newColName = item[0].ToString();
                output.Columns.Add(newColName);
            }

            for (int i = 1; i <= input.Columns.Count - 1; i++)
            {
                DataRow newRow = output.NewRow();

                newRow[0] = input.Columns[i].ColumnName.ToString();
                for (int j = 0; j <= input.Rows.Count - 1; j++)
                {
                    string colValue = input.Rows[j][i].ToString();
                    newRow[j + 1] = colValue;
                }
                output.Rows.Add(newRow);
            }
            return output;
        }
    }
}
