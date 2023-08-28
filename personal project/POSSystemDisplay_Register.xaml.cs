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
        public POSSystemDisplay_Register()
        {
            InitializeComponent();
            MainFocusWindow.Navigate(new Uri("Page2Tables.xaml", UriKind.Relative));
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainFocusWindow.Navigate(new Uri("MenuPage1.xaml", UriKind.Relative));

        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            MainFocusWindow.Navigate(new Uri("Page2Tables.xaml", UriKind.Relative));

        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
            MainFocusWindow.Navigate(new Uri("Page2Tables.xaml", UriKind.Relative));

        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            MainFocusWindow.Navigate(new Uri("Page2Tables.xaml", UriKind.Relative));

        }

        private void Accounting_Click(object sender, RoutedEventArgs e)
        {
            MainFocusWindow.Navigate(new Uri("Page2Tables.xaml", UriKind.Relative));

        }
    }

}
