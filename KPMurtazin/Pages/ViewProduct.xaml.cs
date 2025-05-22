using KPMurtazin.DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewProduct.xaml
    /// </summary>
    public partial class ViewProduct : Page
    {
        //var result = new List<T>();
        private IEnumerable<Purchase_items> result;

        public ViewProduct()
        {
            InitializeComponent();
            View();
            Load();

            List<MenuC> Menu = new DB_Operation().ExecuteQuery<MenuC>("SELECT Name FROM MenuC;");
            cbFilter.Items.Clear();

            foreach (MenuC category in Menu)
            {
                _ = cbFilter.Items.Add(category.Name);
            }
        }

        private void View()
        {
            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                @"SELECT *
                FROM Purchase_items;");
        }

        private void Load()
        {
            lbProduct.Items.Clear();
            foreach (Purchase_items prod in result)
            {
                lbProduct.Items.Add(prod);
            }
        }

        public void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbSearch.Text != "")
            {
                result = result.Where(w => w.Nazvanie.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            Load();
        }

        private void cbFilter_DropDownClosed(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem != null)
            {
                if (cbFilter.Text == "Без фильтров")
                {
                    result = new DB_Operation().ExecuteQuery<Purchase_items>(
                    @"SELECT *
                    FROM MenuC
                    INNER JOIN Purchase_items ON MenuC.ID_Prod = Purchase_items.ID_Category;");
                    Load();
                }
                else
                {
                    switch (cbFilter.Text)
                    {
                        case "Кофе":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 2;");
                            break;

                        case "Горячие напитки":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 3;");
                            break;

                        case "Выпечка":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 4;");
                            break;

                        case "Чай":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 5;");
                            break;

                        case "Пирожные":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 6;");
                            break;

                        case "Торты":
                            result = new DB_Operation().ExecuteQuery<Purchase_items>(
                              @"SELECT *
                                FROM Purchase_items
                                INNER JOIN MenuC ON MenuC.ID_Prod = Purchase_items.ID_Category 
                                Where Purchase_items.ID_Category = 7;");
                            break;
                    }
                    //result = result.Where(w => w.Nazvanie.IndexOf(cbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                    lbProduct.Items.Clear();
                    Load();
                }
            }
        }

        private void btn_DeleteClick(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Purchase_items delete)
            {
                if (MessageBox.Show($"Вы точно хотите удалить выбранный элемент?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        string sql = "DELETE FROM Purchase_items WHERE ID_item = @Id";
                        SQLiteParameter[] parameters = {
                            new SQLiteParameter("@Id", delete.ID_item)
                        };

                        new DB_Operation().Query(sql, parameters);

                        _ = MessageBox.Show("Записи удалены.", "Внимение!", MessageBoxButton.OK, MessageBoxImage.Information);
                        View();
                        Load();
                    }
                    catch
                    {
                        _ = MessageBox.Show("Записи не удалены.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btn_UpdateClick(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(
                new Pages.AddProduct(
                (sender as Button).DataContext as Purchase_items));
        }

        private void btn_ReportClick(object sender, RoutedEventArgs e)
        {
            _ = NavigationService.Navigate(new ViewReport());
        }

        private void btn_AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddProduct(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            View();
            Load();
        }
    }
}