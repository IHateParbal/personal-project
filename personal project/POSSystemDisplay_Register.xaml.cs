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

                string query = "SELECT * FROM MenuItems";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string buttonText = reader["ButtonText"].ToString();
                    string buttonColor = reader["ButtonColor"].ToString();

                    Button button = new Button
                    {
                        Height = 125,
                        Width = 125,
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(buttonColor)),
                        Margin = new Thickness(10),
                        FontSize = 20,
                        Content = buttonText
                    };

                    uniformGrid.Children.Add(button);
                }
            }

            // Set the content of the ScrollViewer to the UniformGrid
            scrollViewer.Content = uniformGrid;

            // Add the ScrollViewer to the main window's content
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
