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
    /// Логика взаимодействия для UpdateOrdersWindow.xaml
    /// </summary>
    public partial class UpdateOrdersWindow : Window
    {
        MainWindow mainWindow;
        public UpdateOrdersWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            Order order = new Order(Int32.Parse(id.Text),
                Int32.Parse(recruitId.Text),
                date.SelectedDate.Value,
                cause.Text);

            mainWindow.orderTerminal.Update(order);
            mainWindow.CreateOrdersTable();
        }
    }
}
