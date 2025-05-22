using KPMurtazin.DataBase;
using System.Windows;
using System.Windows.Controls;
using static KPMurtazin.Pages.MenuZakaz;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для PayMenu.xaml
    /// </summary>
    public partial class PayMenu : Page
    {
        public PayMenu()
        {
            InitializeComponent();
            // Загрузка выбранных товаров в ItemsControl
            ProductsList.ItemsSource = ShoppingCart.SelectedProducts;
            CenaProduct.Text += $"{Vars.Pricecart1:0.00} ₽";
        }

        //private void Oplata(object sender, RoutedEventArgs e)
        //{
        //    //string sql = "INSERT INTO Check(ID_Loc,ID_Pr,Photo,Cost,ID_Category,Weight,Calories) " +
        //    //                "values(@Nazvanie,@Description,@Photo,@Cost,@ID_Category,@Weight,@Calories)";
        //    //SQLiteParameter[] parameters = {
        //    //                new SQLiteParameter("@Nazvanie",NameProd.Text),
        //    //                new SQLiteParameter("@Description",Description.Text),
        //    //                new SQLiteParameter("@Photo",ImageProd.Text),
        //    //                new SQLiteParameter("@Cost",PriceProd.Text),
        //    //                new SQLiteParameter("@ID_Category",idCategory),
        //    //                new SQLiteParameter("@Weight", Weight.Text),
        //    //                new SQLiteParameter("@Calories",Calory.Text)
        //    //            };

        //    //new DB_Operation().Query(sql, parameters);

        //    //var messageWindow = new MessageWindow("Данные успешно добавлены." + Environment.NewLine + "Сохранено!");
        //    //messageWindow.ShowDialog();
        //    //messageWindow.Close();
        //}
    }
}