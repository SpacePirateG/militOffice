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
using System.Security.Authentication;

namespace militOfficeUI
{
	/// <summary>
	/// Логика взаимодействия для Authentication.xaml
	/// </summary>
	public partial class Authentication : Window
	{
        public MainWindow mainWindow;
		public Authentication()
		{
			InitializeComponent();
            validAuthentificationTest();
		}

        public void validAuthentificationTest()
        {
            enterValidUser();
            Button_Click(this, null);
        }

        public void invalidAuthentificationTest()
        {
            enterInvalidUser();
            Button_Click(this, null);
        }

        public void enterValidUser(){
            LoginField.Text = "admin";
            PasswordField.Password = "admin";
        }

        public void enterInvalidUser()
        {
            LoginField.Text = "user";
            PasswordField.Password = "ewrgorjtiowe";
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MilitTerminal militTerminal = ((App)Application.Current).militTerminal;
			try
			{
				militTerminal.Authentication(LoginField.Text, PasswordField.Password);
				mainWindow = new MainWindow(militTerminal);
                mainWindow.Show();
				this.Close();
			}
			catch (AuthenticationException)
			{
				MessageBox.Show("Ошибка: Логин или пароль введены неверно");
			}

				
		}
	}
}
