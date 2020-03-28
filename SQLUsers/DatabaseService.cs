using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class DatabaseService
    {
        private static MySqlConnection connection;
        public static MySqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection("server=localhost;database=users_test;uid=root;");
                connection.Open();
            }
            return connection;
        }
    }
}
