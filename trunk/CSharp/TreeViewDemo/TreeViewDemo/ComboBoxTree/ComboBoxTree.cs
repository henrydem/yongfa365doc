using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace YongFa365.Controls.ComboBoxTree
{
    //public delegate void ClickEventHandler(object sender, EventArgs e);
    /// <summary>
    /// ComboBoxTree control is a treeview that drops down much like a combobox
    /// </summary>
    public class ComboBoxTree : UserControl
    {

        #region Private Fields
        private TextBox txtBack;
        private Panel pnlTree;
        private ButtonEx btnSelect;
        private TreeView tvTreeView;
        private LabelEx lblSizingGrip;
        private Form frmTreeView;


        private bool _absoluteChildrenSelectableOnly = false;
        private System.Drawing.Point DragOffset;
        private string defaultText = "==请选择==";
        private string defaultValue = "-1";
        private int hitnumber = 0;
        private bool isCustomSelectBy = false;
        #endregion

        #region Public Properties

        [Browsable(false)]
        public TreeNodeCollection Nodes
        {
            get
            {
                return this.tvTreeView.Nodes;
            }
        }

        [Browsable(false)]
        public string FullPath
        {
            get
            {
                try
                {
                    return this.tvTreeView.SelectedNode.FullPath;
                }
                catch
                {

                    return "";
                }
            }

        }


        [Browsable(true), Category("TreeView"), Description("获取或设置Text"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return this.txtBack.Text; }
            set { this.txtBack.Text = value; }

        }


        [Browsable(true), Category("TreeView"), Description("获取或设置Value"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Value
        {
            get
            {
                try
                {
                    return this.txtBack.Tag.ToString();
                }
                catch
                {

                    return this.defaultValue;
                }
            }
            set { this.txtBack.Tag = value; }
        }


        [Browsable(true), Category("TreeView"), Description("获取或设置是否 只能选择没有子结点的结点"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AbsoluteChildrenSelectableOnly
        {
            get { return this._absoluteChildrenSelectableOnly; }
            set { this._absoluteChildrenSelectableOnly = value; }
        }



        #endregion

        #region Public Method


        #region 根据条件选中
        public TreeNode FindNodeByText(TreeNodeCollection Nodes, string value)
        {
            TreeNode found = null;

            foreach (TreeNode node in Nodes)
            {
                if (node.Text == value)
                    return node;

                if (node.Nodes.Count > 0 && ((found = FindNodeByText(node.Nodes, value)) != null))
                    return found;
            }

            return null;
        }

        public TreeNode FindNodeByTag(TreeNodeCollection Nodes, object value)
        {
            TreeNode found = null;

            foreach (TreeNode node in Nodes)
            {
                if (node.Tag != null && node.Tag.ToString() == value.ToString())
                    return node;

                if (node.Nodes.Count > 0 && ((found = FindNodeByTag(node.Nodes, value)) != null))
                    return found;

            }

            return null;
        }

        private bool SetTextValue()
        {
            if (this.tvTreeView.SelectedNode != null)
            {
                this.Text = this.tvTreeView.SelectedNode.Text;
                this.Value = this.tvTreeView.SelectedNode.Tag.ToString();
                return true;
            }
            else
            {
                this.Text = this.defaultText;
                this.Value = this.defaultValue;
                return false;
            }

        }

        public bool SelectNodeByText(string value)
        {
            if (this.tvTreeView.SelectedNode != null && this.tvTreeView.SelectedNode.Text != value)
            {
                this.isCustomSelectBy = true;
            }
            this.tvTreeView.SelectedNode = FindNodeByText(this.tvTreeView.Nodes, value);
            return SetTextValue();
        }

        public bool SelectNodeByTag(object value)
        {
            if (this.tvTreeView.SelectedNode != null && this.tvTreeView.SelectedNode.Tag.ToString() != value.ToString())
            {
                this.isCustomSelectBy = true;
            }
            tvTreeView.SelectedNode = FindNodeByTag(tvTreeView.Nodes, value);
            return SetTextValue();
        }


        public bool SelectByText(string value)
        {
            return SelectNodeByText(value);
        }

        public bool SelectByValue(object value)
        {
            return SelectNodeByTag(value);
        }

        #endregion

        #region 填充Tree

        /// <summary>
        /// 填充Tree
        /// </summary>
        /// <param name="filterExpression">起始数据筛选方法如:"ParentId=0"</param>
        /// <param name="dt">格式，三列，Id,Name,ParentId,只要顺序一样就可以了</param>
        public void Fill(DataTable dt, string filterExpression)
        {
            TreeView treeview = tvTreeView;
            treeview.Nodes.Clear();

            //每个树的最上边添加一个：==请选择==
            TreeNode Node0 = new TreeNode();
            Node0.Text = "==请选择==";
            Node0.Tag = -1;
            treeview.Nodes.Add(Node0);

            DataTable temptbl = dt.Copy();
            DataView viewinfo = new DataView(temptbl);
            viewinfo.RowFilter = filterExpression;

            if (viewinfo.Count > 0)
            {
                foreach (DataRowView myRow in viewinfo)
                {
                    TreeNode Node1 = new TreeNode();
                    Node1.Text = myRow[1].ToString();
                    Node1.Tag = myRow[0];
                    treeview.Nodes.Add(Node1);
                    TraverseNode(Node1, Convert.ToInt32(myRow[0]), myRow, dt);
                }
            }

            if (treeview.Nodes.Count > 0)
            {
                treeview.ExpandAll();
            }

        }

        private void TraverseNode(TreeNode ParentNode, int ParentID, DataRowView ParentDV, DataTable dt)
        {
            DataTable temptbl = dt.Copy();
            DataView viewinfo = new DataView(temptbl);
            viewinfo.RowFilter = temptbl.Columns[2].ColumnName + " = " + ParentID;
            foreach (DataRowView myRow in viewinfo)
            {
                TreeNode myNode = new TreeNode();
                myNode.Text = myRow[1].ToString();
                myNode.Tag = myRow[0];
                ParentNode.Nodes.Add(myNode);
                TraverseNode(myNode, Convert.ToInt32(myRow[0]), myRow, dt);
            }
        }

        #endregion


        public void Clear()
        {
            this.tvTreeView.Nodes.Clear();
            this.txtBack.Text = this.defaultText;
            this.txtBack.Tag = this.defaultValue;
        }
        #endregion

        #region Private Method

        public ComboBoxTree()
        {
            Control.CheckForIllegalCrossThreadCalls = false;//多线程用来改变他的状态
            this.InitializeComponent();

            // Initializing Controls
            this.txtBack = new TextBox();
            this.txtBack.ReadOnly = true;
            this.txtBack.Text = this.defaultText;
            this.txtBack.Tag = this.defaultValue;
            this.txtBack.BackColor = Color.White;
            this.txtBack.Cursor = System.Windows.Forms.Cursors.Default;
            //this.txtBack.Click += new EventHandler(ToggleTreeView);//可以不要


            this.btnSelect = new ButtonEx();
            this.btnSelect.Click += new EventHandler(ToggleTreeView);
            this.btnSelect.FlatStyle = FlatStyle.Flat;



            this.lblSizingGrip = new LabelEx();
            this.lblSizingGrip.Size = new Size(10, 10);
            this.lblSizingGrip.BackColor = Color.Transparent;
            this.lblSizingGrip.Cursor = Cursors.SizeNWSE;
            this.lblSizingGrip.MouseMove += new MouseEventHandler(SizingGripMouseMove);
            this.lblSizingGrip.MouseDown += new MouseEventHandler(SizingGripMouseDown);

            this.tvTreeView = new TreeView();
            this.tvTreeView.Dock = DockStyle.Fill;
            this.tvTreeView.BorderStyle = BorderStyle.None;
            this.tvTreeView.AfterSelect += new TreeViewEventHandler(TreeViewNodeSelect);
            this.tvTreeView.Location = new Point(0, 0);
            this.tvTreeView.LostFocus += new EventHandler(TreeViewLostFocus);


            this.frmTreeView = new Form();
            this.frmTreeView.FormBorderStyle = FormBorderStyle.None;
            this.frmTreeView.StartPosition = FormStartPosition.Manual;
            this.frmTreeView.ShowInTaskbar = false;
            this.frmTreeView.BackColor = System.Drawing.SystemColors.Control;


            this.pnlTree = new Panel();
            this.pnlTree.Dock = DockStyle.Fill;
            this.pnlTree.Padding = new Padding(0, 0, 8, 8);
            this.pnlTree.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTree.BackColor = Color.White;



            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Adding Controls to UserControl
            this.pnlTree.Controls.Add(this.lblSizingGrip);
            this.pnlTree.Controls.Add(this.tvTreeView);
            this.frmTreeView.Controls.Add(this.pnlTree);
            this.txtBack.Controls.AddRange(new Control[] { btnSelect });
            this.Controls.Add(this.txtBack);

        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ComboBoxTree
            // 
            this.Name = "ComboBoxTree";
            this.Size = new System.Drawing.Size(87, 26);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ComboBoxTree_Layout);
            this.ResumeLayout(false);

        }

        #endregion

        #region Events

        #region SizeGrip
        private void RelocateGrip()
        {
            this.lblSizingGrip.Top = this.frmTreeView.Height - lblSizingGrip.Height - 1;
            this.lblSizingGrip.Left = this.frmTreeView.Width - lblSizingGrip.Width - 1;
        }


        private void SizingGripMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int TvWidth, TvHeight;
                TvWidth = Cursor.Position.X - this.frmTreeView.Location.X;
                TvWidth = TvWidth + this.DragOffset.X;
                TvHeight = Cursor.Position.Y - this.frmTreeView.Location.Y;
                TvHeight = TvHeight + this.DragOffset.Y;

                if (TvWidth < 20)
                    TvWidth = 20;
                if (TvHeight < 20)
                    TvHeight = 20;

                this.frmTreeView.Size = new System.Drawing.Size(TvWidth, TvHeight);
                this.pnlTree.Size = this.frmTreeView.Size;
                this.tvTreeView.Size = new System.Drawing.Size(this.frmTreeView.Size.Width - this.lblSizingGrip.Width, this.frmTreeView.Size.Height - this.lblSizingGrip.Width);
                RelocateGrip();
            }
        }

        private void SizingGripMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int OffsetX = System.Math.Abs(Cursor.Position.X - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Right);
                int OffsetY = System.Math.Abs(Cursor.Position.Y - this.frmTreeView.RectangleToScreen(this.frmTreeView.ClientRectangle).Bottom);

                this.DragOffset = new Point(OffsetX, OffsetY);
            }
        }
        #endregion


        uint WM_LBUTTONDOWN = 0x0201;
        uint WM_LBUTTONUP = 0x0202;

        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private void ToggleTreeView(object sender, EventArgs e)
        {
            if (!this.frmTreeView.Visible)
            {
                Rectangle CBRect = this.RectangleToScreen(this.ClientRectangle);
                this.frmTreeView.Location = new System.Drawing.Point(CBRect.X, CBRect.Y + this.txtBack.Height);

                this.frmTreeView.Show();
                this.frmTreeView.BringToFront();

                this.RelocateGrip();
            }
            else
            {
                if (hitnumber == 0)
                {
                    hitnumber++;
                }
                else
                {
                    this.frmTreeView.Hide();
                    //chakman mark 如果窗口不close,又没有show新form,要取得焦点可以模拟点击
                    //按下鼠标左键
                    PostMessage(this.Handle, WM_LBUTTONDOWN, 0, 0);
                    //放开鼠标左键
                    PostMessage(this.Handle, WM_LBUTTONUP, 0, 0);
                    this.txtBack.Focus();
                    this.txtBack.SelectAll();
                }


            }
        }

        private void TreeViewLostFocus(object sender, EventArgs e)
        {
            try
            {
                if (!this.btnSelect.RectangleToScreen(this.btnSelect.ClientRectangle).Contains(Cursor.Position))
                    this.frmTreeView.Hide();
            }
            catch
            {
                this.frmTreeView.Hide();

            }


        }

        private void TreeViewNodeSelect(object sender, EventArgs e)
        {
            if (this.isCustomSelectBy == true)
            {
                this.isCustomSelectBy = false;
                return;
            }

            if (this._absoluteChildrenSelectableOnly)
            {
                if (this.tvTreeView.SelectedNode.Nodes.Count == 0)
                {
                    this.txtBack.Text = this.tvTreeView.SelectedNode.Text;
                    this.txtBack.Tag = this.tvTreeView.SelectedNode.Tag;
                    this.ToggleTreeView(sender, null);
                }
            }
            else
            {
                this.txtBack.Text = this.tvTreeView.SelectedNode.Text;
                this.txtBack.Tag = this.tvTreeView.SelectedNode.Tag;
                this.ToggleTreeView(sender, null);
            }
        }


        private void ComboBoxTree_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            this.Height = this.txtBack.Height;
            this.txtBack.Size = new Size(this.Width, this.Height);

            this.btnSelect.Size = new Size(16, 16);
            this.btnSelect.Location = new Point(this.Width - this.btnSelect.Width - 4, 0);

            //this.frmTreeView.Size = new Size(this.Width, this.tvTreeView.Height);
            this.frmTreeView.Size = new Size(200, 100);

            this.pnlTree.Size = this.frmTreeView.Size;
            this.tvTreeView.Width = this.frmTreeView.Width - this.lblSizingGrip.Width;
            this.tvTreeView.Height = this.frmTreeView.Height - this.lblSizingGrip.Width;
            this.RelocateGrip();
        }

        #endregion

        #region LabelEx
        private class LabelEx : Label
        {
            /// <summary>
            /// 
            /// </summary>
            public LabelEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                System.Windows.Forms.ControlPaint.DrawSizeGrip(e.Graphics, System.Drawing.Color.Black, 1, 0, this.Size.Width, this.Size.Height);
            }
        }
        #endregion

        #region ButtonEx
        private class ButtonEx : Button
        {
            ButtonState state;

            /// <summary>
            /// 
            /// </summary>
            public ButtonEx()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.DoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                state = ButtonState.Pushed;
                base.OnMouseDown(e);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnMouseUp(MouseEventArgs e)
            {
                state = ButtonState.Normal;
                base.OnMouseUp(e);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, 0, 0, this.Width, this.Height, state);

            }
        }
        #endregion
    }
}