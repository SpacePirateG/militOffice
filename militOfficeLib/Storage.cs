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
            return null;
        }

        public IEnumerable<Recruit> getRecruitsByCategory(String category)
        {
            return null;
        }

        public IEnumerable<Recruit> getRecruitsByConviction(String conviction)
        {
            return null;
        }

        public IEnumerable<Recruit> getRecruitsByPostponement(String postponement)
        {
            return null;
        }

        public Recruit getRecruitById(Int32 id)
        {
            return null;
        }

        public void addRecruit(Recruit recruit)
        {
        }

        //========Orders=======

        public IEnumerable<Order> getAllOrders()
        {
            return null;
        }

        public IEnumerable<Order> getAllOrdersByDate(DateTime date)
        {
            return null;
        }

        public Order getOrderByRecruitId(Int32 id)
        {
            return null;
        }

        public void addOrder(Order order)
        {
        }

        //=========Users==========
        public User getUserBylogin(string login)
        {
            return null;
        }

		public IEnumerable<User> getAllUsers()
		{
			return null;
		}

        public void addUser(User user)
        {
        }

        

    }
}
