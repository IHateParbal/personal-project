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
        private static readonly Color[] ButtonColors = { Colors.Tomato, Colors.CornflowerBlue, Colors.Salmon, Colors.Coral, Colors.LightSeaGreen };
        public POSSystemDisplay_Register()
        {
            InitializeComponent();
            // Create a ScrollViewer
            ScrollViewer scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
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

                int categoryIDToFilter = 1; // Change this to the desired CategoryID

                string query = $"SELECT ItemName, Price FROM MenuItems WHERE CategoryID = {categoryIDToFilter}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int colorIndex = 0;

                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);

                    Button button = new Button
                    {
                        Height = 125,
                        Width = 125,
                        Background = new SolidColorBrush(ButtonColors[colorIndex % ButtonColors.Length]),
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
                        Content = "01",
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 15,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };

                    Label label2 = new Label
                    {
                        Content = "breakfast",
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        FontSize = 15,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };

                    Label label3 = new Label
                    {
                        Content = itemName,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontFamily = new FontFamily("poppins"),
                        FontSize = 30
                    };

                    Label label4 = new Label
                    {
                        Content = price.ToString(),
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        FontSize = 13,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };

                    grid.Children.Add(label1);
                    grid.Children.Add(label2);
                    grid.Children.Add(label3);
                    grid.Children.Add(label4);

                    button.Content = grid;

                    colorIndex++;

                    uniformGrid.Children.Add(button);
                }
            }

            // Set the content of the ScrollViewer to the UniformGrid
            scrollViewer.Content = uniformGrid;

            // Add the ScrollViewer to the main window's content
            MainGrid.Children.Add(scrollViewer);
        }
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
