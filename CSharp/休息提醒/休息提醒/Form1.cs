using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace 锁定计算机
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        public static extern void LockWorkStation();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxTime.SelectedIndex = 0;
            cbxOpt.SelectedIndex = 0;
            foreach (var item in Environment.GetCommandLineArgs())
            {
                if (item.ToLower()=="/start")
                {
                    Start();
                }
                else if (item.ToLower()=="/stop")
                {
                    Stop();
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Start();
        }

        void Start()
        {
            timer1.Interval = Convert.ToInt32(Regex.Match(cbxTime.Text, "\\d+").Value) * 60 * 1000;
            timer1.Enabled = true;
            btnRun.Enabled = false;
            btnStop.Enabled = true;
            cbxOpt.Enabled = false;
            cbxTime.Enabled = false;
        
        }

        void Stop()
        {
            timer1.Enabled = false;
            btnRun.Enabled = true;
            btnStop.Enabled = false;

            cbxOpt.Enabled = true;
            cbxTime.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbxOpt.Text == "关闭显示器")
            {
                SendMessage(this.Handle.ToInt32(), 0x112, 0xF170, 2); //关闭   
               // SendMessage(this.Handle.ToInt32(), 0x112, 0xF170, -1); //打开
            }
            else if (cbxOpt.Text == "锁定计算机")
            {
                LockWorkStation();
            }
            else if (cbxOpt.Text == "锁定+黑屏")
            {
                LockWorkStation();
                SendMessage(this.Handle.ToInt32(), 0x112, 0xF170, 2); 
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Activate();
        }
    }
}
