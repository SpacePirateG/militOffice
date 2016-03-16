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
        private RecruitTerminal recruitTerminal;
        private UserTerminal userTerminal;
        private OrderTerminal orderTerminal;
        private Commands availableCommands;

        public MainWindow(MilitTerminal militTerminal)
        {
            InitializeComponent();
            this.availableCommands = militTerminal.AvailableCommands;
            
            if (availableCommands.HasFlag(Commands.userRead))
            {
                this.userTerminal = militTerminal.UserTerminal;
                CreateUserTable();
            }
            if (availableCommands.HasFlag(Commands.userRead))
            {
                this.recruitTerminal = militTerminal.RecruitTerminal;
                CreateRecruitsTable();

            }
            if (availableCommands.HasFlag(Commands.userRead))
            {
                this.orderTerminal = militTerminal.OrderTerminal;
                CreateOrdersTable();
            }
            
        }

        private void CreateRecruitsTable()
        {
            Recruits.ItemsSource = recruitTerminal.GetAll();
        }

        private void CreateOrdersTable()
        {
            Orders.ItemsSource = orderTerminal.GetAll();
        }

        private void CreateUserTable()
        {
            Users.ItemsSource = userTerminal.GetAll();
        }

        private void AddRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            new AddingWindow().Show();
        }

        private void UpdateRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdatingWindow().Show();
        }

        private void DeleteRecruitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new AddingWindow().Show();
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdatingWindow().Show();
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            new AddingWindow().Show();
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdatingWindow().Show();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
