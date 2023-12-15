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
            SqlConnection connection = new SqlConnection("Data Source=dbs.mssql.app.biik.ru;Initial Catalog=NewLog;Integrated Security=True;Encrypt=False");
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

        }
    }
}
