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
using Zad9.ClassFolder;

namespace Zad9.SellerFolder
{
    /// <summary>
    /// Логика взаимодействия для ListSellerWindow.xaml
    /// </summary>
    public partial class ListSellerWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Zad9; Integrated Security = True");
        DGClass dGClass;
        
        public ListSellerWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListBookDG);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ListBookDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку");
            }
            else
            {
                VariableClass.Seller = dGClass.SelectId();
                try
                {
                    new SellerFolder.EditSellerWindow().ShowDialog();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            VariableClass.Seller = dGClass.SelectId();
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("DELETE dbo.Seller " +
                            $"Where Id = '{VariableClass.Seller}'",
                            sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MBClass.InfoMB("Риелтор успешно удален");
            dGClass.LoadDG("SELECT * FROM dbo.[SellerView]");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * From dbo.[SellerView]");
        }
    }
}
