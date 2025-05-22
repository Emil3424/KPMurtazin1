using KPMurtazin.DataBase;
using KPMurtazin.Message;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Navigation;
using Page = System.Windows.Controls.Page;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Page
    {
        public reg()
        {
            InitializeComponent();
        }

        private bool IsValidMailAddress2(string mailAddress)
        {
            return Regex.IsMatch(mailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private void Cleartb()
        {
            tbPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
            tbPassword2.BorderBrush = System.Windows.Media.Brushes.Gray;
            tbEmail.BorderBrush = System.Windows.Media.Brushes.Gray;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "")
            {
                Cleartb();
                tbLogin.ToolTip = "Введите логин.";
                tbLogin.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (tbPassword.Password == "")
            {
                Cleartb();
                tbPassword.ToolTip = "Введите пароль.";
                tbPassword.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (tbPassword2.Password == "")
            {
                Cleartb();
                tbPassword2.ToolTip = "Введите пароль для проверки.";
                tbPassword2.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (tbPassword.Password != tbPassword2.Password)
            {
                var messageWindow = new FailMessageWindow("Пароль должны быть одинаковыми." + Environment.NewLine + "Ошибка!");
                messageWindow.ShowDialog();
                Cleartb();
                tbPassword.BorderBrush = System.Windows.Media.Brushes.Red;
                tbPassword2.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else if (IsValidMailAddress2(tbEmail.Text) == false)
            {
                Cleartb();
                var messageWindow = new FailMessageWindow("Email должен быть корректным." + Environment.NewLine + "Ошибка!");
                messageWindow.ShowDialog();
                tbEmail.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                System.Collections.Generic.List<Users> result = new DB_Operation().ExecuteQuery<Users>("SELECT * FROM Users;");

                Users users = result.Where(w =>
                    w.Login == tbLogin.Text &&
                    w.Password == tbPassword.Password)
                    .ToList().LastOrDefault();
                if (users == null)
                {
                    Cleartb();
                    string sql = "INSERT into Users(Login,Password,Email) values(@Login,@Password,@Email)";
                    SQLiteParameter[] parameters = {
                            new SQLiteParameter("@Login",tbLogin.Text),
                            new SQLiteParameter("@Password",tbPassword.Password),
                            new SQLiteParameter("@Email",tbEmail.Text)
                };
                    new DB_Operation().Query(sql, parameters);
                    var messageWindow = new MessageWindow("Вы успешно прошли регистрацию." + Environment.NewLine + "Поздравляем!");
                    messageWindow.ShowDialog();
                    NavigationService.Navigate(new Pages.auto());
                }else
                {
                    Cleartb();
                    var messageWindow = new FailMessageWindow("Login уже занят другим пользователем." + Environment.NewLine + "Ошибка!");
                    messageWindow.ShowDialog();
                    tbLogin.BorderBrush = System.Windows.Media.Brushes.Red;
                }
            }
        }
    }
}