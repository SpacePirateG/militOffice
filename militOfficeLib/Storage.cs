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
        private MySqlConnection connection;
        public Storage(string serverName, string userName, string dbName, string port, string password)
        {
            string connectSettings = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";

            connection = new MySqlConnection(connectSettings);
        }

        public virtual DataTable Query(string sql)
        {           
            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);
            DataTable dataTable = new DataTable();

            connection.Open();
            MySqlDataAdapter dataAdapter;
            using (dataAdapter = new MySqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataTable);
            }

            connection.Close();
            return dataTable;             
        }
    }
}
