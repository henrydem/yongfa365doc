using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace AboutThreading
{
    public partial class FrmThreadUI2 : Form
    {
        public FrmThreadUI2()
        {
            InitializeComponent();
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
                    //Method 001
                    this.Invoke(new MethodInvoker(delegate()
                            {
                                dataGridView1.Rows.Add(cls.dgv);
                                textBox1.Text = cls.txt;
                                checkBox1.Checked = cls.chk;
                                comboBox1.Text = cls.cbx;
                            }));


                    //Method 002
                    this.Invoke(new MethodInvoker(() =>
                            {
                                dataGridView1.Rows.Add(cls.dgv);
                                textBox1.Text = cls.txt;
                                checkBox1.Checked = cls.chk;
                                comboBox1.Text = cls.cbx;
                            }));


                    //Method 003
                    this.SafeInvoke(() =>
                            {
                                dataGridView1.Rows.Add(cls.dgv);
                                textBox1.Text = cls.txt;
                                checkBox1.Checked = cls.chk;
                                comboBox1.Text = cls.cbx;
                            });
                }


                Thread.Sleep(1000);
            }
        }

        //线程上使用匿名方法计算，然后通过Invoke调用Lambda表达式写回UI
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Thread t = new Thread(delegate()
        //    {
        //        while (true)
        //        {
        //            MyClass cls = new MyClass();
        //            cls.dgv = "asdf,wer,234".Split(',');
        //            cls.chk = true;
        //            cls.txt = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss:fff");
        //            cls.cbx = "3";



        //            if (IsHandleCreated)
        //            {
        //                //Method 002
        //                this.Invoke(new MethodInvoker(() =>
        //                        {
        //                            dataGridView1.Rows.Add(cls.dgv);
        //                            textBox1.Text = cls.txt;
        //                            checkBox1.Checked = cls.chk;
        //                            comboBox1.Text = cls.cbx;
        //                        }));
        //            }


        //            Thread.Sleep(1000);
        //        }

        //    });
        //    t.IsBackground = true;
        //    t.Start();
        //}

        class MyClass
        {
            public string txt { get; set; }
            public string[] dgv { get; set; }
            public bool chk { get; set; }
            public string cbx { get; set; }
        }

    }
}
