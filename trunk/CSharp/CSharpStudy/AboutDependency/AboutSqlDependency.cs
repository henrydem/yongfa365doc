using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace AboutDependency
{

    //    CREATE TABLE [dbo].[Messages](
    //    [ID] [int] IDENTITY(1,1) NOT NULL,
    //    [UserID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
    //    [Message] [nvarchar](256) COLLATE Chinese_PRC_CI_AS NOT NULL,
    // CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
    //(
    //    [ID] ASC
    //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) 

    //ON [PRIMARY]
    //)

    class AboutSqlDependency
    {
        private static string ConnectionString = "Data Source=.;Initial Catalog=hehehehe;Integrated Security=True";

        static void Run()
        {
            SqlDependency.Start(ConnectionString);//传入连接字符串,启动基于数据库的监听
            UpdateGrid();

            Console.Read();
        }


        private static void UpdateGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //依赖是基于某一张表的,而且查询语句只能是简单查询语句,不能带top或*,同时必须指定所有者,即类似[dbo].[]
                using (SqlCommand command = new SqlCommand("select ID,UserID,[Message] From [dbo].[Messages] where id>0", connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        Console.WriteLine();
                        while (sdr.Read())
                        {
                            Console.WriteLine(
                                "Id:{0}\tUserId:{1}\tMessage:{2}",
                                sdr["ID"].ToString(), sdr["UserId"].ToString(),
                                sdr["Message"].ToString()
                                );
                        }
                    }

                }
            }
        }


        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            UpdateGrid();
        }
    }
}
