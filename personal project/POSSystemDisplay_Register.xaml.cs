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
            ScrollViewer scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            };
            UniformGrid uniformGrid = new UniformGrid
            {
                Columns = 4,
                Margin = new Thickness(10)
            };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM MenuItems";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                int colorIndex = 0;
                while (reader.Read())
                {
                    string buttonText = reader["ItemName"].ToString();
                    Button button = new Button
                    {
                        Height = 125,
                        Width = 125,
                        Background = new SolidColorBrush(ButtonColors[colorIndex]),
                        Margin = new Thickness(10),
                        FontSize = 20,
                        Content = buttonText
                    };
                    colorIndex = (colorIndex + 1) % ButtonColors.Length;
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
