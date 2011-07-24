using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Owc11;


namespace 体温记录及分析系统
{
    public partial class frmAnalysis : Form
    {
        public frmAnalysis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "1999-01-01";
            string str2 = str;
            string str3 = "";
            OleDbBase.DB db = new OleDbBase.DB();
            OleDbDataReader reader = db.Read("select PutDateTime,TW from TW where PutDateTime>= #" + this.dtp1.Value.ToShortDateString() + " 00:00:00# and PutDateTime<= #" + this.dtp2.Value.ToShortDateString() + " 23:59:59# and UserName='" + this.UserName.Text + "' order by PutDateTime");
            while (reader.Read())
            {
                str2 = DateTime.Parse(reader[0].ToString()).ToString("yyyy-MM-dd");
                if (str != str2)
                {
                    str3 = str3 + ",";
                    str = str2;
                }
                str3 = str3 + reader[1].ToString() + "\t";
            }
            reader.Close();
            ChartSpace space = new ChartSpaceClass();

            ChChart chart = space.Charts.Add(0);
            string str6 = "6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24";
            str6 = str6.Replace(" ", "时\t");
            string[] strArray = str3.Split(',');

            switch (cboStyle.Text)
            {
                case "chChartTypeSmoothLine":
                    chart.Type = ChartChartTypeEnum.chChartTypeSmoothLine;
                    break;
                case "chChartTypeColumnClustered3D":
                    chart.Type = ChartChartTypeEnum.chChartTypeColumnClustered3D;
                    break;

                default:
                    chart.Type = ChartChartTypeEnum.chChartTypeLine;
                    break;
            }
            //chart.Type = ChartChartTypeEnum.chChartTypeSmoothLine;
            chart.HasTitle = true;
            chart.Title.Caption = "体温变化曲线";

            //给定x,y轴图示说明
            chart.Axes[0].HasTitle = true;
            chart.Axes[0].Title.Caption = "测试时间";

            chart.Axes[1].HasTitle = true;
            chart.Axes[1].Title.Caption = "体温";

            chart.SetData(ChartDimensionsEnum.chDimCategories, (int)ChartSpecialDataSourcesEnum.chDataLiteral, str6);
            for (int i = 1; i < strArray.Length; i++)
            {
                chart.SeriesCollection.Add(i).SetData(ChartDimensionsEnum.chDimValues, (int)ChartSpecialDataSourcesEnum.chDataLiteral, strArray[i]);
            }
            space.ExportPicture("OK.gif", "gif", 760, 500);
            this.pictureBox1.ImageLocation = "OK.gif";
        }

        private void frmAnalysis_Load(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now.AddDays(-6);
            UserName.SelectedIndex = 0;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string sql = "";
            //double tw = 36.40;
            //OleDbBase.DB db = new OleDbBase.DB();
            //OleDbDataReader reader;
            //for (int i = 0; i < 6; i++)
            //{
            //    string nowDate = DateTime.Now.AddDays(i * (-1)).ToShortDateString();
            //    for (int ii = 6; ii < 22; ii++)
            //    {
            //        sql = "select * from TW where datevalue(PutDateTime)>= #" + nowDate + "# and hour(PutDateTime)= " + i.ToString() + " and UserName='" + this.UserName.Text + "' order by PutDateTime";
            //        reader = db.Read(sql);
            //        if (!reader.HasRows)
            //        {
            //            db.Exec("insert into  TW (UserName,PutDateTime,Weather,TW) values ('" + UserName.Text + "',#" + nowDate + " " + i.ToString() + ":44:44#,'晴'," + tw + ")");
            //        }

            //    }
            //}

        }
    }
}