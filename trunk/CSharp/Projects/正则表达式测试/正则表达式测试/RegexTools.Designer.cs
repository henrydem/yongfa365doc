namespace 正则表达式测试
{
    partial class RegexTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegexTools));
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegExp2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMatchCount = new System.Windows.Forms.Button();
            this.cbxRegExp = new System.Windows.Forms.ComboBox();
            this.chkMultiline = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.测试内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从文件导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从网站导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正则表达式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从文件导入ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.还原默认数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.柳永法yongfa365BlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.AcceptsReturn = true;
            this.txtSource.BackColor = System.Drawing.Color.White;
            this.txtSource.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtSource.Location = new System.Drawing.Point(15, 32);
            this.txtSource.MaxLength = 2147483647;
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(550, 131);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = resources.GetString("txtSource.Text");
            this.txtSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSource_KeyDown);
            // 
            // txtD
            // 
            this.txtD.BackColor = System.Drawing.Color.White;
            this.txtD.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtD.Location = new System.Drawing.Point(15, 281);
            this.txtD.MaxLength = 2147483647;
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtD.Size = new System.Drawing.Size(550, 123);
            this.txtD.TabIndex = 7;
            this.txtD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtD_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "正则表达式：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "处理结果：";
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(97, 252);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 4;
            this.btnMatch.Text = "查找";
            this.btnMatch.UseVisualStyleBackColor = true;
            this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(178, 252);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Checked = true;
            this.chkIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCase.Location = new System.Drawing.Point(112, 165);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(84, 16);
            this.chkIgnoreCase.TabIndex = 1;
            this.chkIgnoreCase.Text = "忽略大小写";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // txtRegExp2
            // 
            this.txtRegExp2.BackColor = System.Drawing.Color.White;
            this.txtRegExp2.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtRegExp2.Location = new System.Drawing.Point(15, 225);
            this.txtRegExp2.Name = "txtRegExp2";
            this.txtRegExp2.Size = new System.Drawing.Size(550, 21);
            this.txtRegExp2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "替换为：";
            // 
            // btnMatchCount
            // 
            this.btnMatchCount.Location = new System.Drawing.Point(259, 252);
            this.btnMatchCount.Name = "btnMatchCount";
            this.btnMatchCount.Size = new System.Drawing.Size(75, 23);
            this.btnMatchCount.TabIndex = 6;
            this.btnMatchCount.Text = "匹配个数";
            this.btnMatchCount.UseVisualStyleBackColor = true;
            this.btnMatchCount.Click += new System.EventHandler(this.btnMatchCount_Click);
            // 
            // cbxRegExp
            // 
            this.cbxRegExp.DropDownHeight = 300;
            this.cbxRegExp.FormattingEnabled = true;
            this.cbxRegExp.IntegralHeight = false;
            this.cbxRegExp.Items.AddRange(new object[] {
            "\\s",
            "\\d",
            "\\w",
            "(.+?)",
            "================网络匹配===================",
            "<[^<>]+?>",
            "[a-zA-z]+://[^\\s]*",
            "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
            "\\d+\\.\\d+\\.\\d+\\.\\d+",
            "================电话，手机=================",
            "1[35]\\d{9}",
            "d{3,4}-?\\d{6,8}",
            "================中文=======================",
            "[\\u4e00-\\u9fa5]",
            "[^\\x00-\\xff]",
            "================排版=======================",
            "^[ \\t]*|[ \\t]*$"});
            this.cbxRegExp.Location = new System.Drawing.Point(17, 187);
            this.cbxRegExp.Name = "cbxRegExp";
            this.cbxRegExp.Size = new System.Drawing.Size(548, 20);
            this.cbxRegExp.TabIndex = 2;
            this.cbxRegExp.Text = "\\s";
            // 
            // chkMultiline
            // 
            this.chkMultiline.AutoSize = true;
            this.chkMultiline.Location = new System.Drawing.Point(202, 165);
            this.chkMultiline.Name = "chkMultiline";
            this.chkMultiline.Size = new System.Drawing.Size(72, 16);
            this.chkMultiline.TabIndex = 8;
            this.chkMultiline.Text = "多行模式";
            this.chkMultiline.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试内容ToolStripMenuItem,
            this.正则表达式ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 测试内容ToolStripMenuItem
            // 
            this.测试内容ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.从文件导入ToolStripMenuItem,
            this.从网站导入ToolStripMenuItem});
            this.测试内容ToolStripMenuItem.Name = "测试内容ToolStripMenuItem";
            this.测试内容ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.测试内容ToolStripMenuItem.Text = "测试内容";
            // 
            // 从文件导入ToolStripMenuItem
            // 
            this.从文件导入ToolStripMenuItem.Name = "从文件导入ToolStripMenuItem";
            this.从文件导入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.从文件导入ToolStripMenuItem.Text = "从文件导入...";
            this.从文件导入ToolStripMenuItem.Click += new System.EventHandler(this.从文件导入ToolStripMenuItem_Click);
            // 
            // 从网站导入ToolStripMenuItem
            // 
            this.从网站导入ToolStripMenuItem.Name = "从网站导入ToolStripMenuItem";
            this.从网站导入ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.从网站导入ToolStripMenuItem.Text = "从网站导入...";
            this.从网站导入ToolStripMenuItem.Click += new System.EventHandler(this.从网站导入ToolStripMenuItem_Click);
            // 
            // 正则表达式ToolStripMenuItem
            // 
            this.正则表达式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.从文件导入ToolStripMenuItem1,
            this.还原默认数据ToolStripMenuItem});
            this.正则表达式ToolStripMenuItem.Name = "正则表达式ToolStripMenuItem";
            this.正则表达式ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.正则表达式ToolStripMenuItem.Text = "正则表达式";
            // 
            // 从文件导入ToolStripMenuItem1
            // 
            this.从文件导入ToolStripMenuItem1.Name = "从文件导入ToolStripMenuItem1";
            this.从文件导入ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.从文件导入ToolStripMenuItem1.Text = "从文件导入...";
            this.从文件导入ToolStripMenuItem1.Click += new System.EventHandler(this.从文件导入ToolStripMenuItem1_Click);
            // 
            // 还原默认数据ToolStripMenuItem
            // 
            this.还原默认数据ToolStripMenuItem.Name = "还原默认数据ToolStripMenuItem";
            this.还原默认数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.还原默认数据ToolStripMenuItem.Text = "还原默认数据";
            this.还原默认数据ToolStripMenuItem.Click += new System.EventHandler(this.还原默认数据ToolStripMenuItem_Click);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Controls.Add(this.chkMultiline);
            this.groupBox1.Controls.Add(this.txtD);
            this.groupBox1.Controls.Add(this.cbxRegExp);
            this.groupBox1.Controls.Add(this.txtRegExp2);
            this.groupBox1.Controls.Add(this.chkIgnoreCase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMatchCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReplace);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnMatch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 418);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源字符串：";
            // 
            // RegexTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RegexTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正则表达式练习器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMatch;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.TextBox txtRegExp2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMatchCount;
        private System.Windows.Forms.ComboBox cbxRegExp;
        private System.Windows.Forms.CheckBox chkMultiline;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 测试内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从文件导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从网站导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正则表达式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从文件导入ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 还原默认数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 柳永法yongfa365BlogToolStripMenuItem;
    }
}

