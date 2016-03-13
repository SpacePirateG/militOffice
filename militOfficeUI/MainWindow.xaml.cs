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
        //private MilitTerminal militTerminal;
        private RecruitTerminal recruitTerminal;
        private UserTerminal userTerminal;
        private OrderTerminal orderTerminal;
        private Commands availableCommands;

        public MainWindow(MilitTerminal militTerminal)
        {
            InitializeComponent();
            //this.militTerminal = militTerminal;
            this.availableCommands = militTerminal.AvailableCommands;
            this.recruitTerminal = militTerminal.RecruitTerminal;
            this.orderTerminal = militTerminal.OrderTerminal;
            this.userTerminal = militTerminal.UserTerminal;

            CreateUserScreen();
            CreateRecruitsScreen();
            CreateOrdersScreen();



        }

        private void CreateRecruitsScreen()
        {
            Recruits.ItemsSource = recruitTerminal.GetAll();
        }

        private void CreateOrdersScreen()
        {
            Orders.ItemsSource = orderTerminal.GetAll();
        }

        private void CreateUserScreen()
        {
            Users.ItemsSource = userTerminal.GetAll();
        }
    }
}
