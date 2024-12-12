using KPMurtazin.DataBase;
using KPMurtazin.Message;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Changepass.xaml
    /// </summary>
    public partial class Changepass : Page
    {
        public Changepass()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.Generic.List<Users> result = new DB_Operation().ExecuteQuery<Users>("SELECT * FROM Users;");

            Users users = result.Where(w =>
                w.Login == tbLogin.Text &&
                w.Password == tbPassword.Password)
                .ToList().LastOrDefault();

            if (users == null)
            {
                //MessageBox.Show("Введите логин.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbLogin.ToolTip = "Введите правильные данные.";
                tbLogin.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (tbPassword1.Password == tbPassword2.Password)
            {
                {
                    string sql = "UPDATE Users set Password = @Password where Login = @Username;";
                    SQLiteParameter[] parameters = {
                            new SQLiteParameter("@Username",tbLogin.Text),
                            new SQLiteParameter("@Password",tbPassword1.Password)
                };
                    new DB_Operation().Query(sql, parameters);
                    var messageWindow = new MessageWindow("Вы успешно прошли поменяли пароль." + Environment.NewLine + "Поздравляем!");
                    messageWindow.ShowDialog();
                }
            }
        }
    }
}