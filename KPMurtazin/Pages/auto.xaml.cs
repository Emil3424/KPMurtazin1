using KPMurtazin.DataBase;
using KPMurtazin.Message;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для auto.xaml
    /// </summary>
    public partial class auto : Page
    {
        public auto()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            System.Collections.Generic.List<Users> result = new DB_Operation().ExecuteQuery<Users>("SELECT * FROM Users;");

            Users users = result.Where(w =>
                w.Login == tbLogin.Text &&
                w.Password == tbPassword.Password)
                .ToList().LastOrDefault();

            if (users != null)
            {
                var messageWindow = new MessageWindow("Вы успешно авторизовались.");
                messageWindow.ShowDialog();
                messageWindow.Close();

                MainWindow
                    mainWindow = new MainWindow();
                mainWindow.Show();

                Window
                    window = Window.GetWindow(this);
                window?.Close();
            }
            else
            {
                var messageWindow = new FailMessageWindow("Plese Enter Valid Data.");
                messageWindow.ShowDialog();
            }
        }
    }
}