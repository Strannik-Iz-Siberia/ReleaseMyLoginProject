using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using ReleaseMyLoginProject.HomeWindow;

namespace ReleaseMyLoginProject.Pages.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public PageEdit()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=dbs.mssql.app.biik.ru;Initial Catalog=NewVariantLogDB;Integrated Security=True;Encrypt=False");
            connection.Open();
            string cmd = "SELECT * FROM [User]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("[User]");
            dataAdp.Fill(dt);
            BDGrid.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void EditBtn_Click_1(object sender, RoutedEventArgs e)
        {
            AdminMain ad = new AdminMain();
            ad.Close();
            EditUser ed = new EditUser();
            ed.Show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BDGrid.SelectedItem != null)
            {
                // Получаем выделенную строку
                DataRowView selectedUser = (DataRowView)BDGrid.SelectedItem;

                // Получаем имя пользователя, которого нужно удалить
                string userName = selectedUser["Username"].ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=dbs.mssql.app.biik.ru;Initial Catalog=NewLog;Integrated Security=True;Encrypt=False"))
                    {
                        connection.Open();

                        string query = $"DELETE FROM [User] WHERE Username = '{userName}'";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //  возможные ошибки
                }
            }
            else
            {
                //  когда пользователь не выбран для удаления
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=dbs.mssql.app.biik.ru;Initial Catalog=NewLog;Integrated Security=True;Encrypt=False"))
                {
                    connection.Open();
                    string update = "SELECT * FROM [User]";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(update,connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    BDGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch 
            {
                
            }

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMain ad = new AdminMain();
            ad.Close();
            AddUser au = new AddUser();
            au.Show();
         
        }

        private void BlockedUser_Click(object sender, RoutedEventArgs e)
        {
            if (BDGrid.SelectedItem != null)
            {
                // Получаем выделенную строку
                DataRowView selectedUser = (DataRowView)BDGrid.SelectedItem;
                // Получаем имя пользователя, которого нужно заблокировать
                string userName = selectedUser["UserName"].ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=ATX15303;Initial Catalog=NEWLoginDB;Integrated Security=True"))
                    {
                        connection.Open();
                        // Создаем SQL-запрос для обновления статуса блокировки пользователя
                        string query = $"UPDATE [User] SET Blocked = 'YES' WHERE Username = '{userName}'";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатываем возможные ошибки
                }
            }
            else
            {
                // Обработка случая, когда пользователь не выбран для блокировки
            }
        }

        private void UnlockUser_Click(object sender, RoutedEventArgs e)
        {
            if (BDGrid.SelectedItem != null)
            {
                // Получаем выделенную строку
                DataRowView selectedUser = (DataRowView)BDGrid.SelectedItem;
                // Получаем имя пользователя, которого нужно разблокировать
                string userName = selectedUser["UserName"].ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection("Data Source=ATX15303;Initial Catalog=NEWLoginDB;Integrated Security=True"))
                    {
                        connection.Open();
                        // Создаем SQL-запрос для обновления статуса блокировки пользователя
                        string query = $"UPDATE [User] SET Blocked = 'NO' WHERE Username = '{userName}'";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обрабатываем возможные ошибки
                }
            }
            else
            {
                // Обработка случая, когда пользователь не выбран для блокировки
            }
        }
    }
}
