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

        private void query(string sql)
        {
            MySqlCommand sqlCommand = new MySqlCommand(sql, connection);           
            DataTable dataTable = new DataTable();

            connection.Open();
            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlCommand))
            {
                dataAdapter.Fill(dataTable);
            }

            connection.Close();
        }


        //========Recruits=======
        public IEnumerable<Recruit> getAllRecruits()
        {
        }

        public IEnumerable<Recruit> getRecruitsByCategory(String category)
        {
        }

        public IEnumerable<Recruit> getRecruitsByConviction(String conviction)
        {
        }

        public IEnumerable<Recruit> getRecruitsByPostponement(String postponement)
        {
        }

        public Recruit getRecruitById(Int32 id)
        {
        }

        public void addRecruit(Recruit recruit)
        {
        }

        //========Orders=======

        public IEnumerable<Order> getAllOrders()
        {
        }

        public IEnumerable<Order> getAllOrdersByDate(DateTime date)
        {
        }

        public Order getOrderByRecruitId(Int32 id)
        {
        }

        public void addOrder(Order order)
        {
        }

        //=========Users==========
        public User getUserBylogin(string login)
        {
        }

        public void addUser(User user)
        {
        }

        

    }
}
