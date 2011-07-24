﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel=Microsoft.Office.Interop.Excel;
using System.Reflection;



namespace 体温记录及分析系统
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void 柳永法yongfa365BlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
          System.Diagnostics.Process.Start("Iexplore.exe", "http://www.yongfa365.com/");
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void BuildDGV()
        {

            OleDbBase.DB db = new OleDbBase.DB();
            DataSet ds = db.GetDataSet("select UserName,PutDateTime,TW,Weather from TW order by PutDateTime desc", "TW");
            dataGridView1.DataSource = ds.Tables["TW"];
            ds.Dispose();

        }
        private void 生成测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string tempstr="";
            OleDbBase.DB db = new OleDbBase.DB();
            Random rd = new Random();
            int tw = 0;
            DateTime d1 = DateTime.Parse(DateTime.Now.AddDays(-4).ToShortDateString() + " 06:00:00");
            for (int i = 0; i < 5; i++)
            {
                d1 = d1.AddDays(i);
                for (int ii = 0; ii < 18; ii++)
                {
                    d1 = d1.AddHours(ii);
                    switch (ii + 6)
                    {
                        case 6:
                        case 7:
                            tw = rd.Next(3);
                            break;

                        case 14:
                        case 15:
                            tw = rd.Next(2, 5);
                            break;
                        default:
                            tw = rd.Next(4, 8);
                            break;
                    }

                    tempstr+="insert into  TW (UserName,PutDateTime,Weather,TW) values ('柳永法',#" + d1 + "#,'晴',36." + tw + "0)" + "\r";
                    d1 = d1.AddHours(ii * (-1));
                }
                d1 = d1.AddDays(i * (-1));
            }
            db.Exec(tempstr.Split('\r'));
            BuildDGV();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Weather.SelectedIndex = 0;
            UserName.SelectedIndex = 0;
            //Weather.Items.Add("请选择天气");
            //Weather.SelectedIndex = Weather.Items.Count - 1;

            BuildDGV();
            this.Show();
            this.TW.Focus();

            SendKeys.Send("{RIGHT}+{LEFT}+{LEFT}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbBase.DB db = new OleDbBase.DB();
            db.Exec("insert into  TW (UserName,PutDateTime,Weather,TW) values ('" + UserName.Text + "',#" + PutDateTime.Value + "#,'" + Weather.Text + "'," + TW.Text + ")");
            BuildDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmAnalysis().Show();
        }

        private void 删除测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbBase.DB db = new OleDbBase.DB();
            db.Exec("delete * from TW");


            BuildDGV();
        }

        private void 体温记录分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAnalysis().Show();
        }

        private void 导出为ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewToExcel(dataGridView1);
           // DataGridViewExportToExcel(dataGridView1);
            //ExportDataGridview(dataGridView1, true);
        }

        #region DataGridView数据显示到Excel
        /// <summary> 
        /// 打开Excel并将DataGridView控件中数据导出到Excel
        /// </summary> 
        /// <param name="dgv">DataGridView对象 </param> 
        /// <param name="isShowExcle">是否显示Excel界面 </param> 
        /// <remarks>
        /// add com "Microsoft Excel 11.0 Object Library"
        /// using Excel=Microsoft.Office.Interop.Excel;
        /// </remarks>
        /// <returns> </returns> 
        public bool DataGridviewShowToExcel(DataGridView dgv, bool isShowExcle)
        {
            if (dgv.Rows.Count == 0)
                return false;
            //建立Excel对象 
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcle;
            //生成字段名称 
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }
            //填充数据 
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dgv[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = dgv[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }
        #endregion 

        #region DateGridView导出到csv格式的Excel
        /// <summary>
        /// 常用方法，列之间加\t，一行一行输出，此文件其实是csv文件，不过默认可以当Excel打开。
        /// </summary>
        /// <remarks>
        /// using System.IO;
        /// </remarks>
        /// <param name="dgv"></param>
        private void DataGridViewToExcel(DataGridView dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "\t";
                        }
                        columnTitle += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "\t";
                            }
                            if (dgv.Rows[j].Cells[k].Value == null)
                                columnValue += "";
                            else
                                columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        } 
        #endregion

        //#region DataGridView导出到Excel，有一定的判断性
        ///// <summary> 
        /////方法，导出DataGridView中的数据到Excel文件 
        ///// </summary> 
        ///// <remarks>
        ///// add com "Microsoft Excel 11.0 Object Library"
        ///// using Excel=Microsoft.Office.Interop.Excel;
        ///// using System.Reflection;
        ///// </remarks>
        ///// <param name= "dgv"> DataGridView </param> 
        //public static void DataGridViewToExcel(DataGridView dgv)
        //{


        //    #region   验证可操作性

        //    //申明保存对话框 
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    //默然文件后缀 
        //    dlg.DefaultExt = "xls ";
        //    //文件后缀列表 
        //    dlg.Filter = "EXCEL文件(*.XLS)|*.xls ";
        //    //默然路径是系统当前路径 
        //    dlg.InitialDirectory = Directory.GetCurrentDirectory();
        //    //打开保存对话框 
        //    if (dlg.ShowDialog() == DialogResult.Cancel) return;
        //    //返回文件路径 
        //    string fileNameString = dlg.FileName;
        //    //验证strFileName是否为空或值无效 
        //    if (fileNameString.Trim() == " ")
        //    { return; }
        //    //定义表格内数据的行数和列数 
        //    int rowscount = dgv.Rows.Count;
        //    int colscount = dgv.Columns.Count;
        //    //行数必须大于0 
        //    if (rowscount <= 0)
        //    {
        //        MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //列数必须大于0 
        //    if (colscount <= 0)
        //    {
        //        MessageBox.Show("没有数据可供保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //行数不可以大于65536 
        //    if (rowscount > 65536)
        //    {
        //        MessageBox.Show("数据记录数太多(最多不能超过65536条)，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //列数不可以大于255 
        //    if (colscount > 255)
        //    {
        //        MessageBox.Show("数据记录行数太多，不能保存 ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //验证以fileNameString命名的文件是否存在，如果存在删除它 
        //    FileInfo file = new FileInfo(fileNameString);
        //    if (file.Exists)
        //    {
        //        try
        //        {
        //            file.Delete();
        //        }
        //        catch (Exception error)
        //        {
        //            MessageBox.Show(error.Message, "删除失败 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    #endregion
        //    Excel.Application objExcel = null;
        //    Excel.Workbook objWorkbook = null;
        //    Excel.Worksheet objsheet = null;
        //    try
        //    {
        //        //申明对象 
        //        objExcel = new Microsoft.Office.Interop.Excel.Application();
        //        objWorkbook = objExcel.Workbooks.Add(Missing.Value);
        //        objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
        //        //设置EXCEL不可见 
        //        objExcel.Visible = false;

        //        //向Excel中写入表格的表头 
        //        int displayColumnsCount = 1;
        //        for (int i = 0; i <= dgv.ColumnCount - 1; i++)
        //        {
        //            if (dgv.Columns[i].Visible == true)
        //            {
        //                objExcel.Cells[1, displayColumnsCount] = dgv.Columns[i].HeaderText.Trim();
        //                displayColumnsCount++;
        //            }
        //        }
        //        //设置进度条 
        //        //tempProgressBar.Refresh(); 
        //        //tempProgressBar.Visible   =   true; 
        //        //tempProgressBar.Minimum=1; 
        //        //tempProgressBar.Maximum=dgv.RowCount; 
        //        //tempProgressBar.Step=1; 
        //        //向Excel中逐行逐列写入表格中的数据 
        //        for (int row = 0; row <= dgv.RowCount - 1; row++)
        //        {
        //            //tempProgressBar.PerformStep(); 

        //            displayColumnsCount = 1;
        //            for (int col = 0; col < colscount; col++)
        //            {
        //                if (dgv.Columns[col].Visible == true)
        //                {
        //                    try
        //                    {
        //                        objExcel.Cells[row + 2, displayColumnsCount] = dgv.Rows[row].Cells[col].Value.ToString().Trim();
        //                        displayColumnsCount++;
        //                    }
        //                    catch (Exception)
        //                    {

        //                    }

        //                }
        //            }
        //        }
        //        //隐藏进度条 
        //        //tempProgressBar.Visible   =   false; 
        //        //保存文件 
        //        objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
        //                Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
        //                Missing.Value, Missing.Value);
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    finally
        //    {
        //        //关闭Excel应用 
        //        if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
        //        if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
        //        if (objExcel != null) objExcel.Quit();

        //        objsheet = null;
        //        objWorkbook = null;
        //        objExcel = null;
        //    }
        //    MessageBox.Show(fileNameString + "\n\n导出完毕! ", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}

        //#endregion
    }
}