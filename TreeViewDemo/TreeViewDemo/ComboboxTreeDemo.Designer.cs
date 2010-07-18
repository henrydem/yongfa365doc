namespace TreeViewDemo
{
    partial class ComboboxTreeDemo
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxTree2 = new YongFa365.Controls.ComboBoxTree.ComboBoxTree();
            this.comboboxTree1 = new YongFa365.Winform.UserControls.ComboBoxTree();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(37, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBoxTree2
            // 
            this.comboBoxTree2.AbsoluteChildrenSelectableOnly = false;
            this.comboBoxTree2.Location = new System.Drawing.Point(377, 14);
            this.comboBoxTree2.Name = "comboBoxTree2";
            this.comboBoxTree2.Size = new System.Drawing.Size(153, 21);
            this.comboBoxTree2.TabIndex = 3;
            this.comboBoxTree2.Text = "comboBoxTree2";
            this.comboBoxTree2.Value = "-1";
            // 
            // comboboxTree1
            // 
            this.comboboxTree1.BackColor = System.Drawing.Color.Transparent;
            this.comboboxTree1.DropDownHeigth = 300;
            this.comboboxTree1.Location = new System.Drawing.Point(131, 12);
            this.comboboxTree1.Name = "comboboxTree1";
            this.comboboxTree1.Size = new System.Drawing.Size(125, 20);
            this.comboboxTree1.TabIndex = 1;
            this.comboboxTree1.Text = "";
            // 
            // ComboboxTreeDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 222);
            this.Controls.Add(this.comboBoxTree2);
            this.Controls.Add(this.comboboxTree1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Name = "ComboboxTreeDemo";
            this.Text = "ComboboxTreeDemo";
            this.Load += new System.EventHandler(this.ComboboxTreeDemo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private YongFa365.Controls.ComboBoxTree.ComboBoxTree comboBoxTree2;
        private YongFa365.Winform.UserControls.ComboBoxTree comboboxTree1;
    }
}