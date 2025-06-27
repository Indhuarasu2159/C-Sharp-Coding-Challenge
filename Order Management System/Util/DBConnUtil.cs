using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Util
{
    public class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string server = DBPropertyUtil.GetProperty("server");
            string port = DBPropertyUtil.GetProperty("port");
            string database = DBPropertyUtil.GetProperty("database");
            string user = DBPropertyUtil.GetProperty("user");
            string password = DBPropertyUtil.GetProperty("password");
            string useWindowsAuth = DBPropertyUtil.GetProperty("useWindowsAuth");

            string connStr;

            if (useWindowsAuth == "true")
            {
                connStr = $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                connStr = $"Server={server},{port};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";
            }

            return new SqlConnection(connStr);
        }
    }
}
