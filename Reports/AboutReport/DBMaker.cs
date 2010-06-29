using System;
using System.Data;


class DBMaker
{

    public static DataTable 学生成绩表()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("姓名", typeof(string)));
        dt.Columns.Add(new DataColumn("课程", typeof(string)));
        dt.Columns.Add(new DataColumn("成绩", typeof(decimal)));
        dt.Rows.Add("张三", "语文", 80);
        dt.Rows.Add("张三", "数学", 60);
        dt.Rows.Add("张三", "化学", 30);

        dt.Rows.Add("李四", "语文", 40);
        dt.Rows.Add("李四", "数学", 50);
        dt.Rows.Add("李四", "化学", 60);

        dt.Rows.Add("王五", "语文", 70);
        dt.Rows.Add("王五", "数学", 90);
        dt.Rows.Add("王五", "化学", 20);
        return dt;
    }


    public static DataTable 文章表()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Id", typeof(int)));
        dt.Columns.Add(new DataColumn("ArticleType", typeof(string)));
        dt.Columns.Add(new DataColumn("txtTitle", typeof(string)));
        dt.Columns.Add(new DataColumn("AddTime", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("UserName", typeof(string)));
        for (int i = 0; i < 2000; i++)
        {
            dt.Rows.Add(i, "[中心文件]", "标题" + i.ToString().PadRight(50, '='), DateTime.Now.Date.AddHours(i), "柳永法" + i);
        }
        return dt;
    }

    public static DataTable 班级表()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("班级名称", typeof(string)));
        dt.Columns.Add(new DataColumn("几年级", typeof(string)));
        dt.Rows.Add("一班", "一年级");
        dt.Rows.Add("二班", "一年级");
        dt.Rows.Add("三班", "一年级");

        return dt;
    }


    public static DataTable 学生表()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("姓名", typeof(string)));
        dt.Columns.Add(new DataColumn("年龄", typeof(string)));
        dt.Columns.Add(new DataColumn("性别", typeof(string)));
        dt.Columns.Add(new DataColumn("班级名称", typeof(string)));

        for (int i = 0; i < 10; i++)
        {
            dt.Rows.Add("柳永法" + i, i.ToString(), "男", "一班");
        }

        for (int i = 0; i < 10; i++)
        {
            dt.Rows.Add("王磊" + i, i.ToString(), "男", "二班");
        }

        for (int i = 0; i < 10; i++)
        {
            dt.Rows.Add("曾建新" + i, i.ToString(), "男", "三班");
        }


        return dt;
    }

    public static DataTable 人员表()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("姓名", typeof(string)));
        dt.Columns.Add(new DataColumn("所在部门", typeof(string)));
        dt.Columns.Add(new DataColumn("工资", typeof(decimal)));
        dt.Columns.Add(new DataColumn("行号", typeof(int)));
        dt.Columns.Add(new DataColumn("列号", typeof(int)));


        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 5; j++)
			{
                 dt.Rows.Add("柳永法" + i,"技术部", i,i,j);
			}
           
        }


        return dt;
    }



}
