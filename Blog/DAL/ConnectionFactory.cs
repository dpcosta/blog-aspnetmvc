using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public class ConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Blog.mdf;Integrated Security=True");
        }
    }
}