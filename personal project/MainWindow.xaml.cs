using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

namespace personal_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\madgw\source\repos\Console\personal project\personal project\POS.mdf;Integrated Security=True;Connect Timeout=30";
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button SignupClicked = (Button)sender;
            string Signuptext = SignupClicked.Content.ToString();
            LoginSignup.Content = Signuptext;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button LoginClicked = (Button)sender;
            string Signuptext = LoginClicked.Content.ToString();
            LoginSignup.Content = Signuptext;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserName = Username.Text; 
            Password = password.Password;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlInsertQuery = "INSERT INTO Users (UserName, Password) VALUES (@Username, @Password)";
                    using (SqlCommand insertCommand = new SqlCommand(sqlInsertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Username", UserName);
                        insertCommand.Parameters.AddWithValue("@Password", Password);
                        insertCommand.ExecuteNonQuery();
                    }
                    //use this to get to another window that might be anything most likely Hme page
                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}