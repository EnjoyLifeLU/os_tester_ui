using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace os_tester_ui
{
    public class SQLiteHelper
    {
        private SQLiteConnection connection;

        /// <summary>
        /// 初始化连接数据库
        /// </summary>
        /// <param name="dbFilePath">SQLite数据库文件路径</param>
        public SQLiteHelper(string dbFilePath)
        {
            try
            {
                // 创建一个 SQLiteConnection 对象
                string connectionString = String.Format("Data Source={0};Version=3;", dbFilePath);
                connection = new SQLiteConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("初始化连接数据库连接失败: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 关闭数据连接
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// 在SQLite数据库中创建一个与DataTable一致的空表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dt">DataTable对象</param>
        public void CreateTable(string tableName, DataTable dt)
        {
            try
            {
                string sql = String.Format("CREATE TABLE {0} (", tableName);
                string tableAttributes = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    tableAttributes += String.Format("{0} {1}", dt.Columns[i].ColumnName, GetType(dt.Columns[i].DataType.ToString()));
                    if (i < dt.Columns.Count - 1)
                    {
                        tableAttributes += ",";
                    }
                }
                sql += tableAttributes + ");";
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取创建SQLite表格的属性字段类型
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <returns>对应的SQLite数据类型</returns>
        private string GetType(string dataType)
        {
            switch (dataType)
            {
                case "System.String":
                    return "TEXT";
                case "System.DateTime":
                    return "DATETIME";
                case "System.Double":
                    return "REAL";
                case "System.Int32":
                case "System.Int16":
                case "System.Int64":
                    return "INTEGER";
                default:
                    return "TEXT";
            }
        }

        /// <summary>
        /// 创建SQLite数据库文件
        /// </summary>
        /// <param name="dbFilePath">数据库文件路径</param>
        /// <returns>是否创建成功</returns>
        public static bool CreateSQLiteDatabase(string dbFilePath)
        {
            // 如果文件存在则返回false
            if (File.Exists(dbFilePath))
            {
                Console.WriteLine("文件已存在！");
                return false;
            }

            try
            {
                // 创建数据库文件
                SQLiteConnection.CreateFile(dbFilePath);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("数据库创建失败: {0}", ex.Message));
            }
        }

        /// <summary>
        /// 执行SQL命令并返回一个DataTable
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>执行结果</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL命令失败: {0}", ex.Message));
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL命令返回执行结果
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>执行结果</returns>
        public string GetSqlResult(string sql)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                return cmd.ExecuteScalar().ToString();;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("执行SQL命令失败: {0}", ex.Message));
            }
        }
    }
}
