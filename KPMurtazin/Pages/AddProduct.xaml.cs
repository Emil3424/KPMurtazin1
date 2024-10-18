using KPMurtazin.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        private int idCategory = 0;
        private readonly Purchase_items current = null;
        public AddProduct( Purchase_items purchase)
        {
            InitializeComponent();

            System.Collections.Generic.List<MenuC> Menu = new DB_Operation().ExecuteQuery<MenuC>("SELECT Name FROM MenuC;");
            //CategoryProd.Items.Clear();
            //CategoryProd.ItemsSource = Menu.Select(w => w.Name).ToList();

            System.Collections.Generic.List<Purchase_items> res = new DB_Operation().ExecuteQuery<Purchase_items>(
                @"SELECT p.*, 
                c.ID_Category as Menu_ID_Category, 
                c.Name as Menu_Name
                FROM Purchase_items p
                INNER JOIN MenuC c ON p.ID_Category = c.ID_Category;");

            if (purchase != null)
            {
                current = res
                    .Where(w => w.ID_item == purchase.ID_item)
                    .ToList().LastOrDefault();
            }

            DataContext = current;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void PriceProd_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            //Regex regex = new (@"^[0-9]*(?:[.,][0-9]*)?$");
            //e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
