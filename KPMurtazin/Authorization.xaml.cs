using System.Windows;

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

        private void changepass_Click(object sender, RoutedEventArgs e)
        {
            FrameForLogin.Content = new Pages.Changepass();
        }
    }
}