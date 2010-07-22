using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace AboutReport.CrystalReport
{
    public partial class frmCrystalReport : Form
    {
        public frmCrystalReport()
        {
            InitializeComponent();
        }

        private void frmCrystalReport_Load(object sender, EventArgs e)
        {

        }


        private void btnByParam_Click(object sender, EventArgs e)
        {
            //加载文件的方式
            //ReportDocument doc = new ReportDocument();
            ////设置报表文件为“始终复制”
            //doc.Load(@"CrystalReport\rptParam.rpt");

            rptParam doc = new rptParam();

            crystalReportViewer1.ParameterFieldInfo = new ParameterFields();
            doc.SetParameterValue("txtTitle", "水晶报表参数测试");
            doc.SetParameterValue("txtContent", "<font color=red>我是有色内容</font>".PadRight(10000, '='));

            //自定义参数添加方法，来自MSDN可能会用到
            //AddParameter("txtTitle", "水晶报表参数测试", crystalReportViewer1.ParameterFieldInfo);
            //AddParameter("txtContent", "<font color=red>我是有色内容</font>".PadRight(10000, '='), crystalReportViewer1.ParameterFieldInfo);

            crystalReportViewer1.ReportSource = doc;
        }

        private void btnByDataSet_Click(object sender, EventArgs e)
        {
            rptDataSet doc = new rptDataSet();

            DataTable dt = DBMaker.文章表();
            doc.SetDataSource(dt);
            crystalReportViewer1.ReportSource = doc;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            rptCross doc = new rptCross();
            DataTable dt = DBMaker.学生成绩表();
            doc.SetDataSource(dt);
            crystalReportViewer1.ReportSource = doc;
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            rptChart doc = new rptChart();
            DataTable dt = DBMaker.学生成绩表();
            doc.SetDataSource(dt);
            crystalReportViewer1.ReportSource = doc;
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            rptGroup doc = new rptGroup();
            DataTable dt = DBMaker.学生成绩表();
            doc.SetDataSource(dt);
            crystalReportViewer1.ReportSource = doc;
        }




        private ParameterFields AddParameter(string paramName, string paramValue, ParameterFields paramFields)
        {
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new
            ParameterDiscreteValue();
            ParameterValues paramValues = new ParameterValues();

            // 设置要修改的参数的名称。
            paramField.ParameterFieldName = paramName;

            // 为该参数设置一个值。
            paramDiscreteValue.Value = paramValue;
            paramValues.Add(paramDiscreteValue);
            paramField.CurrentValues = paramValues;

            // 将该参数添加到 ParameterFields 集合中。
            paramFields.Add(paramField);
            return paramFields;
        }

        private void btnParentChild_Click(object sender, EventArgs e)
        {
            rptParent doc = new rptParent();

            DataSet ds = new DataSet();
            ds.Tables.Add(DBMaker.班级表());
            ds.Tables.Add(DBMaker.学生表());

            ds.Tables[0].TableName = "班级";
            ds.Tables[1].TableName = "学生";



            doc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = doc;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            rptList doc = new rptList();
            DataTable dt = DBMaker.人员表();
            doc.SetDataSource(dt);
            crystalReportViewer1.ReportSource = doc;
        }






    }
}
