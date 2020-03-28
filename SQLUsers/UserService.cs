using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class UserService
    {
        public static int getNumberOfUsers()
        {
            MySqlConnection connection = DatabaseService.getConnection();
            MySqlCommand query = new MySqlCommand("SELECT COUNT(1) AS user_count FROM users;", connection);
            MySqlDataReader reader = query.ExecuteReader();
            reader.Read();
            int output = reader.GetInt32("user_count");
            reader.Close();
            return output;
        }

        public static void registerNewUser(string username, string password)
        {
            if (getUserByUsername(username) == null)
            {
                MySqlConnection connection = DatabaseService.getConnection();
                MySqlCommand query = new MySqlCommand("INSERT INTO users (username, password) VALUES ('" + username + "', '" + password + "')", connection);
                query.ExecuteNonQuery();
            }
            else
            {
                throw new UsernameAlreadyTakenException(username);
            }
        }

        public static User getUserByUsername(string username)
        {
            MySqlConnection connection = DatabaseService.getConnection();
            MySqlCommand query = new MySqlCommand("SELECT * FROM users WHERE username = '" + username + "';", connection);
            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                User output = new User(reader.GetInt32("id"), reader.GetString("username"), reader.GetString("password"));
                reader.Close();
                return output;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
    }
}
