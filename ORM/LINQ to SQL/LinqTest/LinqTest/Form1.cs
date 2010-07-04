using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Transactions;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LinqLib;


//动态条件查询，表达式树
//AddTime让系统自动生成
//外键问题
//用户定义函数



namespace LinqTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StreamWriter writer = new StreamWriter("log.txt", true);

            LinqDB data = new LinqDB();
            data.Log = writer;

            Category cat = new Category() { Category1 = "哈哈哈哈" };

            for (int i = 0; i < 100; i++)
            {
                Articles art = new Articles()
                {
                    txtTitle = "title" + DateTime.Now.Second,
                    txtContent = "内容" + DateTime.Now.Second,
                    CategoryId = i
                };
                cat.Articles.Add(art);

            }
            data.Category.InsertOnSubmit(cat);
            data.SubmitChanges();

            dataGridView1.DataSource = data.Articles;
            writer.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();

            int nowId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Articles art = data.Articles.Single(a => a.Id == nowId);


            data.Articles.DeleteOnSubmit(art);
            data.SubmitChanges();

            dataGridView1.DataSource = data.Articles;
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();

            int nowId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //int nowId = (dataGridView1.CurrentRow.DataBoundItem as Articles).Id;

            Articles art = data.Articles.Single(a => a.Id == nowId);
            art.txtTitle = "改变后的东西" + DateTime.Now.ToString();
            data.SubmitChanges();

            dataGridView1.DataSource = data.Articles;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("log.txt", true);
            LinqDB data = new LinqDB();
            data.Log = writer;


            var ds = from c in data.Category
                     from a in data.Articles

                     where a.CategoryId==c.Id  && data.ContainsOne(a.txtTitle,"4")==1
                     select new { a.Id, a.txtTitle, c.Category1 };

            dataGridView1.DataSource = ds;


            writer.Close();


            //DataLoadOptions options = new DataLoadOptions();
            //options.LoadWith<Articles>(p => p.AddTime);
            //data.LoadOptions = options;


        }


        //Expression<Func<Articles, Category, bool>> expr = (art, cat) => GetCondition(art, cat);

        //private bool GetCondition(Articles art, Category cat)
        //{
        //    bool boolResult = true;
        //    if ("" != string.Empty)
        //    {
        //        boolResult &= art.CategoryId == cat.Id;
        //    }

        //    return boolResult;
        //}
    }
}
