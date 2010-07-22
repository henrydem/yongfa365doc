using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 下载地址批量转换工具
{
    public partial class Form1 : Form
    {
        public string msg = "此处可以输入各种地址，一行一个地址，转换后会转换为同一种地址";
        public Form1()
        {
            InitializeComponent();
        }

        private string ToBase64String(string str)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(str));
        }
        private string FromBase64String(string str)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(str));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Iexplore.exe", "http://www.yongfa365.com/?下载地址批量转换工具");
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            D.Text = "";
            foreach (string nowurl in S.Text.Split('\n'))
            {
                try
                {
                    string text = nowurl;
                    string str2 = string.Empty;
                    string str3 = string.Empty;
                    string str4 = string.Empty;

                    if (text.ToLower().StartsWith("thunder://"))
                    {
                        str2 = text.Substring(10);
                        str2 = FromBase64String(str2);
                        str4 = str2.Substring(2, str2.Length - 4);
                    }
                    else if (text.ToLower().StartsWith("flashget://"))
                    {
                        str2 = text.Substring(11);
                        if (str2.Contains("&"))
                        {
                            str2 = str2.Substring(0, str2.IndexOf("&"));
                        }
                        str2 = FromBase64String(str2);
                        str4 = str2.Substring(10, str2.Length - 20);
                    }
                    else if (text.ToLower().StartsWith("qqdl://"))
                    {
                        str2 = text.Substring(7);
                        str2 = FromBase64String(str2);
                        str4 = str2.Substring(0, str2.Length);
                    }
                    else
                    {
                        str4 = text;
                    }


                    if (rdnormal.Checked)
                    {
                        str3 = str4;
                    }
                    else if (rdxunlei.Checked)
                    {
                        str3 = "thunder://" + ToBase64String("AA" + str4 + "ZZ");
                    }
                    else if (rdflashget.Checked)
                    {
                        str3 = "flashget://" + ToBase64String("[FLASHGET]" + str4 + "[FLASHGET]");
                    }
                    else if (rdxuanfeng.Checked)
                    {
                        str3 = "qqdl://" + ToBase64String(str4);
                    }
                    D.Text += str3 + "\n";
                }
                catch (Exception)
                {
                    D.Text += "*******************有误*******************\n";
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            S.Text = msg;
        }

        private void S_MouseClick(object sender, MouseEventArgs e)
        {
            if (S.Text == msg)
            {
                S.Text = "";
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            S.Text = @"
http://www.yongfa365.com/
thunder://QUHO0rXEYmxvZzogaHR0cDovL3d3dy55b25nZmEzNjUuY29tL1pa
thunder://QUFodHRwOi8vZG93bmxvYWQubWljcm9zb2Z0LmNvbS9kb3dubG9hZC8yLzAvZS8yMGU5MDQxMy03MTJmLTQzOGMtOTg4ZS1mZGFhNzlhOGFjM2QvZG90bmV0ZngzNS5leGVaWg==
flashget://W0ZMQVNIR0VUXWh0dHA6Ly93d3cueW9uZ2ZhMzY1LmNvbS9bRkxBU0hHRVRd
qqdl://aHR0cDovL3d3dy55b25nZmEzNjUuY29tLw==
".Substring(2);
        }

    }
}
