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
    /// Логика взаимодействия для AddingOrderWindow.xaml
    /// </summary>
    public partial class AddingOrderWindow : Window
    {
        MainWindow mainWindow;
        public AddingOrderWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order(0, 
                Int32.Parse(recruitId.Text), 
                date.SelectedDate.Value,
                cause.Text);

            mainWindow.orderTerminal.Add(order);
            mainWindow.CreateOrdersTable();
        }
    }
}
