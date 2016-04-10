using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using militOfficeLib;

namespace militOfficeUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RecruitTerminal recruitTerminal;
        public UserTerminal userTerminal;
        public OrderTerminal orderTerminal;

        private Permissions availablePermissions;

        public MainWindow(MilitTerminal militTerminal)
        {
            InitializeComponent();
            this.availablePermissions = militTerminal.AvailablePermissions;

            if (availablePermissions.HasFlag(Permissions.usersRead))
            {
                this.userTerminal = militTerminal.UserTerminal;
                CreateUserTable();
                if (!availablePermissions.HasFlag(Permissions.usersWrite))
                {
                    UpdateUserButton.Visibility = System.Windows.Visibility.Collapsed;
                    AddUserButton.Visibility = System.Windows.Visibility.Collapsed;
                    DeleteUserButton.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
                tabControl.Items.Remove(UsersItem);
            if (availablePermissions.HasFlag(Permissions.recruitsRead))
            {
                this.recruitTerminal = militTerminal.RecruitTerminal;
                CreateRecruitsTable();
                if (!availablePermissions.HasFlag(Permissions.recruitsWrite))
                {
                    UpdateRecruitButton.Visibility = System.Windows.Visibility.Collapsed;
                    AddRecruitButton.Visibility = System.Windows.Visibility.Collapsed;
                    DeleteRecruitButton.Visibility = System.Windows.Visibility.Collapsed;
                }
            }
            else
                tabControl.Items.Remove(RecruitsItem);
            if (availablePermissions.HasFlag(Permissions.ordersRead))
            {
                this.orderTerminal = militTerminal.OrderTerminal;
                CreateOrdersTable();
                if (!availablePermissions.HasFlag(Permissions.ordersWrite))
                {
                    UpdateOrderButton.Visibility = System.Windows.Visibility.Collapsed;
                    AddOrderButton.Visibility = System.Windows.Visibility.Collapsed;
                    DeleteOrderButton.Visibility = System.Windows.Visibility.Collapsed;
                }

            }
            else
                tabControl.Items.Remove(OrdersItem);

            //if (availableCommands.)
            
        }

        public void CreateRecruitsTable()
        {
            IEnumerable<Recruit> recruits = recruitTerminal.GetAll();
            foreach(var recruit in recruits){
                RecruitsTable.Items.Add(recruit);
            }
        }

        public void CreateOrdersTable()
        {
            OrdersTable.ItemsSource = orderTerminal.GetAll();
        }

        public void CreateUserTable()
        {
            UsersTable.ItemsSource = userTerminal.GetAll();
        }

        private void AddRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            new AddingRecruitWindow(this).Show();
        }

        private void UpdateRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            Recruit recruit = RecruitsTable.SelectedItem as Recruit;
            if (recruit != null)
            {
                new UpdatingRecruitWindow(this, recruit).Show();
            }
        }

        private void DeleteRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            Recruit recruit = RecruitsTable.SelectedItem as Recruit;
            if (recruit != null)
            {
                recruitTerminal.DeleteById(recruit.id);
                CreateRecruitsTable();
            }
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //new AddingWindow().Show();
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //new UpdatingWindow().Show();
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            //new AddingWindow().Show();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            //new UpdatingWindow().Show();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
