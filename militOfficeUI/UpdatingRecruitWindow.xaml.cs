﻿using System;
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
    /// Логика взаимодействия для UpdateRecruitWindow.xaml
    /// </summary>
    public partial class UpdatingRecruitWindow : Window
    {
        private Recruit recruit;
        private MainWindow mainWindow;
        public UpdatingRecruitWindow(MainWindow mainWindow, Recruit recruit)
        {
            InitializeComponent();
            this.recruit = recruit;
            this.mainWindow = mainWindow;
            ConfigureFields();
        }

        public void ConfigureFields()
        {
            Name.Text = recruit.name;
            Surname.Text = recruit.surname;
            Patronymic.Text = recruit.patronymic;
            Birthday.SelectedDate = recruit.birthday;
            Pasport.Text = recruit.pasport;
            PhoneNumber.Text = recruit.phoneNumber;
            Address.Text = recruit.address;
            Category.Text = recruit.category;
            Conviction.Text = recruit.conviction;
            Postponement.SelectedDate = recruit.postponement;

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Recruit updatedRecruit = new Recruit(
                  recruit.id,
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

            mainWindow.recruitTerminal.Update(updatedRecruit);
            mainWindow.CreateRecruitsTable();
        }
    }
}
