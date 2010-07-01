using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 注册表操作之历史浏览记录
{
    public partial class 注册表操作之历史浏览记录管理 : Form
    {
        public 注册表操作之历史浏览记录管理()
        {
            InitializeComponent();
        }

        private void 注册表浏览记录管理_Load(object sender, EventArgs e)
        {

        }
        private void inputurls()
        {
            dgv1.Rows.Clear();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\TypedUrls", true);

            string[] subvalueNames;

            subvalueNames = key.GetValueNames();

            foreach (string valueName in subvalueNames)
            {
                dgv1.Rows.Add(false, key.GetValue(valueName));

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(Convert.ToString(e.ColumnIndex));
            if (e.ColumnIndex > 0)
                System.Diagnostics.Process.Start("Iexplore.exe", dgv1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                dgv1.Rows[i].Cells[0].Value = !Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = dgv1.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dgv1.Rows[i].Cells[0].Value) == true)
                {
                    dgv1.Rows.RemoveAt(dgv1.Rows[i].Index);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\TypedUrls", true);

            string[] subvalueNames = key.GetValueNames();
            foreach (string valueName in subvalueNames)
            {
                key.DeleteValue(valueName);
            }


            for (int i = 0; i < dgv1.RowCount; i++)
            {
                key.SetValue("url" + i, dgv1.Rows[i].Cells[1].Value);
            }
            MessageBox.Show("保存成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputurls();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dgv1.Rows.Add(false, "http://www.xujiwei.cn/blog/");
            dgv1.Rows.Add(false, "http://www.cmdos.net");
            dgv1.Rows.Add(false, "http://www.rootkit.net.cn");
            dgv1.Rows.Add(false, "http://www.myfirm.cn");
            dgv1.Rows.Add(false, "http://bbs.verybat.cn/forumdisplay.php?fid=61");
            dgv1.Rows.Add(false, "http://www.radys.cn");
            dgv1.Rows.Add(false, "http://www.zfnn.com/");
            dgv1.Rows.Add(false, "http://www.zewen.cn");
            dgv1.Rows.Add(false, "http://www.jiangyao.com");
            dgv1.Rows.Add(false, "http://www.huaidan.org/blog/");
            dgv1.Rows.Add(false, "http://www.qicaispace.net/blog/");
            dgv1.Rows.Add(false, "http://www.jiangyao.net");
            dgv1.Rows.Add(false, "http://www.haixiaIT.com");
            dgv1.Rows.Add(false, "http://www.auiou.com/");
            dgv1.Rows.Add(false, "http://www.yesky.com/imagesnew/software/vbscript/head.html");
            dgv1.Rows.Add(false, "http://www.w3schools.com/");
            dgv1.Rows.Add(false, "http://www.microsoft.com/china/technet/community/scriptcenter/default.mspx");
            dgv1.Rows.Add(false, "http://www.activexperts.com/activmonitor/windowsmanagement/scripts/networking/windowsfirewall/");
            dgv1.Rows.Add(false, "http://www.readlog.cn/");
            dgv1.Rows.Add(false, "http://bbs.cn-dos.net");
            dgv1.Rows.Add(false, "http://www.anti-spam.org.cn/");
            dgv1.Rows.Add(false, "http://www.xfocus.net/");
            dgv1.Rows.Add(false, "http://www.vbgood.com");
            dgv1.Rows.Add(false, "http://www.papozhe.com/");
            dgv1.Rows.Add(false, "http://www.gxjss.cn/zblog/");
            dgv1.Rows.Add(false, "http://www.tool.la/");
            dgv1.Rows.Add(false, "http://www.aixinshe.net");
            dgv1.Rows.Add(false, "http://www.chizone.cn");
            dgv1.Rows.Add(false, "http://www.yongfa365.com/blog/item/f9be52ef5d215bd0.htm");
            dgv1.Rows.Add(false, "http://www.ky530.com/blog/");
            dgv1.Rows.Add(false, "http://zzwzz.cn");
            dgv1.Rows.Add(false, "http://www.windsfly.cn/blog/");
            dgv1.Rows.Add(false, "http://www.51qqkongjian.com");
            dgv1.Rows.Add(false, "http://soft.ylmf.com/ylmf.html");
            dgv1.Rows.Add(false, "http://www.gupiaoji.com/");


        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Iexplore.exe", "http://www.yongfa365.com/");
        }
    }
}