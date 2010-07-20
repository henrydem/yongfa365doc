using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


class DBMaker
{
    public static DataTable GetCity()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Id", typeof(int)));
        dt.Columns.Add(new DataColumn("txtName", typeof(string)));
        dt.Columns.Add(new DataColumn("ParentId", typeof(int)));
        dt.Rows.Add(1, "北京", 0);
        dt.Rows.Add(2, "山西", 0);

        dt.Rows.Add(3, "朝阳区", 1);
        dt.Rows.Add(4, "海淀区", 1);

        dt.Rows.Add(5, "豆各庄", 3);
        dt.Rows.Add(6, "十里堡", 3);
        dt.Rows.Add(7, "中关村", 4);

        dt.Rows.Add(8, "运城地区", 2);
        dt.Rows.Add(9, "太原市", 2);
        dt.Rows.Add(10, "永济市", 8);
        dt.Rows.Add(11, "西文学", 10);
        dt.Rows.Add(12, "东文学", 10);
        dt.Rows.Add(13, "南文学", 10);
        return dt;
    }
}

