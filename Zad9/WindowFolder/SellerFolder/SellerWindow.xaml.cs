using System;
using System.Collections.Generic;
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

namespace Zad9.SellerFolder
{
    /// <summary>
    /// Логика взаимодействия для SellerWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            InitializeComponent();
        }

        private void AddSellerBtn_Click(object sender, RoutedEventArgs e)
        {
            new SellerFolder.AddSellerWindow().ShowDialog();
        }

        private void ListSellerBtn_Click(object sender, RoutedEventArgs e)
        {
            new SellerFolder.ListSellerWindow().ShowDialog();
        }
    }
}
