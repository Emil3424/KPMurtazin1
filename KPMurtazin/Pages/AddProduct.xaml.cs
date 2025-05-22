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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        private int idCategory = 0;
        private readonly Purchase_items current = null;

        public AddProduct(Purchase_items purchase)
        {
            InitializeComponent();

            System.Collections.Generic.List<MenuC> Menu = new DB_Operation().ExecuteQuery<MenuC>("SELECT Name FROM MenuC;");
            CategoryProd.Items.Clear();
            CategoryProd.ItemsSource = Menu.Select(w => w.Name).ToList();

            System.Collections.Generic.List<Purchase_items> res = new DB_Operation().ExecuteQuery<Purchase_items>(
                @"SELECT *
                FROM MenuC
                INNER JOIN Purchase_items ON MenuC.ID_Prod = Purchase_items.ID_Category;");

            if (purchase != null)
            {
                current = res
                    .Where(w => w.ID_item == purchase.ID_item)
                    .ToList().LastOrDefault();
            }

            DataContext = current;
        }

        private void cbCategory_DropDownClosed(object sender, EventArgs e)
        {
            if (CategoryProd.SelectedIndex != -1)
            {
                System.Collections.Generic.List<MenuC> categories = new DB_Operation().ExecuteQuery<MenuC>("SELECT * FROM MenuC;");
                idCategory = categories.Where(w => w.Name == CategoryProd.Text).LastOrDefault().ID_Category;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CategoryProd.SelectedIndex != -1)
                {
                    if (current != null)
                    {
                        string sql = "UPDATE Purchase_items SET Nazvanie = @Nazvanie, Description = @Description, " +
                            "Photo = @Photo, Cost = @Cost, ID_Category = @ID_Category, Weight = @Weight, Calories = @Calories " +
                            "WHERE ID_item = @ID_item";
                        SQLiteParameter[] parameters = {
                            new SQLiteParameter("@ID_item",current.ID_item),
                            new SQLiteParameter("@Nazvanie",NameProd.Text),
                            new SQLiteParameter("@Description",Description.Text),
                            new SQLiteParameter("@Photo",ImageProd.Text),
                            new SQLiteParameter("@Cost",PriceProd.Text),
                            new SQLiteParameter("@ID_Category",2),
                            new SQLiteParameter("@Weight", Weight.Text),
                            new SQLiteParameter("@Calories",Calory.Text)
                        };
                        new DB_Operation().Query(sql, parameters);
                        var messageWindow = new MessageWindow("Данные успешно изменены." + Environment.NewLine + "Сохранено!");
                        messageWindow.ShowDialog();
                        messageWindow.Close();
                    }
                    else if (current == null)
                    {
                        string sql = "INSERT INTO Purchase_items(Nazvanie,Description,Photo,Cost,ID_Category,Weight,Calories) " +
                            "values(@Nazvanie,@Description,@Photo,@Cost,@ID_Category,@Weight,@Calories)";
                        SQLiteParameter[] parameters = {
                            new SQLiteParameter("@Nazvanie",NameProd.Text),
                            new SQLiteParameter("@Description",Description.Text),
                            new SQLiteParameter("@Photo",ImageProd.Text),
                            new SQLiteParameter("@Cost",PriceProd.Text),
                            new SQLiteParameter("@ID_Category",2),
                            new SQLiteParameter("@Weight", Weight.Text),
                            new SQLiteParameter("@Calories",Calory.Text)
                        };

                        new DB_Operation().Query(sql, parameters);

                        var messageWindow = new MessageWindow("Данные успешно добавлены." + Environment.NewLine + "Сохранено!");
                        messageWindow.ShowDialog();
                        messageWindow.Close();
                    };
                }
            }
            catch (Exception ex)
            {
                var messageWindow = new FailMessageWindow("Ошибка: " + ex.Message + Environment.NewLine + "Ошибка!");
                messageWindow.ShowDialog();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (CategoryProd.SelectedIndex != -1)
            {
                CategoryProd.SelectedIndex += -1;
            }
        }
    }
}