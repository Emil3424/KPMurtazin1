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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KPMurtazin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Pages.ViewProduct();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationMenu.Visibility == Visibility.Collapsed)
            {
                NavigationMenu.Visibility = Visibility.Visible;
            }
            else
            {
                NavigationMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            Button button
                = sender as Button;
            switch (button.Content)
            {
                case "Главная":
                    MainFrame.Content = new Pages.ViewProduct();
                    break;

                //case "Еще страница":
                //    MainFrame.Content = new Pages.AddProduct();
                //    break;

                case "Тут будет отчет":
                    MainFrame.Content = new Pages.ViewReport();
                    break;
            }
            NavigationMenu.Visibility = Visibility.Collapsed;
        }
    }
}
