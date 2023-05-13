using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SQLProject
{
    class DataAccess
    {
        private static string cnnStr = "";

        public static List<T> GetData<T>(string sql)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(cnnStr))
                {
                    return conn.Query<T>(sql).ToList();
                }
            }

            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public static List<T> GetDataProc<T>(string sql, object? param = null)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(cnnStr))
                {
                    return conn.Query<T>(sql, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public static void SQLQuery(string s)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(cnnStr))
                {
                    conn.Execute(s);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static void SQLQueryProc(string s, object? param = null)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(cnnStr))
                {
                    conn.Execute(s, param);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
