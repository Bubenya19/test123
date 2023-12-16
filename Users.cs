using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace test
{
    public class Users : INotifyPropertyChanged
    {

        private int idUsers;
        private string userName;
        private string userPassword;


        public Users(int idUsers, string userName, string userPassword)
        {
            IdUsers = idUsers;
            UserName = userName;

            UserPassword = userPassword;

        }

        public int IdUsers
        {
            get => idUsers;
            set
            {
                idUsers = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IdUsers"));
            }

        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }

        }
        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserPassword"));
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }


    }
}
