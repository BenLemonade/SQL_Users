using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class UserDataService
    {
        public static void storeUserData(int userID, string dataKey, string dataValue)
        {
            MySqlConnection connection = DatabaseService.getConnection();
            if (getDataForUserByKey(userID, dataKey).Equals(default(KeyValuePair<string, string>)))
            {
                MySqlCommand query = new MySqlCommand("INSERT INTO user_data (user_id, data_key, data_value) VALUES ('" + userID + "' , '" + dataKey + "' , '" + dataValue + "');", connection);
                query.ExecuteNonQuery();
            }
            else 
            {
                MySqlCommand query = new MySqlCommand("UPDATE user_data SET data_value = '" + dataValue + "' WHERE user_id = '" + userID + "' AND data_key = '" + dataKey + "' ", connection);
                query.ExecuteNonQuery();
            }
        }
        public static KeyValuePair<string, string> getDataForUserByKey(int userID, string dataKey)
        {
            MySqlConnection connection = DatabaseService.getConnection();
            MySqlCommand query = new MySqlCommand("SELECT data_value FROM user_data WHERE user_id = '" + userID + "' AND data_key = '" + dataKey + "';", connection);
            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                KeyValuePair<string, string> output = new KeyValuePair<string, string>(dataKey, reader.GetString("data_value"));
                reader.Close();
                return output;
            }
            else 
            {
                reader.Close();
                return default;
            }
        }

        public static Dictionary<string, string> getAllDataForUser(int userID)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            MySqlConnection connection = DatabaseService.getConnection();
            MySqlCommand query = new MySqlCommand("SELECT data_key, data_value FROM user_data WHERE user_id = " + userID, connection);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                output.Add(reader.GetString("data_key"), reader.GetString("data_value"));
            }
            reader.Close();
            return output;
        }
    }
}
