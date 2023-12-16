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
using test.Pages;
using Npgsql;
using NpgsqlTypes;


namespace test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NpgsqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AuthFrame.NavigationService.Navigate(new Auth());
        }

        private void AuthFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void Connect(string host, string port, string user, string pass, string dbname)
        {
            string cs = string.Format("Host=10.14.206.27;Username=student;Password=1234;Database=denis200");
            NpgsqlConnection nc = new NpgsqlConnection(cs);
            connection = new NpgsqlConnection(cs);
            connection.Open();

        }
    }
}
