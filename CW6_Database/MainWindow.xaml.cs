using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Logan Walsh
//2-10-2023
//This program allows the user to print out a list of employees


namespace CW6_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\lwalsh6\\Desktop\\EmployeeDatabase_CW6.accdb");
        }

        private void SeeAssets_Click(object sender, RoutedEventArgs e)
        {
            cn.Close();
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\t";
                data += read[1].ToString() + "\t";
                data += read[2].ToString() + "\t";
                data += read[3].ToString() + "\n";
                DataDisplay.Text = data + "\n";
            }
            
        }
        private void SeeEmployees_Click(object sender, RoutedEventArgs e)
        {
            cn.Close();
            string query = "select* from Employee";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\t";
                data += read[1].ToString() + "\t";
                data += read[2].ToString() + "\n";
                DataDisplay.Text = data + "\n";
            }
        }

        private void DataDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
