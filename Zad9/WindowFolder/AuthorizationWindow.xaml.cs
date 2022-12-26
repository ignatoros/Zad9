using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Zad9.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Zad9; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        int caunter = 0;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Вы не ввели логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Вы не ввели пароль");
                PasswordPsb.Focus();
            }
            else if (caunter == 3)
            {
                MBClass.InfoMB("Слишком большое количество попыток");
                Thread.Sleep(5000);
               
                caunter = 0;
                
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand =
                        new SqlCommand("Select * " +
                        "FROM dbo.[User] " +
                        $"Where Login = '{LoginTB.Text}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();
                    if (dataReader[1].ToString() != PasswordPsb.Password)
                    {
                        MBClass.ErrorMB("Вы ввели неверный пароль");
                        PasswordPsb.Focus();
                        caunter++;
                    }
                    else
                    {
                        switch (dataReader[2].ToString())
                        {
                            case "1":
                                new SellerFolder.SellerWindow().ShowDialog();
                                break;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                    caunter++;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void RegistrationTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new SellerFolder.AddSellerWindow().ShowDialog();
        }

       
    }
}
