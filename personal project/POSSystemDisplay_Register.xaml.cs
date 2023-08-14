using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

namespace personal_project
{
    /// <summary>
    /// Interaction logic for POSSystemDisplay_Register.xaml
    /// </summary>
    public partial class POSSystemDisplay_Register : Window
    {
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
                    int MenuItemID = Convert.ToInt32(reader["MenuItemID"]);
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
                    Label label1 = new Label
                    {
                        Content = MenuItemID,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 15,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
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
                    grid.Children.Add(label1);
                    grid.Children.Add(label2);
                    grid.Children.Add(label3);
                    grid.Children.Add(label4);

                    button.Content = grid;

                    uniformGrid.Children.Add(button);
                }
            }
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
    }
}
