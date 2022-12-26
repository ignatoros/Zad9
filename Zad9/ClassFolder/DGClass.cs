using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zad9.ClassFolder
{
    class DGClass
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source = (local)\SQLEXPRESS; Initial Catalog = Zad9; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader dataReader;
        DataGrid grid;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        public DGClass(DataGrid grid)
        {
            this.grid = grid;
        }
        public void LoadDG(string command)
        {
            try
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(command, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                grid.ItemsSource = dataTable.DefaultView;
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
        public string SelectId()
        {
            object[] mass = null;
            string id = "";
            try
            {
                if (grid != null)
                {
                    DataRowView dataRowView = grid.SelectedItem as DataRowView;

                    if (dataRowView != null)
                    {
                        DataRow row = (DataRow)dataRowView.Row;
                        mass = row.ItemArray;
                    }
                }
                id = mass[0].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            return id;
        }
    }
}
