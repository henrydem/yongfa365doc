namespace 下载地址批量转换工具
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
            this.S = new System.Windows.Forms.RichTextBox();
            this.D = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdnormal = new System.Windows.Forms.RadioButton();
            this.rdflashget = new System.Windows.Forms.RadioButton();
            this.rdxunlei = new System.Windows.Forms.RadioButton();
            this.rdxuanfeng = new System.Windows.Forms.RadioButton();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDemo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // S
            // 
            this.S.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.S.Location = new System.Drawing.Point(14, 25);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(701, 153);
            this.S.TabIndex = 0;
            this.S.Text = "";
            this.S.MouseClick += new System.Windows.Forms.MouseEventHandler(this.S_MouseClick);
            // 
            // D
            // 
            this.D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.D.Location = new System.Drawing.Point(14, 207);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(701, 153);
            this.D.TabIndex = 1;
            this.D.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "输出：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "输出格式：";
            // 
            // rdnormal
            // 
            this.rdnormal.AutoSize = true;
            this.rdnormal.Location = new System.Drawing.Point(83, 380);
            this.rdnormal.Name = "rdnormal";
            this.rdnormal.Size = new System.Drawing.Size(47, 16);
            this.rdnormal.TabIndex = 2;
            this.rdnormal.Text = "普通";
            this.rdnormal.UseVisualStyleBackColor = true;
            // 
            // rdflashget
            // 
            this.rdflashget.AutoSize = true;
            this.rdflashget.Location = new System.Drawing.Point(225, 380);
            this.rdflashget.Name = "rdflashget";
            this.rdflashget.Size = new System.Drawing.Size(119, 16);
            this.rdflashget.TabIndex = 4;
            this.rdflashget.Text = "网际快车FlashGet";
            this.rdflashget.UseVisualStyleBackColor = true;
            // 
            // rdxunlei
            // 
            this.rdxunlei.AutoSize = true;
            this.rdxunlei.Checked = true;
            this.rdxunlei.Location = new System.Drawing.Point(136, 380);
            this.rdxunlei.Name = "rdxunlei";
            this.rdxunlei.Size = new System.Drawing.Size(83, 16);
            this.rdxunlei.TabIndex = 3;
            this.rdxunlei.TabStop = true;
            this.rdxunlei.Text = "迅雷xunlei";
            this.rdxunlei.UseVisualStyleBackColor = true;
            // 
            // rdxuanfeng
            // 
            this.rdxuanfeng.AutoSize = true;
            this.rdxuanfeng.Location = new System.Drawing.Point(350, 380);
            this.rdxuanfeng.Name = "rdxuanfeng";
            this.rdxuanfeng.Size = new System.Drawing.Size(59, 16);
            this.rdxuanfeng.TabIndex = 5;
            this.rdxuanfeng.Text = "QQ旋风";
            this.rdxuanfeng.UseVisualStyleBackColor = true;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(435, 366);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(92, 45);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "开始转换";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(543, 366);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 45);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "查看更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnDemo.Location = new System.Drawing.Point(646, 366);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(75, 45);
            this.btnDemo.TabIndex = 8;
            this.btnDemo.Text = "测试数据";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnChange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 423);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.rdxuanfeng);
            this.Controls.Add(this.rdxunlei);
            this.Controls.Add(this.rdflashget);
            this.Controls.Add(this.rdnormal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.D);
            this.Controls.Add(this.S);
            this.Name = "Form1";
            this.Text = "下载地址批量转换工具 V1.0 2009-04-10";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox S;
        private System.Windows.Forms.RichTextBox D;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdnormal;
        private System.Windows.Forms.RadioButton rdflashget;
        private System.Windows.Forms.RadioButton rdxunlei;
        private System.Windows.Forms.RadioButton rdxuanfeng;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDemo;
    }
}

