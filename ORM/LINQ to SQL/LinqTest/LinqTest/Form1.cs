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
//Union,Concat生成多层select，效率问题



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
                     where art.CategoryId == cat.Id && data.GetOrderId() != "1"//调用自定义函数
                     select new { 编号 = art.Id, 标题 = art.txtTitle, 内容 = art.txtContent, 添加时间 = art.AddTime, 分类 = cat.Category1 };
            dgv1.DataSource = ds;


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
                dgv1.DataSource = data.ExecuteQuery<Articles>("select * from Articles where id%3=0").ToList();

                dgv1.DataSource = data.ExecuteQuery(typeof(Articles), "select * from Articles where id%3=0").Cast<Articles>().ToList();

                // 在dbml里 手动添加类_显示结果
                dgv1.DataSource = data.ExecuteQuery<手动添加类_显示结果>("select a.txtTitle 标题,a.txtContent 内容,c.Category 分类 from Articles a left join Category c on a.CategoryId=c.id").ToList();

            }
            #endregion

            #region 查询
            {

                Dictionary<string, IQueryable> dict = new Dictionary<string, IQueryable>();

                dict.Add("条件查询", null);
                dict["条件查询"] = data.Articles.Where(art => art.Id % 2 == 0).Where(art => art.txtTitle.Length > 5);


                dict.Add("分页", null);
                dict["分页"] = (from art in data.Articles select art).Skip(10).Take(10);


                //分页，跳过几条，获取几条
                dict.Add("分页2", null);
                dict["分页2"] = data.Articles.Skip(10).Take(10);


                dict.Add("存储过程", null);
                dict["存储过程"] = data.up_GetArticles("标题", "").AsQueryable();

                dict.Add("union", null);
                dict["union"] = (from art in data.Articles where art.Id < 10 select art).Union
                                (from art in data.Articles where art.Id > 15 && art.Id < 20 select art).Union
                                (from art in data.Articles where art.Id > 30 && art.Id < 40 select art);




                dict.Add("union_all用Concat实现", null);
                dict["union_all用Concat实现"] = (from art in data.Articles where art.Id < 10 select art).Concat
                                (from art in data.Articles where art.Id > 15 && art.Id < 20 select art).Concat
                                (from art in data.Articles where art.Id > 30 && art.Id < 40 select art);


                dict.Add("in操作", null);
                dict["in操作"] = from art in data.Articles
                               where new int[] { 1, 200, 3, 100 }.Contains(art.CategoryId)
                               select art;


                dict.Add("子查询", null);
                dict["子查询"] = from art in data.Articles
                              where (from cat in data.Category where cat.Id > 0 select cat.Id).Contains(art.CategoryId)
                              select art;


                dict.Add("InnerJoin", null);
                dict["InnerJoin"] = from art in data.Articles
                                    join cat in data.Category on art.CategoryId equals cat.Id
                                    select new { art.Id, art.txtTitle, cat.Category1 };


                dict.Add("LeftJoin", null);
                dict["LeftJoin"] = from art in data.Articles
                                   join cat in data.Category on art.CategoryId equals cat.Id into pro
                                   from x in pro.DefaultIfEmpty()
                                   select new { art.Id, art.txtTitle, x.Category1 };


                dict.Add("LeftJoinMore", null);
                dict["LeftJoinMore"] = from art in data.Articles
                                       join cat in data.Category on art.CategoryId equals cat.Id into pro
                                       join cat in data.Category on art.CategoryId equals cat.Id into pro2
                                       join cat in data.Category on art.CategoryId equals cat.Id into pro3
                                       from x in pro.DefaultIfEmpty()
                                       from y in pro.DefaultIfEmpty()
                                       from z in pro.DefaultIfEmpty()
                                       select new { art.Id, art.txtTitle, x.Category1, y = y.Category1, z = z.Category1 };


                dict.Add("distinct", null);
                dict["distinct"] = (from art in data.Articles orderby art.Id select art.CategoryId).Distinct();


                dict.Add("CaseWhen", null);
                dict["CaseWhen"] = from art in data.Articles
                                   select new
                                   {
                                       art.Id,
                                       art.txtTitle,
                                       ID能被3整除 = art.Id % 3 == 0,
                                       ID能被2整除 = art.Id % 2 == 0 ? "是" : "否",
                                   };


                dict.Add("GroupBy", null);
                dict["GroupBy"] = from art in data.Articles
                                  group art by art.CategoryId into g
                                  select new
                                  {
                                      g.Key,
                                      最大ID = g.Max(a => a.Id),
                                      数量 = g.Count(),
                                      ID之和 = g.Sum(a => a.Id)
                                  };

                #region 多条件_多个对象_动态查询    推荐
                string _txtTitle = "3";
                string _txtContent = null;
                int? _id = null;

                dict.Add("多条件_多个对象_动态查询", null);
                dict["多条件_多个对象_动态查询"] = from cat in data.Category
                                        from art in data.Articles
                                        where art.CategoryId == cat.Id && data.GetOrderId() != "1" &&
                                        (_txtTitle == null || art.txtTitle.Contains(_txtTitle)) &&
                                        (_txtContent == null || art.txtContent.Contains(_txtContent)) &&
                                        (_id == null || art.Id > _id)
                                        orderby art.Id descending, art.CategoryId ascending
                                        select new { 编号 = art.Id, 标题 = art.txtTitle, 内容 = art.txtContent, 添加时间 = art.AddTime, 分类 = cat.Category1 };

                #endregion


                #region 动态条件QueryWhere  次级推荐
                {
                    var 动态条件QueryWhere = from art in data.Articles
                                         join cat in data.Category
                                         on art.CategoryId equals cat.Id
                                         where art.Id % 2 == 0
                                         select new { art, cat };

                    动态条件QueryWhere = 动态条件QueryWhere.Where(p => (p.art.txtTitle.Contains("标题") || p.art.txtContent.Contains("标题") && p.cat.Id > 0));
                  
                    var 动态条件QueryWhere_OK=动态条件QueryWhere.Select(p => new { p.art, 分类 = p.cat.Category1 });

                    dgv1.DataSource = 动态条件QueryWhere_OK;

                    Console.WriteLine("{0}{1}{0}\r\n{2}\r\n\r\n", new string('=', 50), 
                        "动态条件QueryWhere",
                        data.GetCommand(动态条件QueryWhere_OK).CommandText);

                }
                #endregion


                #region Where动态条件查询之只查单个对象
                {
                    var Where动态条件查询之只查单个对象 = data.Articles.Where(a => a.CategoryId == 1);

                    if (true)
                    {
                        Where动态条件查询之只查单个对象 = Where动态条件查询之只查单个对象.Where(a => a.txtTitle.Contains("1"));
                    }

                    if (true)
                    {
                        Where动态条件查询之只查单个对象 = Where动态条件查询之只查单个对象.Where(a => a.txtTitle.Contains("1"));
                    }
                    dgv1.DataSource = Where动态条件查询之只查单个对象;

                    Console.WriteLine("{0}{1}{0}\r\n{2}\r\n\r\n", new string('=', 50),
                                "Where动态条件查询之只查单个对象",
                                data.GetCommand(Where动态条件查询之只查单个对象).CommandText);
                }
                #endregion

                //使用GetCommand输出IQueryable所生成的CommandText
                foreach (var item in dict)
                {
                    Console.WriteLine("{0}{1}{0}\r\n{2}\r\n\r\n", new string('=', 50), item.Key, data.GetCommand(item.Value).CommandText);
                    dgv1.DataSource = item.Value;
                }

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

    /// <summary>
    /// 暂时不知道怎么用
    /// 构造函数使用True时：单个AND有效，多个AND有效；单个OR无效，多个OR无效；混合时写在AND后的OR有效
    /// 构造函数使用False时：单个AND无效，多个AND无效；单个OR有效，多个OR有效；混合时写在OR后面的AND有效
    /// </summary>
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }

        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, invokedExpression), expression1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body, invokedExpression), expression1.Parameters);
        }
    }


}
