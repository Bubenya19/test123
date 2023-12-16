using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using NpgsqlTypes;


namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        private NpgsqlConnection connection;
        public ObservableCollection<Users> User { get; set; }
        public Users NewUser { get; set; }
        public Auth()
        {
            InitializeComponent();

             User = new ObservableCollection<Users>();
             Connection.Connectt("10.14.206.27", "5432", "PDA", "k24a_463", "1234");
            
        }

       

        private void BtAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(TBoxUserName.Text) && !String.IsNullOrEmpty(PBoxPassword.Password))
                {
                    string ll = TBoxUserName.Text;
                    string ll2 = PBoxPassword.Password;


                    string sql = "SELECT idUser, userName, userPassword FROM users where userName = @a && userPassword = @b";
                   
                    var cmd = Connection.GetCommand(sql);
                    cmd.Parameters.AddWithValue("@a", NpgsqlDbType.Varchar, ll);
                    cmd.Parameters.AddWithValue("@b", NpgsqlDbType.Varchar, ll2);
                    NpgsqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            User.Add(new Users(result.GetInt32(0), result.GetString(1), result.GetString(2)));
                        }
                    }

                    if(User != null)

                    result.Close();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены", "Поля не заполнены", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("User not found", "System error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
