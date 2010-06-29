namespace AboutReport.CrystalReport
{
    partial class frmCrystalReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnChart = new System.Windows.Forms.Button();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnByDataSet = new System.Windows.Forms.Button();
            this.btnByParam = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnParentChild = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(343, 12);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(75, 23);
            this.btnChart.TabIndex = 7;
            this.btnChart.Text = "图表报表";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // btnCross
            // 
            this.btnCross.Location = new System.Drawing.Point(246, 12);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(75, 23);
            this.btnCross.TabIndex = 6;
            this.btnCross.Text = "交叉报表";
            this.btnCross.UseVisualStyleBackColor = true;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnByDataSet
            // 
            this.btnByDataSet.Location = new System.Drawing.Point(126, 12);
            this.btnByDataSet.Name = "btnByDataSet";
            this.btnByDataSet.Size = new System.Drawing.Size(98, 23);
            this.btnByDataSet.TabIndex = 5;
            this.btnByDataSet.Text = "DataSet加载";
            this.btnByDataSet.UseVisualStyleBackColor = true;
            this.btnByDataSet.Click += new System.EventHandler(this.btnByDataSet_Click);
            // 
            // btnByParam
            // 
            this.btnByParam.Location = new System.Drawing.Point(29, 12);
            this.btnByParam.Name = "btnByParam";
            this.btnByParam.Size = new System.Drawing.Size(75, 23);
            this.btnByParam.TabIndex = 4;
            this.btnByParam.Text = "参数加载";
            this.btnByParam.UseVisualStyleBackColor = true;
            this.btnByParam.Click += new System.EventHandler(this.btnByParam_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Location = new System.Drawing.Point(1, 41);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(750, 465);
            this.crystalReportViewer1.TabIndex = 8;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(425, 13);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(99, 23);
            this.btnGroup.TabIndex = 9;
            this.btnGroup.Text = "分组显示并统计";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnParentChild
            // 
            this.btnParentChild.Location = new System.Drawing.Point(556, 12);
            this.btnParentChild.Name = "btnParentChild";
            this.btnParentChild.Size = new System.Drawing.Size(75, 23);
            this.btnParentChild.TabIndex = 10;
            this.btnParentChild.Text = "子报表";
            this.btnParentChild.UseVisualStyleBackColor = true;
            this.btnParentChild.Click += new System.EventHandler(this.btnParentChild_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(655, 12);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "多列格式";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // frmCrystalReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 508);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnParentChild);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnChart);
            this.Controls.Add(this.btnCross);
            this.Controls.Add(this.btnByDataSet);
            this.Controls.Add(this.btnByParam);
            this.Name = "frmCrystalReport";
            this.Text = "CrystalReport  水晶报表演示";
            this.Load += new System.EventHandler(this.frmCrystalReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnByDataSet;
        private System.Windows.Forms.Button btnByParam;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnParentChild;
        private System.Windows.Forms.Button btnList;
    }
}