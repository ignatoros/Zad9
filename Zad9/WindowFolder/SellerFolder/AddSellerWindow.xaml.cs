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
    /// Логика взаимодействия для AddSellerWindow.xaml
    /// </summary>
    public partial class AddSellerWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Zad9; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        DataGrid grid;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        public AddSellerWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void AddSellerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SellerNameTB.Text) ||
                string.IsNullOrWhiteSpace(SellerMidlleNameTB.Text) ||
                string.IsNullOrWhiteSpace(SellerSecondNameTB.Text))
                
                

            {
                MBClass.ErrorMB("Заполните все поля");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    if (!string.IsNullOrWhiteSpace(ComsaTB.Text))
                    {
                        int a = Convert.ToInt32(ComsaTB.Text);

                        if (a > 100)
                        {
                            MBClass.ErrorMB("можно ввести от 0 до 100");
                        }
                        else if (a < 0)
                        {
                            MBClass.ErrorMB("можно ввести от 0 до 100");
                        }
                        else
                        {
                            sqlCommand = new SqlCommand("INSERT INTO dbo.Seller " +
                            "(SellerName, SellerMiddleName, SellerLastName, comsa) Values " +
                            $"('{SellerNameTB.Text}', '{SellerMidlleNameTB.Text}', " +
                            $"'{SellerSecondNameTB.Text}', " +
                            $"'{Convert.ToInt32(ComsaTB.Text)}')", sqlConnection);

                            

                        }
                    }
                    else
                    {



                        sqlCommand = new SqlCommand("INSERT INTO dbo.Seller " +
                        "(SellerName, SellerMiddleName, SellerLastName, comsa) Values " +
                        $"('{SellerNameTB.Text}', '{SellerMidlleNameTB.Text}', " +
                        $"'{SellerSecondNameTB.Text}', null)", sqlConnection);

                       

                    }
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB("Риелтор успешно добавлен");
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
    }
    }

