namespace _51job
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.job全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关键词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载从文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 25);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(766, 487);
            this.dgv1.TabIndex = 1;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.列ToolStripMenuItem,
            this.关键词ToolStripMenuItem,
            this.开始分析ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 列ToolStripMenuItem
            // 
            this.列ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.精选ToolStripMenuItem,
            this.job全部ToolStripMenuItem});
            this.列ToolStripMenuItem.Name = "列ToolStripMenuItem";
            this.列ToolStripMenuItem.Size = new System.Drawing.Size(107, 21);
            this.列ToolStripMenuItem.Text = "加载城市列表(&1)";
            // 
            // 精选ToolStripMenuItem
            // 
            this.精选ToolStripMenuItem.Name = "精选ToolStripMenuItem";
            this.精选ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.精选ToolStripMenuItem.Text = "精选";
            this.精选ToolStripMenuItem.Click += new System.EventHandler(this.精选ToolStripMenuItem_Click);
            // 
            // job全部ToolStripMenuItem
            // 
            this.job全部ToolStripMenuItem.Name = "job全部ToolStripMenuItem";
            this.job全部ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.job全部ToolStripMenuItem.Text = "51job全部";
            this.job全部ToolStripMenuItem.Click += new System.EventHandler(this.job全部ToolStripMenuItem_Click);
            // 
            // 关键词ToolStripMenuItem
            // 
            this.关键词ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载默认ToolStripMenuItem,
            this.加载从文件ToolStripMenuItem,
            this.保存到文件ToolStripMenuItem});
            this.关键词ToolStripMenuItem.Name = "关键词ToolStripMenuItem";
            this.关键词ToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.关键词ToolStripMenuItem.Text = "加载关键词(&2)";
            // 
            // 加载默认ToolStripMenuItem
            // 
            this.加载默认ToolStripMenuItem.Name = "加载默认ToolStripMenuItem";
            this.加载默认ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.加载默认ToolStripMenuItem.Text = "加载默认";
            this.加载默认ToolStripMenuItem.Click += new System.EventHandler(this.加载默认ToolStripMenuItem_Click);
            // 
            // 加载从文件ToolStripMenuItem
            // 
            this.加载从文件ToolStripMenuItem.Name = "加载从文件ToolStripMenuItem";
            this.加载从文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.加载从文件ToolStripMenuItem.Text = "加载从文件";
            this.加载从文件ToolStripMenuItem.Click += new System.EventHandler(this.加载从文件ToolStripMenuItem_Click);
            // 
            // 保存到文件ToolStripMenuItem
            // 
            this.保存到文件ToolStripMenuItem.Name = "保存到文件ToolStripMenuItem";
            this.保存到文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.保存到文件ToolStripMenuItem.Text = "保存到文件";
            this.保存到文件ToolStripMenuItem.Click += new System.EventHandler(this.保存到文件ToolStripMenuItem_Click);
            // 
            // 开始分析ToolStripMenuItem
            // 
            this.开始分析ToolStripMenuItem.Image = global::_51job.Properties.Resources.查询;
            this.开始分析ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.开始分析ToolStripMenuItem.Name = "开始分析ToolStripMenuItem";
            this.开始分析ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.开始分析ToolStripMenuItem.Size = new System.Drawing.Size(105, 21);
            this.开始分析ToolStripMenuItem.Text = "开始分析(F5)";
            this.开始分析ToolStripMenuItem.Click += new System.EventHandler(this.开始分析ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 512);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "51job职位要求分析系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关键词ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载默认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载从文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存到文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem job全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 精选ToolStripMenuItem;
    }
}

