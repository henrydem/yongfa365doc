using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace AboutThreading
{
    public partial class FrmThreadUI : Form
    {
        delegate void UpdateUIDelegate(object obj);

        UpdateUIDelegate updater;

        public FrmThreadUI()
        {
            InitializeComponent();
            updater = new UpdateUIDelegate(Write2UI);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ThreadProc);
            t.IsBackground = true;
            t.Start();
        }

        void ThreadProc()
        {
            while (true)
            {
                MyClass cls = new MyClass();
                cls.dgv = "asdf,wer,234".Split(',');
                cls.chk = true;
                cls.txt = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss:fff");
                cls.cbx = "3";
                if (IsHandleCreated)
                {
                    this.Invoke(updater, cls);

                }

                Thread.Sleep(1000);
            }

        }
        void Write2UI(object obj)
        {
            MyClass cls = obj as MyClass;
            dataGridView1.Rows.Add(cls.dgv);
            textBox1.Text = cls.txt;
            checkBox1.Checked = cls.chk;
            comboBox1.Text = cls.cbx;
        }
        class MyClass
        {
            public string txt { get; set; }
            public string[] dgv { get; set; }
            public bool chk { get; set; }
            public string cbx { get; set; }
        }

        private void FrmThreadUI_Load(object sender, EventArgs e)
        {

        }
    }
}
