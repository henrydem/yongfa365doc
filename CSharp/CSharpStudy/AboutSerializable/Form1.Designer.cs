namespace AboutSerializable
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.btnXML2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DemoFirst";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(24, 81);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(211, 23);
            this.btnXML.TabIndex = 1;
            this.btnXML.Text = "XML序列化及反序列化【不加标签】";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // btnXML2
            // 
            this.btnXML2.Location = new System.Drawing.Point(24, 110);
            this.btnXML2.Name = "btnXML2";
            this.btnXML2.Size = new System.Drawing.Size(242, 23);
            this.btnXML2.TabIndex = 1;
            this.btnXML2.Text = "XML序列化及反序列化【加各种特性标签】";
            this.btnXML2.UseVisualStyleBackColor = true;
            this.btnXML2.Click += new System.EventHandler(this.btnXML2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnXML2);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.Button btnXML2;
    }
}

