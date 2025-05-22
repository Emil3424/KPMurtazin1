using System.Windows;
using System.Windows.Controls;

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

        public void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
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

                case "Создание заказа":
                    MainFrame.Content = new Pages.MenuZakaz();
                    break;

                case "Тут будет отчет":
                    MainFrame.Content = new Pages.ViewReport();
                    break;

                case "Сотрудники":
                    MainFrame.Content = new Pages.AddSotrudniki(null);
                    break;
            }
        }
    }
}