using System;
using Npgsql;
using LinqToDB;
using LinqToDB.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataModel;

namespace CourseApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLoginPress_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new StockDB())
            {
                var user =
                    from users in db.Users
                    where users.UserName == textBoxLogin.Text && users.UserPass == passwordBoxPass.Password
                    select users;

                int count = user.ToList().Count;

                if (count > 0)
                {
                    WorkWindow workWindow = new WorkWindow(user.ElementAt(0).RoleKey, user.ElementAt(0).UserId);
                    workWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введены не верно!");
                    passwordBoxPass.Password = "";
                }
            }

        }
    }
}
