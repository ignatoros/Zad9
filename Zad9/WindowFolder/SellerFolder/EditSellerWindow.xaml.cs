using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Zad9.ClassFolder;

namespace Zad9.SellerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditSellerWindow.xaml
    /// </summary>
    public partial class EditSellerWindow : Window
    {
        
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Zad9; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        DataGrid grid;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        public EditSellerWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * FROM dbo.Seller " +
                    $"Where Id = '{VariableClass.Seller}'",
                    sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                SellerNameTB.Text = sqlDataReader[1].ToString();
                SellerMidlleNameTB.Text = sqlDataReader[2].ToString();
                SellerSecondNameTB.Text = sqlDataReader[3].ToString();
               
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void EditSellerBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                   
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("UPDATE " +
                        "dbo.[Seller] " +
                        $"Set SellerName = '{SellerNameTB.Text}', " +
                        $"SellerMiddleName = '{SellerMidlleNameTB.Text}', " +
                        $"SellerLastName = '{SellerSecondNameTB.Text}', " +
                        $"comsa = '{ComsaTB.Text}' " +
                        $"WHERE Id = '{VariableClass.Seller}'", sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB("Риелтор успешно отредактирован");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
