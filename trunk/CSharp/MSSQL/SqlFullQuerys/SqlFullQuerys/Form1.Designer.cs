namespace SqlFullQuerys
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblDBName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.chkUseWindows = new System.Windows.Forms.CheckBox();
            this.chkLike = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbxDBName = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDbInstance = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtLogs = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 508);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(762, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 392);
            this.panel2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(756, 313);
            this.dataGridView1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDBName);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.progressBar2);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 313);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(756, 79);
            this.panel3.TabIndex = 1;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(12, 11);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(41, 12);
            this.lblDBName.TabIndex = 3;
            this.lblDBName.Text = "dbname";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(139, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Preparing ...";
            // 
            // progressBar2
            // 
            this.progressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar2.Location = new System.Drawing.Point(0, 33);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(756, 23);
            this.progressBar2.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(756, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtDBName);
            this.panel1.Controls.Add(this.chkUseWindows);
            this.panel1.Controls.Add(this.chkLike);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.cbxDBName);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.txtDbInstance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 84);
            this.panel1.TabIndex = 2;
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(336, 10);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.ReadOnly = true;
            this.txtDBName.Size = new System.Drawing.Size(100, 21);
            this.txtDBName.TabIndex = 17;
            this.txtDBName.Text = "dbname";
            // 
            // chkUseWindows
            // 
            this.chkUseWindows.AutoSize = true;
            this.chkUseWindows.Checked = true;
            this.chkUseWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseWindows.Location = new System.Drawing.Point(453, 12);
            this.chkUseWindows.Name = "chkUseWindows";
            this.chkUseWindows.Size = new System.Drawing.Size(72, 16);
            this.chkUseWindows.TabIndex = 16;
            this.chkUseWindows.Text = "集成验证";
            this.chkUseWindows.UseVisualStyleBackColor = true;
            this.chkUseWindows.Click += new System.EventHandler(this.chkUseWindows_CheckedChanged);
            // 
            // chkLike
            // 
            this.chkLike.AutoSize = true;
            this.chkLike.Checked = true;
            this.chkLike.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLike.Location = new System.Drawing.Point(453, 50);
            this.chkLike.Name = "chkLike";
            this.chkLike.Size = new System.Drawing.Size(72, 16);
            this.chkLike.TabIndex = 15;
            this.chkLike.Text = "Use Like";
            this.chkLike.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(229, 48);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(207, 21);
            this.txtKey.TabIndex = 12;
            this.txtKey.Text = "iwingon.com";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(531, 47);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(48, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(531, 9);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(46, 23);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cbxDBName
            // 
            this.cbxDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDBName.FormattingEnabled = true;
            this.cbxDBName.Location = new System.Drawing.Point(11, 48);
            this.cbxDBName.Name = "cbxDBName";
            this.cbxDBName.Size = new System.Drawing.Size(209, 20);
            this.cbxDBName.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(229, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(100, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "sa";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(120, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Text = "sa";
            // 
            // txtDbInstance
            // 
            this.txtDbInstance.Location = new System.Drawing.Point(11, 10);
            this.txtDbInstance.Name = "txtDbInstance";
            this.txtDbInstance.Size = new System.Drawing.Size(100, 21);
            this.txtDbInstance.TabIndex = 3;
            this.txtDbInstance.Text = "hp580dbsz\\dev";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtLogs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(762, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLogs
            // 
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogs.Location = new System.Drawing.Point(3, 3);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(756, 476);
            this.txtLogs.TabIndex = 0;
            this.txtLogs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Full Text Query";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.CheckBox chkUseWindows;
        private System.Windows.Forms.CheckBox chkLike;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cbxDBName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDbInstance;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox txtLogs;

    }
}

