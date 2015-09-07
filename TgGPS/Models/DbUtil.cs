using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MySql.Data.MySqlClient;

namespace TgGPS.Models
{
    public class DbUtil
    {
        public static readonly string ConnectString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public static IDbConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectString);
            connection.Open();
            return connection;
        }

        public static IDbConnection GetConnection(string conStr)
        {
            var connection = new SqlConnection(conStr);
            connection.Open();
            return connection;
        }

        public static int Execute(string sql, object parameters, CommandType? cmdType = null)
        {
            using (var con = GetConnection())
            {
                return con.Execute(sql, parameters, commandType:cmdType);
            }
        }

        public static IEnumerable<T> Query<T>(string sql, object parameters, CommandType? cmdType = null)
        {
            using (var con = GetConnection())
            {
                return con.Query<T>(sql, parameters, commandType: cmdType);
            }
        }
    }
}