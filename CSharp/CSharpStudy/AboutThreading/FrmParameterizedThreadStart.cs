using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AboutThreading
{
    public partial class FrmParameterizedThreadStart : Form
    {
        public FrmParameterizedThreadStart()
        {
            InitializeComponent();
        }

        public void Calc(object obj)
        {
            Thread.Sleep(5000);
            MyClass cls = obj as MyClass;
            MessageBox.Show(cls.UserName);
        }

        public void Calc()
        {
            Thread.Sleep(6000);
            MessageBox.Show("Test");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyClass cls = new MyClass();
            cls.UserName = "柳永法";
            cls.PassWord = "花飘万家雪";


            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(cls);


            t2 = new Thread(new ThreadStart(Calc));
            t2.Start();

        }

        private void FrmParameterizedThreadStart_Load(object sender, EventArgs e)
        {

        }
    }

    class MyClass
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
