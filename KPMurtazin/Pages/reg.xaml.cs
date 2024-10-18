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

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "")
            {
                //MessageBox.Show("Введите логин.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbLogin.ToolTip = "Введите логин.";
                tbLogin.BorderBrush = Brushes.Red;
            }
            else if (tbPassword.Password == "")
            {
                //MessageBox.Show("Введите пароль.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword.ToolTip = "Введите пароль.";
                tbPassword.BorderBrush = Brushes.Red;
            }
            else if (tbPassword2.Password == "")
            {
                //MessageBox.Show("Введите пароль для проверки.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword2.ToolTip = "Введите пароль для проверки.";
                tbPassword2.BorderBrush = Brushes.Red;
            }
            else if (tbPassword.Password != tbPassword2.Password)
            {
                MessageBox.Show("Пароль должны быть одинаковыми.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                tbPassword.BorderBrush = Brushes.Red;
                tbPassword2.BorderBrush = Brushes.Red;
            }
            else
            {
                MessageBox.Show("Вы успешно прошли регистрацию.", "Поздравляем!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.auto());
            }
        }
    }
}
