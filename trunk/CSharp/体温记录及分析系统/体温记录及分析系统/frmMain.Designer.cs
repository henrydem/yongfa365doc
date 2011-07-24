namespace 体温记录及分析系统
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.数据库压缩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除指定数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所有数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.数据库备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库压缩ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.柳永法yongfa365BlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.ComboBox();
            this.Weather = new System.Windows.Forms.ComboBox();
            this.PutDateTime = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导出为ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(554, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出XToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成测试数据ToolStripMenuItem,
            this.删除测试数据ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.数据库压缩ToolStripMenuItem,
            this.删除指定数据ToolStripMenuItem,
            this.删除所有数据ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.数据库备份ToolStripMenuItem,
            this.数据库压缩ToolStripMenuItem1,
            this.导出为ExcelToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 生成测试数据ToolStripMenuItem
            // 
            this.生成测试数据ToolStripMenuItem.Name = "生成测试数据ToolStripMenuItem";
            this.生成测试数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.生成测试数据ToolStripMenuItem.Text = "生成测试数据";
            this.生成测试数据ToolStripMenuItem.Click += new System.EventHandler(this.生成测试数据ToolStripMenuItem_Click);
            // 
            // 删除测试数据ToolStripMenuItem
            // 
            this.删除测试数据ToolStripMenuItem.Name = "删除测试数据ToolStripMenuItem";
            this.删除测试数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除测试数据ToolStripMenuItem.Text = "删除测试数据";
            this.删除测试数据ToolStripMenuItem.Click += new System.EventHandler(this.删除测试数据ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // 数据库压缩ToolStripMenuItem
            // 
            this.数据库压缩ToolStripMenuItem.Name = "数据库压缩ToolStripMenuItem";
            this.数据库压缩ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据库压缩ToolStripMenuItem.Text = "数据库压缩";
            // 
            // 删除指定数据ToolStripMenuItem
            // 
            this.删除指定数据ToolStripMenuItem.Name = "删除指定数据ToolStripMenuItem";
            this.删除指定数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除指定数据ToolStripMenuItem.Text = "删除指定数据";
            // 
            // 删除所有数据ToolStripMenuItem
            // 
            this.删除所有数据ToolStripMenuItem.Name = "删除所有数据ToolStripMenuItem";
            this.删除所有数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除所有数据ToolStripMenuItem.Text = "删除所有数据";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // 数据库备份ToolStripMenuItem
            // 
            this.数据库备份ToolStripMenuItem.Name = "数据库备份ToolStripMenuItem";
            this.数据库备份ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据库备份ToolStripMenuItem.Text = "数据库备份";
            // 
            // 数据库压缩ToolStripMenuItem1
            // 
            this.数据库压缩ToolStripMenuItem1.Name = "数据库压缩ToolStripMenuItem1";
            this.数据库压缩ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.数据库压缩ToolStripMenuItem1.Text = "数据库压缩";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.柳永法yongfa365BlogToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 柳永法yongfa365BlogToolStripMenuItem
            // 
            this.柳永法yongfa365BlogToolStripMenuItem.Name = "柳永法yongfa365BlogToolStripMenuItem";
            this.柳永法yongfa365BlogToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.柳永法yongfa365BlogToolStripMenuItem.Text = "柳永法(yongfa365)\'Blog";
            this.柳永法yongfa365BlogToolStripMenuItem.Click += new System.EventHandler(this.柳永法yongfa365BlogToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TW);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Controls.Add(this.Weather);
            this.groupBox1.Controls.Add(this.PutDateTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加体温记录";
            // 
            // TW
            // 
            this.TW.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TW.Location = new System.Drawing.Point(16, 48);
            this.TW.Name = "TW";
            this.TW.Size = new System.Drawing.Size(119, 57);
            this.TW.TabIndex = 3;
            this.TW.Text = "36.00";
            this.TW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(126, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "℃";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(364, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "分析体温记录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "添加体温记录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserName
            // 
            this.UserName.FormattingEnabled = true;
            this.UserName.Items.AddRange(new object[] {
            "柳永法",
            "陈漫霞"});
            this.UserName.Location = new System.Drawing.Point(364, 22);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(121, 20);
            this.UserName.TabIndex = 2;
            // 
            // Weather
            // 
            this.Weather.FormattingEnabled = true;
            this.Weather.Items.AddRange(new object[] {
            "睛",
            "阴",
            "小雨",
            "多云",
            "阵雨",
            "连阴",
            "小雪"});
            this.Weather.Location = new System.Drawing.Point(224, 22);
            this.Weather.Name = "Weather";
            this.Weather.Size = new System.Drawing.Size(121, 20);
            this.Weather.TabIndex = 1;
            // 
            // PutDateTime
            // 
            this.PutDateTime.CustomFormat = "yyyy年MM月dd日 HH时mm分ss秒";
            this.PutDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PutDateTime.Location = new System.Drawing.Point(16, 21);
            this.PutDateTime.Name = "PutDateTime";
            this.PutDateTime.Size = new System.Drawing.Size(187, 21);
            this.PutDateTime.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(526, 214);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserName";
            this.Column1.HeaderText = "添加者";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "PutDateTime";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "添加时间";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TW";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "体温";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Weather";
            this.Column4.HeaderText = "天气";
            this.Column4.Name = "Column4";
            // 
            // 导出为ExcelToolStripMenuItem
            // 
            this.导出为ExcelToolStripMenuItem.Name = "导出为ExcelToolStripMenuItem";
            this.导出为ExcelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导出为ExcelToolStripMenuItem.Text = "导出为Excel";
            this.导出为ExcelToolStripMenuItem.Click += new System.EventHandler(this.导出为ExcelToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "体温记录及分析系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 柳永法yongfa365BlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成测试数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除测试数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据库压缩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除指定数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除所有数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 数据库备份ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker PutDateTime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TW;
        private System.Windows.Forms.ComboBox UserName;
        private System.Windows.Forms.ComboBox Weather;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 数据库压缩ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导出为ExcelToolStripMenuItem;
    }
}

