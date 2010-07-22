using System;
using System.Data;

namespace ClassLibrary1
{
    public class DBMaker
    {
        public static DataTable 人员表()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("年龄", typeof(int)));
            dt.Columns.Add(new DataColumn("身高", typeof(decimal)));
            dt.Columns.Add(new DataColumn("出生日期", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("已婚", typeof(bool)));

            for (int i = 0; i < 10000; i++)
            {
                dt.Rows.Add("柳永法" + i, i, (decimal)i / 2, DateTime.Parse("1983-1-1").AddDays(i), i % 3 == 0 ? true : false);
            }
            return dt;
        }

    }

}
