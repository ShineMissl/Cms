using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            insertSingleData();
            insertMutilData();
            Console.ReadLine();
        }

        static void insertSingleData()
        {
            var content = new Content()
            {
                title = "Title1",
                content = "Content1"
            };
            using (var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Practice\\Cms\\DapperDemo\\DapperDemo\\Database1.mdf;Integrated Security=True"))
            {
                string sql_insert = @"Insert into [Content] 
                    values (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");

            }
        }

        /// <summary>
        /// 测试一次批量插入两条数据
        /// </summary>
        static void insertMutilData()
        {
            List<Content> contents = new List<Content>();
            contents.Add(new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            });
            contents.Add(new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            });

            using (var conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Practice\\Cms\\DapperDemo\\DapperDemo\\Database1.mdf;Integrated Security=True"))
            {
                string sql_insert = @"INSERT INTO [Content]
                    (title, [content], status, add_time, modify_time)
                    VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }
    }
}
