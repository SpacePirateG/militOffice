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
using NLog;

namespace militOfficeUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public RecruitTerminal recruitTerminal;
        public UserTerminal userTerminal;
        public OrderTerminal orderTerminal;

        private Permissions availablePermissions;

        public AddingRecruitWindow addingWindow;
        public UpdatingRecruitWindow updatingWindow;

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

                logger.Info("Получение всех призывников");
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
            RunTests();
        }

        public void CreateRecruitsTable()
        {
            RecruitsTable.Items.Clear();
            logger.Info("Запрос всех призывников");
            logger.Info("Возвращение всех призывников");
            IEnumerable<Recruit> recruits = recruitTerminal.GetAll();
            logger.Info("Обновление таблицы призывников");
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
            addingWindow = new AddingRecruitWindow(this);
            addingWindow.Show();
        }

        private void UpdateRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            Recruit recruit = RecruitsTable.SelectedItem as Recruit;
            if (recruit != null)
            {
                updatingWindow = new UpdatingRecruitWindow(this, recruit);
                updatingWindow.Show();
            }
        }

        private void DeleteRecruitButton_Click(object sender, RoutedEventArgs e)
        {
            Recruit recruit = RecruitsTable.SelectedItem as Recruit;
            if (recruit != null)
            {
                logger.Info("Запрос на удаление призывника");
                logger.Info("Удаление призывника");
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

        private void RunTests()
        {
            TestAddingRecruit();
            TestUpdatingRecruit();
            TestDeleteRecruit();

            addingWindow = null;
            updatingWindow = null;
            RecruitsTable.SelectedIndex = -1;

            TestInvalidAddingRecruit();
            TestInvalidUpdatingRecruitFirst();
            TestInvalidUpdatingRecruitSecond();

            RecruitsTable.SelectedIndex = -1;

            TestInvalidDeleteRecruit();
        }

        private void TestAddingRecruit()
        {
            logger.Info("---ТЕСТ: ПРАВИЛЬНОЕ ДОБАВЛЕНИЕ ПРИЗЫВНИКА--");
            logger.Info("Нажатие кнопки Добавить");
            AddRecruitButton_Click(this, null);

            logger.Info("Ввод данных о призывнике");
            var recruit = ConfigureAddingRecruit();

            logger.Info("Нажатие кнопки Добавить");
            addingWindow.Button_Click(this, null);

            var resultRecruit = (Recruit)RecruitsTable.Items[RecruitsTable.Items.Count - 1];

            logger.Info("Получение информации");
            if (resultRecruit.Equals(recruit))
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Добавленный призывник находится в таблице призывников");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник не был добавлен");
        }

        private void TestInvalidAddingRecruit()
        {
            logger.Info("---ТЕСТ: НЕ ПРАВИЛЬНОЕ ДОБАВЛЕНИЕ ПРИЗЫВНИКА  _Закрытие--");
            logger.Info("Нажатие кнопки Добавить");
            AddRecruitButton_Click(this, null);

            logger.Info("Ввод данных о призывнике");
            var recruit = ConfigureAddingRecruit();

            logger.Info("Нажатие кнопки закрыть форму");
            addingWindow.Close();

            var resultRecruit = (Recruit)RecruitsTable.Items[RecruitsTable.Items.Count - 1];

            logger.Info("Получение информации");
            if (!resultRecruit.Equals(recruit))
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Призывник не добавлен");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник добавлен WHAT????Оо");
        }

        //for tests
        public Recruit ConfigureAddingRecruit()
        {
            Recruit recruit = new Recruit(
                  0,
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
            addingWindow.Name.Text = recruit.name;
            addingWindow.Surname.Text = recruit.surname;
            addingWindow.Patronymic.Text = recruit.patronymic;
            addingWindow.Birthday.SelectedDate = recruit.birthday;
            addingWindow.Pasport.Text = recruit.pasport;
            addingWindow.PhoneNumber.Text = recruit.phoneNumber;
            addingWindow.Address.Text = recruit.address;
            addingWindow.Category.Text = recruit.category;
            addingWindow.Conviction.Text = recruit.conviction;
            addingWindow.Postponement.SelectedDate = recruit.postponement;

            return recruit;
        }

        private void TestUpdatingRecruit()
        {
            logger.Info("---ТЕСТ: ПРАВИЛЬНОЕ ОБНОВЛЕНИЕ ПРИЗЫВНИКА--");
            logger.Info("Выбор призывника");
            RecruitsTable.SelectedIndex = RecruitsTable.Items.Count - 1;
            logger.Info("Нажатие кнопки Изменить");
            UpdateRecruitButton_Click(this, null);

            logger.Info("Изменение данных о призывнике");
            var recruit = ConfigureUpdatingRecruit();

            logger.Info("Нажатие кнопки Обновить");
            updatingWindow.UpdateButton_Click(this, null);

            var resultRecruit = (Recruit)RecruitsTable.Items[RecruitsTable.Items.Count - 1];

            logger.Info("Получение информации");
            if (resultRecruit.Equals(recruit))
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Обновленный призывник находится в таблице призывников");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник не обновился");
        }

        private void TestInvalidUpdatingRecruitFirst()
        {
            logger.Info("---ТЕСТ: НЕ ПРАВИЛЬНОЕ ОБНОВЛЕНИЕ ПРИЗЫВНИКА _Без выбора--");
            
            logger.Info("Нажатие кнопки Изменить");
            UpdateRecruitButton_Click(this, null);

            if (updatingWindow == null)
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Окно изменения не открылось, призывник не обновлен");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Окно изменения открылось");

        }

        private void TestInvalidUpdatingRecruitSecond()
        {
            logger.Info("---ТЕСТ: НЕ ПРАВИЛЬНОЕ ОБНОВЛЕНИЕ ПРИЗЫВНИКА _Закрытие--");
            logger.Info("Выбор призывника");
            RecruitsTable.SelectedIndex = RecruitsTable.Items.Count - 1;
            logger.Info("Нажатие кнопки Изменить");
            UpdateRecruitButton_Click(this, null);

            logger.Info("Изменение данных о призывнике");
            var recruit = ConfigureUpdatingRecruit();

            logger.Info("Нажатие кнопки закрыть форму");
            updatingWindow.Close();

            var resultRecruit = (Recruit)RecruitsTable.Items[RecruitsTable.Items.Count - 1];

            logger.Info("Получение информации");
            if (!resultRecruit.Equals(recruit))
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Призывник не обновлен");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник обновлен NO NO NO");
        }

        //for tests
        public Recruit ConfigureUpdatingRecruit()
        {
            Recruit recruit =  new Recruit(
                  0,
                  "testUpdated",
                  "testUpdated",
                  "testUpdated",
                  new DateTime(1),
                  "testUpdated",
                  "testUpdated",
                  "testUpdated",
                  "testUpdated",
                  "testUpdated",
                  new DateTime(1)
                );

            updatingWindow.Name.Text = recruit.name;
            updatingWindow.Surname.Text = recruit.surname;
            updatingWindow.Patronymic.Text = recruit.patronymic;
            updatingWindow.Birthday.SelectedDate = recruit.birthday;
            updatingWindow.Pasport.Text = recruit.pasport;
            updatingWindow.PhoneNumber.Text = recruit.phoneNumber;
            updatingWindow.Address.Text = recruit.address;
            updatingWindow.Category.Text = recruit.category;
            updatingWindow.Conviction.Text = recruit.conviction;
            updatingWindow.Postponement.SelectedDate = recruit.postponement;

            return recruit;
        }

        private void TestDeleteRecruit()
        {
            logger.Info("---ТЕСТ: ПРАВИЛЬНОЕ УДАЛЕНИЕ ПРИЗЫВНИКА--");
            logger.Info("Выбор призывника");
            var delitingRecruit = (Recruit)RecruitsTable.Items[RecruitsTable.Items.Count - 1];

            RecruitsTable.SelectedIndex = RecruitsTable.Items.Count - 1;

            logger.Info("Нажатие на кнопку Удалить");
            DeleteRecruitButton_Click(this, null);

            logger.Info("Получение информации");
            if (!RecruitsTable.Items.Contains(delitingRecruit))
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Успешное удаление призывника");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник удален");
        }

        private void TestInvalidDeleteRecruit()
        {
            logger.Info("---ТЕСТ: НЕ ПРАВИЛЬНОЕ УДАЛЕНИЕ ПРИЗЫВНИКА _Без выбора--");

            int oldCount = RecruitsTable.Items.Count;

            logger.Info("Нажатие на кнопку Удалить");
            DeleteRecruitButton_Click(this, null);

            if (RecruitsTable.Items.Count == oldCount)
                logger.Info("РЕЗУЛЬТАТ ТЕСТА: УСПЕХ. Призывник не удален");
            else
                logger.Error("РЕЗУЛЬТАТ ТЕСТА: ПРОВАЛ. Призывник удален...");
        }
    }
}
