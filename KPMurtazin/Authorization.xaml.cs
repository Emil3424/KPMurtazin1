using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace KPMurtazin
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
            FrameForLogin.Content = new Pages.auto();
        }

        private void autoUser_Click(object sender, RoutedEventArgs e)
        {
            FrameForLogin.Content = new Pages.auto();
        }

        private void newUser_Click(object sender, RoutedEventArgs e)
        {
            FrameForLogin.Content = new Pages.reg();
        }
    }
}
