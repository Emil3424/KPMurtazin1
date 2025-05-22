using System.Windows;

namespace KPMurtazin.Message
{
    /// <summary>
    /// Логика взаимодействия для FailMessageWindow.xaml
    /// </summary>
    public partial class FailMessageWindow : Window
    {
        public FailMessageWindow(string message)
        {
            InitializeComponent();
            Message.Text = message;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}