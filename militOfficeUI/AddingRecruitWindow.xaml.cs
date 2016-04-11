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
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.Button_Click(this, null); //for tests
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logger.Info("Добавление призывника");

            //for tests
            /*
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
            */
      //      mainWindow.recruitTerminal.Add(recruit);
            mainWindow.recruitTerminal.Add(GetTestRecruit()); //for tests
            mainWindow.CreateRecruitsTable();
        }

        //for tests
        public static Recruit GetTestRecruit()
        {
            return new Recruit(
                  666,
                  "test",
                  "test",
                  "test",
                  new DateTime(1),
                  "test",
                  "test",
                  "test",
                  "test",
                  "test",
                  new DateTime(1)
                );
        }
    }
}
