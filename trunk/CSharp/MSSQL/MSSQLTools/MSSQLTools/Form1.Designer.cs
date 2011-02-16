namespace MSSQLTools
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbxConn = new System.Windows.Forms.ComboBox();
            this.btnMake = new System.Windows.Forms.Button();
            this.txtOK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxdbName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "连接字符串：";
            // 
            // cbxConn
            // 
            this.cbxConn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConn.FormattingEnabled = true;
            this.cbxConn.Items.AddRange(new object[] {
            "Data Source=HP580DBSZ\\DEVDBINSTANCE;Initial Catalog=HotelDB;Integrated Security=T" +
                "rue"});
            this.cbxConn.Location = new System.Drawing.Point(14, 24);
            this.cbxConn.Name = "cbxConn";
            this.cbxConn.Size = new System.Drawing.Size(885, 20);
            this.cbxConn.TabIndex = 2;
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(14, 107);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(75, 23);
            this.btnMake.TabIndex = 3;
            this.btnMake.Text = "btnMake";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // txtOK
            // 
            this.txtOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOK.Location = new System.Drawing.Point(14, 136);
            this.txtOK.Multiline = true;
            this.txtOK.Name = "txtOK";
            this.txtOK.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOK.Size = new System.Drawing.Size(885, 379);
            this.txtOK.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "要处理的数据库：";
            // 
            // cbxdbName
            // 
            this.cbxdbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxdbName.FormattingEnabled = true;
            this.cbxdbName.Items.AddRange(new object[] {
            "DataAccessDB|HRDB|HotelDB|Caching|LoggingDB|RightsManagementDB|OperateLogDB|Membe" +
                "rDB|MessageDB|AccountDB|MailDB"});
            this.cbxdbName.Location = new System.Drawing.Point(14, 81);
            this.cbxdbName.Name = "cbxdbName";
            this.cbxdbName.Size = new System.Drawing.Size(885, 20);
            this.cbxdbName.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 539);
            this.Controls.Add(this.txtOK);
            this.Controls.Add(this.btnMake);
            this.Controls.Add(this.cbxdbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxConn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "生成备份及还原SQL语句";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxConn;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.TextBox txtOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxdbName;
    }
}

