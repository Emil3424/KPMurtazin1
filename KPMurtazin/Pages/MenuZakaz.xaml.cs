using KPMurtazin.DataBase;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KPMurtazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuZakaz.xaml
    /// </summary>
    public partial class MenuZakaz : Page
    {
        public ObservableCollection<Purchase_items> Purchase_itemsC;
        private decimal Pricecart = 0;

        public static class ShoppingCart
        {
            public static List<Purchase_items> SelectedProducts { get; set; } = new List<Purchase_items>();
        }

        // Количество товаров в корзине
        private int cartCount = 0;

        public MenuZakaz()
        {
            InitializeComponent();

            InitializeData();
            this.DataContext = this;
        }

        private void InitializeData()
        {
            Purchase_itemsC = new ObservableCollection<Purchase_items>();

            var snack = new DB_Operation().ExecuteQuery<Purchase_items>("SELECT * FROM Purchase_items");
            foreach (var product in snack)
            {
                Menushkaa.Items.Add(product);
            }
        }

        private List<CartItem> _items = new List<CartItem>();

        public void ExistProduct(Purchase_items product)
        {
            var existingItem = _items.FirstOrDefault(item => item.Product.ID_item == product.ID_item);

            if (existingItem != null)
            {
                // Если товар уже есть, увеличиваем его количество
                existingItem.Quantity++;
            }
            else
            {
                // Если товара нет в корзине, добавляем новый элемент
                _items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Purchase_items product)
            {
                // Увеличиваем количество товаров в корзине
                cartCount++;

                // Добавляем товар в корзину
                ShoppingCart.SelectedProducts.Add(product);

                // Обновляем текст в панели корзины
                CartCountText.Text = $"Товары в корзине: {cartCount}";
                Pricecart += (decimal)product.Cost;
                Price_Cart.Text = $"Итого: {Pricecart:0.00} ₽";

                // Показываем панель корзины, если она скрыта
                if (cartCount == 1)
                {
                    CartPanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void Payment_click(object sender, RoutedEventArgs e)
        {
            Vars.Pricecart1 = Pricecart;
            this.NavigationService.Navigate(new PayMenu());
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Purchase_items product)
            {
                // Перейти на страницу с деталями продукта
                //this.NavigationService.Navigate(new ProductDetail(product));
            }
        }
    }
}