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
using System.Windows.Shapes;
using militOfficeLib;

namespace militOfficeUI
{
    /// <summary>
    /// Логика взаимодействия для AddingRecruitWindow.xaml
    /// </summary>
    public partial class AddingRecruitWindow : Window
    {
        MainWindow mainWindow;
        public AddingRecruitWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Recruit recruit = new Recruit(
                  0,
                  Name.Text,
                  Surname.Text,
                  Patronymic.Text,
                  Birthday.SelectedDate.Value,
                  Pasport.Text,
                  PhoneNumber.Text,
                  Address.Text,
                  Category.Text,
                  Conviction.Text,
                  Postponement.SelectedDate.Value
                );

            mainWindow.recruitTerminal.Add(recruit);
            mainWindow.CreateRecruitsTable();
        }
    }
}
