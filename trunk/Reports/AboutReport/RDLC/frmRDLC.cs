using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace AboutReport.RDLC
{
    public partial class frmRDLC : Form
    {
        public frmRDLC()
        {
            InitializeComponent();
        }

        private void frmRDLC_Load(object sender, EventArgs e)
        {

        }

        private void btnByParam_Click(object sender, EventArgs e)
        {
            reportViewer1.Reset();

            List<ReportParameter> list = new List<ReportParameter>();
            list.Add(new ReportParameter("txtTitle", "RDLC参数测试"));
            list.Add(new ReportParameter("txtContent", "测试内容".PadRight(10000, '=')));

            //命名空间.文件名.rdlc
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptParam.rdlc";
            //reportViewer1.LocalReport.ReportPath = "rptParam.rdlc";

            reportViewer1.LocalReport.SetParameters(list);
            reportViewer1.RefreshReport();
        }

        private void btnByDataSet_Click(object sender, EventArgs e)
        {


            DataTable dt = DBMaker.文章表();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            //DataSet名_表名
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetArticles_Articles", dt));
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptDataSet.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btnCross_Click(object sender, EventArgs e)
        {


            DataTable dt = DBMaker.学生成绩表();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetScore_学生成绩", dt));
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptCross.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {


            DataTable dt = DBMaker.学生成绩表();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetScore_学生成绩", dt));
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptChart.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {

            DataTable dt = DBMaker.学生成绩表();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetScore_学生成绩", dt));
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptGroup.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btnParentChild_Click(object sender, EventArgs e)
        {
            reportViewer1.Reset();

            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptParent.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetStudent_班级", DBMaker.班级表()));
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            this.reportViewer1.RefreshReport();
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("DataSetStudent_学生", DBMaker.学生表()));
        }


        private void btnList_Click(object sender, EventArgs e)
        {

            DataTable dt = DBMaker.人员表();

            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetOffice_人员表", dt));
            reportViewer1.LocalReport.ReportEmbeddedResource = "AboutReport.RDLC.rptList.rdlc";
            reportViewer1.RefreshReport();
        }
    }
}
