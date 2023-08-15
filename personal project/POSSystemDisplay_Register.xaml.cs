using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static personal_project.POSSystemDisplay_Register;

namespace personal_project
{
    /// <summary>
    /// Interaction logic for POSSystemDisplay_Register.xaml
    /// </summary>
    public partial class POSSystemDisplay_Register : Window
    {
        private ObservableCollection<MenuItemData> menuItemsData = new ObservableCollection<MenuItemData>();
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madgw\source\repos\Console\personal project\personal project\POS.mdf;Integrated Security=True;Connect Timeout=30";
        public POSSystemDisplay_Register()
        {
            InitializeComponent();

            // Create a ScrollViewer
            ScrollViewer scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
            };

            // Create a UniformGrid
            UniformGrid uniformGrid = new UniformGrid
            {
                Columns = 4,
                Margin = new Thickness(10)
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID;";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    string CategoryID = reader["CategoryName"].ToString();
                    Button button = new Button
                    {
                        Height = 125,
                        Width = 125,
                        Margin = new Thickness(10),
                        FontSize = 20
                    };
                    Grid grid = new Grid
                    {
                        Height = 120,
                        Width = 120
                    };
                    
                    Label label2 = new Label
                    {
                        Content = CategoryID,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 15,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };
                    TextBlock label3 = new TextBlock
                    {
                        Text = itemName,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontFamily = new FontFamily("poppins"),
                        FontSize = 17,
                        Width = 120,
                        TextWrapping = TextWrapping.Wrap
                        
                    };
                    Label label4 = new Label
                    {
                        Content = $"Rs. {price.ToString()}",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        FontSize = 14,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };

                    MenuItemData itemData = new MenuItemData
                    {
                        ItemName = itemName,
                        Price = price
                    };
                    menuItemsData.Add(itemData);

                    grid.Children.Add(label2);
                    grid.Children.Add(label3);
                    grid.Children.Add(label4);
                    button.Content = grid;

                    button.Click += Button_Click;
                    uniformGrid.Children.Add(button);
                }
            }
            SelectedMenuPrice.ItemsSource = menuItemsData;
            scrollViewer.Content = uniformGrid;
            MainGrid.Children.Add(scrollViewer);
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Accounting_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Breakfast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Alcohol_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Desserts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainCourse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pasta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Soups_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (clickedButton.Content is Grid buttonGrid)
                {
                    foreach (var uiElement in buttonGrid.Children)
                    {
                        if (uiElement is TextBlock textBlock)
                        {
                            string labelText3 = textBlock.Text;
                        }
                        else if (uiElement is Label label)
                        {
                            string labelText4 = label.Content.ToString();
                        }
                    }
                }
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
        public class MenuItemData
        {
            public string ItemName { get; set; }
            public int Price { get; set; }
        }
    }

}
