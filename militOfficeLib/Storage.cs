using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace militOfficeLib
{
    public class Storage
    {
        private string connectSettings;
        public Storage(string serverName, string userName, string dbName, string port, string password)
        {
            connectSettings = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
        }

        private void query(string sql)
        {
            MySqlConnection connection = new MySqlConnection(connectSettings);
            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);           
            DataTable dataTable = new DataTable();

            connection.Open();
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataTable);
            }

            connection.Close();
        }
    }
}
