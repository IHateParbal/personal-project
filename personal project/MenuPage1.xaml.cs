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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace personal_project
{
    /// <summary>
    /// Interaction logic for MenuPage1.xaml
    /// </summary>
    public class OrderItem
    {
        public int OrderQuantity { get; set; }
        public double OrderPrice { get; set; }
        public double Price { get; set; }
    }
    public partial class MenuPage1 : Page
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        private DataGrid dataGrid;
        private string labelText3 = null;
        private string labelText4 = null;
        private ScrollViewer scrollViewer;
        private UniformGrid uniformGrid1;
        int sum = 0;
        private int counter = 1;
        private Button button1;
        private Label labelQuantity;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madgw\source\repos\Console\personal project\personal project\POS.mdf;Integrated Security=True;Connect Timeout=30";

        

        public MenuPage1()
        {
            InitializeComponent();
            // Create a ScrollViewer
            scrollViewer = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
            };

            // Create a UniformGrid
            uniformGrid1 = new UniformGrid
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
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
            MainGrid.Children.Add(scrollViewer);
        }

        private Button ButtonCreation(string itemName, int price)
        {
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
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(0, 10, 0, 0),
                FontFamily = new FontFamily("poppins"),
                FontSize = 17,
                Width = 120,
                TextWrapping = TextWrapping.Wrap
            };
            Label label4 = new Label
            {
                Content = price.ToString(),
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
            return button;
        }

        private void Breakfast_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Breakfast';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Alcohol_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Alcohols';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Drinks';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Desserts_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Desserts';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void MainCourse_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Main Course';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Pasta_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID" +
                    " WHERE C.CategoryName = 'Pasta';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Soups_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Soup';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE C.CategoryName = 'Special';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            counter = 1;
            labelText3 = null;
            labelText4 = null;

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

            int parsedLabelText4 = int.Parse(labelText4);
            selectedItemMiniTab.Children.Clear();
            dataGrid = new DataGrid
            {                
                AutoGenerateColumns = true,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                ItemsSource = orderItems
            };

            selectedItemMiniTab.Children.Add(dataGrid);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///

            int priceint = int.Parse(labelText4) * counter;
            int Vat = 13;
            sum += priceint;
            double finalPrice = sum + (0.13 * sum);
            BillReport.Text = "SubTotal Price:          " + sum + "\nVAT:                           " + Vat + "%\nTotal Price:                " + finalPrice;
            orderItems.Add(new OrderItem { OrderPrice = parsedLabelText4, OrderQuantity = counter, Price = finalPrice});
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string SearchItem = Search.Text;
            uniformGrid1.Children.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT MI.MenuItemID, MI.ItemName, MI.Price, C.CategoryName FROM MenuItems MI JOIN Categories C ON MI.CategoryID = C.CategoryID " +
                    "WHERE MI.ItemName = '" + SearchItem + "';";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int price = Convert.ToInt32(reader["Price"]);
                    Button button = ButtonCreation(itemName, price);
                    uniformGrid1.Children.Add(button);
                }
            }
            scrollViewer.Content = uniformGrid1;
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

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            if (sender is Button deleteButton)
            {
                if (deleteButton.Parent is StackPanel mainStackPanel)
                {
                    if (mainStackPanel.Parent is StackPanel selectedItemMiniTab)
                    {
                        selectedItemMiniTab.Children.Remove(mainStackPanel);

                        if (deleteButton.Content is Grid buttonGrid)
                        {
                            foreach (var uiElement in buttonGrid.Children)
                            {
                                if (uiElement is Label label)
                                {
                                    if (int.TryParse(label.Content.ToString(), out int priceToDelete))
                                    {
                                        sum -= priceToDelete;
                                        UpdateBillReport();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void UpdateBillReport()
        {
            int Vat = 13;
            double finalPrice = sum + (0.13 * sum);
            BillReport.Text = "SubTotal Price:          " + sum + "\nVAT:                           " + Vat + "%\nTotal Price:                " + finalPrice;
        }

        private void Button_ClickDecrease(object sender, RoutedEventArgs e)
        {
            if (counter > 1)
            {
                counter--;
                labelQuantity.Content = "x" + counter;
                UpdateBill(counter, labelText4);

            }
        }

        private void Button_ClickIncrease(object sender, RoutedEventArgs e)
        {
            counter++;
            labelQuantity.Content = "x" + counter;
            UpdateBill(counter, labelText4);
        }

        private void UpdateBill(int counter, string labelText4)
        {
            int priceint = int.Parse(labelText4) * counter;
            int Vat = 13;
            double finalPrice = priceint + (0.13 * priceint);
            BillReport.Text = "SubTotal Price:          " + priceint + "\nVAT:                           " + Vat + "%\nTotal Price:                " + finalPrice;

        }

    }
}
