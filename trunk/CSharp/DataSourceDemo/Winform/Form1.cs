using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lib;
//http://msdn.microsoft.com/zh-cn/library/dsb2zb51.aspx

//DataSource可绑定实现下列接口之一的任何类型：
//IList List<T>,
//IListSource DataTable,DataSet,DataView
//IBindingList BindingList<T>
//IBindingListView BindingSource


namespace Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBMaker.GetListMyClass();
            dataGridView1.DataSource = DBMaker.GetDataTable() ;
            dataGridView1.DataSource = DBMaker.GetDataTable().DefaultView;

            BindingSource bs = new BindingSource();
            bs.DataSource = DBMaker.GetDictionary();
            dataGridView1.DataSource = bs;

            dataGridView1.DataSource = DBMaker.GetList().Select(p => (new { 内容 = p })).ToList();

            dataGridView1.DataSource = DBMaker.GetDictionary().Select(p => (new { 编号 = p.Key, 内容 = p.Value })).ToList();


        }
    }
}
