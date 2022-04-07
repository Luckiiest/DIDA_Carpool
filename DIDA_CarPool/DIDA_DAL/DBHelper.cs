using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DIDA_DAL
{
    public class DBHelper
    {
        static string connstr = "Data Source=.;Initial Catalog=DIDA_DB;Integrated Security=True";
        static SqlConnection conn = new SqlConnection(connstr);


        /// <summary>
        /// 初始化数据连接
        /// </summary>
        public static void init()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connstr);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }


        /// <summary>
        /// 查询，获取DataReader
        /// </summary>
        /// <param name="sqlConstr"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sqlConstr)
        {
            init();
            SqlCommand cmd = new SqlCommand(sqlConstr, conn);
            //commandBehavior.CloseConnection 命令行为：当DataReader对象被关闭时，自动关闭连接对象
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            init();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            adp.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql)
        {
            init();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int retus = cmd.ExecuteNonQuery();
            conn.Close();
            return retus > 0;
        }

        //聚合查询
        public static object ExecuteScalar(string sql)
        {
            init();
            SqlCommand cmd = new SqlCommand(sql, conn);
            object r = cmd.ExecuteScalar();
            conn.Close();
            return r;
        }
    }
}
