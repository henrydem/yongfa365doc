namespace FriendsLinks
{
    partial class FriendsLinks
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
            this.txtMyURL = new System.Windows.Forms.TextBox();
            this.txtS = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetURL = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtWebName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWebURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.txtStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCheckURL = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.解决方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwwChiZonecnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wwwyongfa365comToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于作者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.柳永法yongfa365BlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkPR = new System.Windows.Forms.CheckBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.保存当前方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入解决方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMyURL
            // 
            this.txtMyURL.Location = new System.Drawing.Point(107, 28);
            this.txtMyURL.Name = "txtMyURL";
            this.txtMyURL.Size = new System.Drawing.Size(453, 21);
            this.txtMyURL.TabIndex = 0;
            // 
            // txtS
            // 
            this.txtS.Location = new System.Drawing.Point(107, 54);
            this.txtS.Name = "txtS";
            this.txtS.Size = new System.Drawing.Size(167, 21);
            this.txtS.TabIndex = 1;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(375, 55);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(185, 21);
            this.txtD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "您的网站地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "第一链接地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "最后链接网址：";
            // 
            // btnGetURL
            // 
            this.btnGetURL.Location = new System.Drawing.Point(569, 28);
            this.btnGetURL.Name = "btnGetURL";
            this.btnGetURL.Size = new System.Drawing.Size(78, 23);
            this.btnGetURL.TabIndex = 6;
            this.btnGetURL.Text = "取地址";
            this.btnGetURL.UseVisualStyleBackColor = true;
            this.btnGetURL.Click += new System.EventHandler(this.btnGetURL_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtWebName,
            this.txtWebURL,
            this.txtStatus,
            this.txtPR,
            this.blFlag});
            this.dataGridView1.Location = new System.Drawing.Point(12, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(695, 396);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtWebName
            // 
            this.txtWebName.HeaderText = "网站名称";
            this.txtWebName.Name = "txtWebName";
            this.txtWebName.Width = 140;
            // 
            // txtWebURL
            // 
            this.txtWebURL.HeaderText = "网址";
            this.txtWebURL.Name = "txtWebURL";
            this.txtWebURL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtWebURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtWebURL.Width = 300;
            // 
            // txtStatus
            // 
            this.txtStatus.HeaderText = "状态";
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Width = 60;
            // 
            // txtPR
            // 
            this.txtPR.HeaderText = "PR值";
            this.txtPR.Name = "txtPR";
            this.txtPR.Width = 60;
            // 
            // blFlag
            // 
            this.blFlag.HeaderText = "已检测";
            this.blFlag.Name = "blFlag";
            this.blFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.blFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.blFlag.Width = 80;
            // 
            // btnCheckURL
            // 
            this.btnCheckURL.Location = new System.Drawing.Point(569, 54);
            this.btnCheckURL.Name = "btnCheckURL";
            this.btnCheckURL.Size = new System.Drawing.Size(78, 23);
            this.btnCheckURL.TabIndex = 9;
            this.btnCheckURL.Text = "检测链接";
            this.btnCheckURL.UseVisualStyleBackColor = true;
            this.btnCheckURL.Click += new System.EventHandler(this.btnCheckURL_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(653, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(54, 23);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.Text = "反选";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解决方案ToolStripMenuItem,
            this.关于作者ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 解决方案ToolStripMenuItem
            // 
            this.解决方案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wwwChiZonecnToolStripMenuItem,
            this.wwwyongfa365comToolStripMenuItem,
            this.toolStripMenuItem1,
            this.保存当前方案ToolStripMenuItem,
            this.载入解决方案ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.解决方案ToolStripMenuItem.Name = "解决方案ToolStripMenuItem";
            this.解决方案ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.解决方案ToolStripMenuItem.Text = "解决方案";
            this.解决方案ToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // wwwChiZonecnToolStripMenuItem
            // 
            this.wwwChiZonecnToolStripMenuItem.Name = "wwwChiZonecnToolStripMenuItem";
            this.wwwChiZonecnToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.wwwChiZonecnToolStripMenuItem.Text = "www.ChiZone.cn";
            this.wwwChiZonecnToolStripMenuItem.Click += new System.EventHandler(this.wwwChiZonecnToolStripMenuItem_Click);
            // 
            // wwwyongfa365comToolStripMenuItem
            // 
            this.wwwyongfa365comToolStripMenuItem.Name = "wwwyongfa365comToolStripMenuItem";
            this.wwwyongfa365comToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.wwwyongfa365comToolStripMenuItem.Text = "www.yongfa365.com";
            this.wwwyongfa365comToolStripMenuItem.Click += new System.EventHandler(this.wwwyongfa365comToolStripMenuItem_Click);
            // 
            // 关于作者ToolStripMenuItem
            // 
            this.关于作者ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.柳永法yongfa365BlogToolStripMenuItem});
            this.关于作者ToolStripMenuItem.Name = "关于作者ToolStripMenuItem";
            this.关于作者ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.关于作者ToolStripMenuItem.Text = "关于作者";
            // 
            // 柳永法yongfa365BlogToolStripMenuItem
            // 
            this.柳永法yongfa365BlogToolStripMenuItem.Name = "柳永法yongfa365BlogToolStripMenuItem";
            this.柳永法yongfa365BlogToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.柳永法yongfa365BlogToolStripMenuItem.Text = "柳永法(yongfa365)\'Blog";
            this.柳永法yongfa365BlogToolStripMenuItem.Click += new System.EventHandler(this.柳永法yongfa365BlogToolStripMenuItem_Click);
            // 
            // chkPR
            // 
            this.chkPR.AutoSize = true;
            this.chkPR.Location = new System.Drawing.Point(653, 58);
            this.chkPR.Name = "chkPR";
            this.chkPR.Size = new System.Drawing.Size(60, 16);
            this.chkPR.TabIndex = 13;
            this.chkPR.Text = "检测PR";
            this.chkPR.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 6);
            // 
            // 保存当前方案ToolStripMenuItem
            // 
            this.保存当前方案ToolStripMenuItem.Name = "保存当前方案ToolStripMenuItem";
            this.保存当前方案ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.保存当前方案ToolStripMenuItem.Text = "保存当前方案";
            this.保存当前方案ToolStripMenuItem.Click += new System.EventHandler(this.保存当前方案ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 载入解决方案ToolStripMenuItem
            // 
            this.载入解决方案ToolStripMenuItem.Name = "载入解决方案ToolStripMenuItem";
            this.载入解决方案ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.载入解决方案ToolStripMenuItem.Text = "载入解决方案";
            this.载入解决方案ToolStripMenuItem.Click += new System.EventHandler(this.载入解决方案ToolStripMenuItem_Click);
            // 
            // FriendsLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 488);
            this.Controls.Add(this.chkPR);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCheckURL);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGetURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtS);
            this.Controls.Add(this.txtMyURL);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FriendsLinks";
            this.Text = "陈漫霞小美女专用友情链接检测工具";
            this.Load += new System.EventHandler(this.FriendsLinks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMyURL;
        private System.Windows.Forms.TextBox txtS;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetURL;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCheckURL;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 解决方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwwChiZonecnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wwwyongfa365comToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于作者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 柳永法yongfa365BlogToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWebName;
        private System.Windows.Forms.DataGridViewLinkColumn txtWebURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn blFlag;
        private System.Windows.Forms.CheckBox chkPR;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 保存当前方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入解决方案ToolStripMenuItem;
    }
}