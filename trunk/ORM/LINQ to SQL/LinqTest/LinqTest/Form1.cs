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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();

            for (int i = 1; i < 5; i++)
            {
                Category cat = new Category() { Category1 = "分类" + i };
                data.Category.InsertOnSubmit(cat);
            }


            for (int i = 0; i < 100; i++)
            {

                Articles art = new Articles()
                {
                    txtTitle = "title" + DateTime.Now.Second,
                    txtContent = "内容" + DateTime.Now.Second,
                    CategoryId = i % 3
                };
                data.Articles.InsertOnSubmit(art);
            }

            data.SubmitChanges();
            dgv1.DataSource = data.Articles;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();

            int nowId = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            Articles art = data.Articles.First(a => a.Id == nowId);


            data.Articles.DeleteOnSubmit(art);
            data.SubmitChanges();

            dgv1.DataSource = data.Articles;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();

            int nowId = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
            //int nowId = (dataGridView1.CurrentRow.DataBoundItem as Articles).Id;

            Articles art = data.Articles.First(a => a.Id == nowId);
            art.txtTitle = "改变后的东西" + DateTime.Now.ToString();

            data.SubmitChanges();

            dgv1.DataSource = data.Articles;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("log.txt", true);
            LinqDB data = new LinqDB();
            data.Log = writer;


            var ds = from cat in data.Category
                     from art in data.Articles
                     where art.CategoryId == cat.Id && data.GetOrderId() != "1"
                     select new { 编号 = art.Id, 标题 = art.txtTitle, 内容 = art.txtContent, 添加时间 = art.AddTime, 分类 = cat.Category1 };

            //使用GetCommand输出IQueryable所生成的CommandText
            Console.WriteLine(data.GetCommand(ds).CommandText);

            var 条件查询 = data.Articles.Where(art => art.Id % 2 == 0).Where(art => art.txtTitle.Length > 5);
            var 分页 = (from art in data.Articles select art).Skip(10).Take(10);

            //分页，跳过几条，获取几条
            var 分页2 = data.Articles.Skip(10).Take(10);

            {
                string _txtTitle = "3";
                string _txtContent = null;
                int? _id = null;

                var ds2 = from cat in data.Category
                          from art in data.Articles
                          where art.CategoryId == cat.Id && data.GetOrderId() != "1" &&
                          (_txtTitle == null || art.txtTitle.Contains(_txtTitle)) &&
                            (_txtContent == null || art.txtContent.Contains(_txtContent)) &&
                            (_id == null || art.Id > _id)
                          select new { 编号 = art.Id, 标题 = art.txtTitle, 内容 = art.txtContent, 添加时间 = art.AddTime, 分类 = cat.Category1 };

                dgv1.DataSource = ds2;

            }
            // dataGridView1.DataSource = ds;


            writer.Close();
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            LinqDB data = new LinqDB();
            //数据库不存在的话，创建数据库，数据库默认值、函数不会被创建
            if (!data.DatabaseExists())
            {
                data.CreateDatabase();
            }

            #region 直接执行SQL语句，及通过SQL返回对象
            {
                //直接用{0}而不是'{0}'
                data.ExecuteCommand("insert into Articles(txtTitle,txtContent,CategoryId) values ({0},{1},1)", "SQL生成的标题", "SQL生成的内容");

                //sql查询里多一列不会出错，但少一列会出错
                dgv1.DataSource = data.ExecuteQuery<Articles>("select * from Articles where id%3=0", "").ToList();

                dgv1.DataSource = data.ExecuteQuery(typeof(Articles), "select * from Articles where id%3=0", "").Cast<Articles>().ToList();
            }
            #endregion

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
