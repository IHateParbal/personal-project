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
using System.Xml.Linq;
using static personal_project.POSSystemDisplay_Register;

namespace personal_project
{
    /// <summary>
    /// Interaction logic for POSSystemDisplay_Register.xaml
    /// </summary>
    public partial class POSSystemDisplay_Register : Window
    {
        int sum = 0;
        int increase = 0;
        private int count = 0;
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
            UniformGrid uniformGrid1 = new UniformGrid
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
                    Button button = new Button
                    {
                        Height = 125,
                        Width = 125,
                        Margin = new Thickness(10),
                        FontSize = 20
                    };
                    Grid grid = new Grid
                    {
                        Height = 125,
                        Width = 125
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
                        Content =price.ToString(),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        FontSize = 15,
                        FontWeight = FontWeights.SemiBold,
                        FontFamily = new FontFamily("poppins")
                    };
                    grid.Children.Add(label3);
                    grid.Children.Add(label4);
                    button.Content = grid;

                    button.Click += Button_Click;
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
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
        private void Button_Click(object sender, RoutedEventArgs e )
        {

            string labelText3 = null;
            string labelText4 = null;

            if (sender is Button clickedButton)
            {
                if (clickedButton.Content is Grid buttonGrid)
                {
                    foreach (var uiElement in buttonGrid.Children)
                    {
                        if (uiElement is TextBlock textBlock)
                        {
                            labelText3 = textBlock.Text.ToString();
                        }
                        else if (uiElement is Label label)
                        {
                            labelText4 = label.Content.ToString();
                        }
                    }
                }
            }

            Button button = new Button
            {
                Height = 80,
                Width = 250,
                Margin = new Thickness(5),
                HorizontalContentAlignment = HorizontalAlignment.Left
            };

            Grid grid = new Grid();

            TextBlock label3 = new TextBlock
            {
                Text = labelText3,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                FontFamily = new FontFamily("poppins"),
                FontSize = 17,
                FontWeight = FontWeights.Bold,
                TextWrapping = TextWrapping.Wrap,
                Height = 50,
                Width = 225,
                Margin = new Thickness(0, 0, 0, 15),
            };

            Label label4 = new Label
            {
                Content = labelText4,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                FontSize = 15,
                FontWeight = FontWeights.SemiBold,
                FontFamily = new FontFamily("poppins")
            };
            grid.Children.Add(label3);
            grid.Children.Add(label4);

            // Set the grid as the button's content
            button.Content = grid;

            selectedItemMiniTab.Children.Add(button);

            button.Click += Button_ClickTab;






            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///

            int priceint = int.Parse(labelText4);
            int Vat = 13;
                sum += priceint;
            double finalPrice = sum + (0.13 * sum);
                BillReport.Text = "SubTotal Price:          " + sum + "\nVAT:                           " +Vat+ "%\nTotal Price:                "+finalPrice;

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_ClickTab(object sender, RoutedEventArgs e)
        {
            string labelText4 = null;

            if (sender is Button clickedButton)
            {
                if (clickedButton.Content is Grid buttonGrid)
                {
                    foreach (var uiElement in buttonGrid.Children)
                    {
                        if (uiElement is Label label)
                        {
                            labelText4 = label.Content.ToString();
                        }
                    }
                }
            }
            increase = sum;
             increase = increase+increase;
            BillReport.Text = "SubTotal Price:             " + increase;
        }

        private void CashPaymnt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CardPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void E_WalletPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
