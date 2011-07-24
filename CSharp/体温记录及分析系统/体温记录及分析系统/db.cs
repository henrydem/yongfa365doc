using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace OleDbBase
{
    class DB
    {
        public OleDbConnection GetConn()
        {
            string strConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb";
            OleDbConnection objConnection = new OleDbConnection(strConnection);
            return objConnection;
        }

        public void Exec(string sql)
        {
            OleDbConnection conn = this.GetConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public void Exec(string[] sqls)
        {
            OleDbConnection conn = this.GetConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            foreach (string sql in sqls)
            {
                if (sql.Length > 10)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public void ExecScalar(string sql)
        {
            OleDbConnection conn = this.GetConn();
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteScalar();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public OleDbDataReader Read(string sql)
        {
            OleDbConnection conn = this.GetConn();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.Open();
            OleDbDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return rd;
        }



        public DataSet GetDataSet(string sql,string table)
        {
            OleDbConnection conn = this.GetConn();
            //conn.Open();//不明白为什么不用打开就可以
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            da.Fill(ds, table);
            return ds;
        }
    }
}
