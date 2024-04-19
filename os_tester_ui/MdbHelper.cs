using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace os_tester_ui
{
    public class MdbHelper
    {
        private static OleDbConnection myConn;
        
        /// <summary>
        /// 初始化连接数据库
        /// </summary>
        /// <param name="dbFilePath">数据库文件路径</param>
        public MdbHelper(string dbFilePath)
        {
            try
            {
                //创建一个 OleDbConnection对象
                //string strCon = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + address;
                string strCon = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", dbFilePath);
                myConn = new OleDbConnection(strCon);
                myConn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("初始化连接数据库连接失败:{0}", ex.Message));
            }
        }

        /// <summary>
        /// 关闭数据连接
        /// </summary>
        public void CloseConnection()
        {
            myConn.Close();
        }

        /// <summary>
        ///在mdb中创建一个类型和datatable一致的空表
        /// </summary>
        /// <param name="tableName"></param>
        public void CreateTable(string tableName, DataTable dt)
        {
            try
            {
                string sql = "create table " + tableName;
                string tableAttribute = "";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    tableAttribute = tableAttribute + dt.Columns[i].ColumnName + " " + GetType(dt.Columns[i].DataType.ToString());
                    if (i < dt.Columns.Count - 1)
                    {
                        tableAttribute = tableAttribute + ",";
                    }
                }
                sql = sql + "(" + tableAttribute + ");";
                OleDbCommand cmd = new OleDbCommand(sql, myConn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // todo

                throw ex;
            }
        }

        /// <summary>
        /// 将datatable导入对应名字的表中
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="dt"></param>
        public void DatatableToMdb(string name, DataTable dt)
        {
            try
            {
                string strCom = string.Format("select * from {0}", name);
                OleDbDataAdapter da = new OleDbDataAdapter(strCom, myConn);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(da);//这里的CommandBuilder对象一定不要忘了,一般就是写在DataAdapter定义的后面
                cb.QuotePrefix = "[";
                cb.QuoteSuffix = "]";
                DataSet midData = new DataSet();
                da.Fill(midData, name);
                foreach (DataRow dR in dt.Rows)
                {
                    DataRow dr = midData.Tables[name].NewRow();
                    dr.ItemArray = dR.ItemArray;//行复制
                    midData.Tables[name].Rows.Add(dr);
                }
                da.Update(midData, name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取创建mdb表格的属性字段类型
        /// </summary>
        /// <param name="datatype"></param>
        /// <returns></returns>
        private string GetType(string datatype)
        {
            switch (datatype)//匹配类型选择
            {
                case "System.String":
                    return "TEXT(50)";
                case "System.DateTime":
                    return "DateTime";
                case "System.Double":
                    return "Double";
                case "System.Int32":
                case "System.Int16":
                case "System.Int64":
                    return "Int";
                default:
                    return "TEXT(50)";
            }
        }

        /// <summary>
        /// 创建Access数据库
        /// </summary>
        /// <param name="dbFilePath">文件和文件路径</param>
        /// <returns>真为创建成功，假为创建失败或是文件已存在</returns>
        public static bool CreateAccessDatabase(string dbFilePath)
        {
            //如果文件存在反回假
            if (File.Exists(dbFilePath))
            {
                MessageBox.Show("文件已存在！");
                return false;
            }

            try
            {
                //如果目录不存在，则创建目录
                string dirName = Path.GetDirectoryName(dbFilePath);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }

                //创建Catalog目录类
                ADOX.CatalogClass catalog = new ADOX.CatalogClass();

                string _connectionStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", dbFilePath);
                //根据联结字符串使用Jet数据库引擎创建数据库
                catalog.Create(_connectionStr);

                //要加上下面这两句，否则创建文件后会有*.ldb文件，一直到程序关闭后才消失 
                //原因参考   https://blog.csdn.net/baple/article/details/8131717
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(catalog.ActiveConnection);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(catalog);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("数据库创建失败:{0}", ex.Message));
            }
        }

        /// <summary>
        /// 获取当前连接的mdb中的所有表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTables()
        {
            DataTable dt = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            List<string> tableNameList = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                String tableName = dt.Rows[i]["TABLE_NAME"].ToString();
                tableNameList.Add(tableName);
            }
            return tableNameList;
        }

        /// <summary>
        /// 获取当前传入表名中的表内的所有字段信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<Dictionary<string, OleDbType>> GetFields(string tableName)
        {
            DataTable schemaTable;
            List<Dictionary<string, OleDbType>> Fields = new List<Dictionary<string, OleDbType>>();
            schemaTable = myConn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new Object[] { null, null, tableName, null });
            for (int j = 0; j < schemaTable.Rows.Count; j++)
            {
                Dictionary<string, OleDbType> dic = new Dictionary<string, OleDbType>();
                string fieldName = schemaTable.Rows[j]["COLUMN_NAME"].ToString();
                OleDbType type = (OleDbType)schemaTable.Rows[j]["DATA_TYPE"];
                dic.Add(fieldName, type);
                Fields.Add(dic);
            }
            return Fields;
        }

        /// <summary> 
        /// 根据SQL命令返回一个DataTable
        /// </summary> 
        /// <param name="sql">sql/param> 
        /// <returns>DataTable</returns> 
        public DataTable GetDataTable(string sql)
        {
            DataTable ds = new DataTable();
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, myConn);
                adapter.Fill(ds);
            }
            catch (Exception)
            {
                throw new Exception("sql语句：" + sql + " 执行失败！");
            }
            return ds;
        }

        /// <summary>
        /// 按行获取数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IDataReader QueryReader(string sql)
        {
            lock (myConn)
            {
                bool fClose = myConn.State != ConnectionState.Open;
                try
                {
                    if (fClose)
                        myConn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, myConn);
                    return cmd.ExecuteReader();
                }
                catch (Exception)
                {
                    throw new Exception("sql语句：" + sql + " 执行失败！");
                }
            }
        }

        /// <summary>
        /// 用于查询数据条数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int QueryOneInt(string sql)
        {
            using (var dr = QueryReader(sql))
            {
                if (dr.Read())
                {
                    var o = dr.GetValue(0);
                    return Convert.ToInt32(o);
                }
                return 0;
            }
        }

        /// <summary>
        /// 执行 SQL 命令返回执行结果
        /// </summary>
        /// <param name="sql">SQL 命令</param>
        /// <returns>执行结果</returns>
        public string GetSqlResult(string sql)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, myConn);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("执行 SQL 命令失败: " + ex.Message);
            }
        }
    }
}
