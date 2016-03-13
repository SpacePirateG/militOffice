﻿using System;
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

        private DataTable Query(string sql)
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


        //========Recruits=======
        public IEnumerable<Recruit> GetAllRecruits()
        {
            return null;
        }

        public IEnumerable<Recruit> GetRecruitsByCategory(String category)
        {
            return null;
        }

        //выборка по судимости
        public IEnumerable<Recruit> GetRecruitsByConviction(String conviction)
        {
            return null;
        }

        //выборка по отсрочке
        public IEnumerable<Recruit> GetRecruitsByPostponement(String postponement)
        {
            return null;
        }

        public Recruit GetRecruitById(Int32 id)
        {
            return null;
        }

        public void AddRecruit(Recruit recruit)
        {

        }

        public void UpdateRecruit(Recruit oldRecruit, Recruit newRecruit)
        {

        }

        public void DeleteRecruit(Recruit recruit)
        {

        }

        //========Orders=======

        public IEnumerable<Order> GetAllOrders()
        {
            return null;
        }

        public IEnumerable<Order> GetAllOrdersByDate(DateTime date)
        {
            return null;
        }

        public Order GetOrderByRecruitId(Int32 id)
        {
            return null;
        }

        public void AddOrder(Order order)
        {

        }

        public void UpdateOrder(Order oldOrder, Order newOrder)
        {

        }

        public void DeleteOrder(Order order)
        {

        }

        //=========Users==========

        public User GetUserBylogin(string login)
        {
            return null;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return null;
        }

        public void AddUser(User user)
        {

        }

        public void UpdateUser(User oldUser, User newUser)
        {
            
        }

        public void DeleteUser(User user)
        {

        }
    }
}
