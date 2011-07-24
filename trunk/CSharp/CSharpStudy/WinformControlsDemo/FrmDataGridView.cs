using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformControlsDemo
{
    public partial class FrmDataGridView : Form
    {
        public FrmDataGridView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 生成DataGridView列 并设置
            {
                DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                col.HeaderText = "城市名称";
                col.Name = "城市名称";
                col.DataSource = DBMaker.GetCity();
                col.DisplayMember = "txtName";
                col.ValueMember = "Id";
                dgv1.Columns.Add(col);
            }
            #endregion

            #region 填充DataGridViewComboBoxColumn
            {
                DataGridViewComboBoxColumn col = dgv1.Columns[0] as DataGridViewComboBoxColumn;
                col.HeaderText = "城市名称";
                col.Name = "城市名称";
                col.DataSource = DBMaker.GetCity();
                col.DisplayMember = "txtName";
                col.ValueMember = "Id";
            }
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv1[0, 0].Value = 11;
            dgv1[1, 0].Value = 2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = string.Format("FormattedValue:{0}  Value:{1}\n\nFormattedValue:{2}  Value:{3}",
                dgv1[0, 0].FormattedValue, dgv1[0, 0].Value,
                dgv1[1, 0].FormattedValue, dgv1[1, 0].Value

                );
            MessageBox.Show(str);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv2.DataSource = DBMaker.GetCity();

            //禁止列排序
            for (int i = 0; i < dgv2.Columns.Count; i++)
            {
                dgv2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //锁定列头高
            dgv2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //锁定行头宽
            dgv2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            //设定行头宽
            dgv2.RowHeadersWidth = 30;

            //禁止调整行高
            dgv2.AllowUserToResizeRows = false;

            //禁止调整列高
            dgv2.AllowUserToResizeColumns = false;


        }

        private void dgv2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //在行头上添加数字
            using (SolidBrush b = new SolidBrush(dgv2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture),
                        dgv2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
