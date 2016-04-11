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
using NLog;

namespace militOfficeUI
{
    /// <summary>
    /// Логика взаимодействия для AddingRecruitWindow.xaml
    /// </summary>
    public partial class AddingRecruitWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        MainWindow mainWindow;
        public AddingRecruitWindow(MainWindow mainWindow)
        {
            logger.Info("Открытие окна добавления");
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            Recruit recruit = new Recruit(
                  0,
                  Name.Text,
                  Surname.Text,
                  Patronymic.Text,
                  Birthday.SelectedDate.Value.Date,
                  Pasport.Text,
                  PhoneNumber.Text,
                  Address.Text,
                  Category.Text,
                  Conviction.Text,
                  Postponement.SelectedDate.Value.Date
                );
            logger.Info("Запрос на добавление призывника");
            logger.Info("Добавление призывника");
            mainWindow.recruitTerminal.Add(recruit);
            mainWindow.CreateRecruitsTable();
        }
    }
}
