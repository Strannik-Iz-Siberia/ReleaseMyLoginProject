using ReleaseMyLoginProject.HomeWindow;
using ReleaseMyLoginProject.Models;
using ReleaseMyLoginProject.Pages;
using ReleaseMyLoginProject.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ReleaseMyLoginProject.ViewModel
{
    public class LoginViewModel : ViewModelBase 
    {
        private string username;
        private UserModel newUser;
        private string connectionString = "Data Source=dbs.mssql.app.biik.ru;Initial Catalog=NewLog;Integrated Security=True;Encrypt=False";
        private string password;


        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

       

  

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            NewUser = new UserModel();
            AddUserCommand = new RelayCommand(AddUser);
        }

        public UserModel NewUser
        {
            get { return newUser; }
            set
            {
                newUser = value;
                OnPropertyChanged(nameof(NewUser));
            }
        }

        public ICommand LoginCommand { get; private set; }
        public ICommand AddUserCommand { get; private set; }

        public ICommand EditUserCommand { get; private set; }

        private void Login()
        {
            HomeMain hm = new HomeMain();
            AdminMain adminMain = new AdminMain();
            MainWindow mainWindow = new MainWindow();

            mainWindow.Close();
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Не введены данные!");
                return;
            }

            if (IsUserCheck(Username, Password, "Admin"))
            {
                App.Current.Windows[0].Close();
                adminMain.Show();
                mainWindow.Close();
            }
            else if (IsUserCheck(Username, Password, "User"))
            {
                App.Current.Windows[0].Close();
                hm.Show();
                mainWindow.Close();

            }
            else
            {
                MessageBox.Show("Пользователь не обнаружен.");
            }
        }


        private bool IsUserCheck(string username, string password, string role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE (Username = @Username AND Password = @Password AND Role = @Role)", connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        Console.WriteLine("Пользователь найден!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Пользователь не найден.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при выполнении запроса: " + ex.Message);
                    return false;
                }
            }
        }

        private void AddUser()
        {
            if (string.IsNullOrEmpty(NewUser.Username) || string.IsNullOrEmpty(NewUser.Name) || string.IsNullOrEmpty(NewUser.Email) || string.IsNullOrEmpty(NewUser.LastName) || string.IsNullOrEmpty(NewUser.Password))
            {
                MessageBox.Show("Не введены данные!");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (Username, Password, Name, LastName, Role, Email) VALUES (@Username, @Password, @Name, @LastName, @Role, @Email)", connection);
                {
                    command.Parameters.AddWithValue("@Username", NewUser.Username);
                    command.Parameters.AddWithValue("@Password", NewUser.Password);
                    command.Parameters.AddWithValue("@Name", NewUser.Name);
                    command.Parameters.AddWithValue("@LastName", NewUser.LastName);
                    command.Parameters.AddWithValue("@Role", "User");  // Устанавливаем значение "User" для поля Role
                    command.Parameters.AddWithValue("@Email", NewUser.Email);

                    int rowsbd = command.ExecuteNonQuery();
                    if (rowsbd > 0)
                    {
                        MessageBox.Show("Пользователь успешно добавлен в базу данных.");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить пользователя в базу данных.");
                    }
                }
            }

        }

        private void EditUser()
        {
            App.Current.Windows[0].Close();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"UPDATE [User] SET Name = @Name, LastName = @LastName, Password = @Password WHERE Username = @Username", connection);
                try
                {
                    command.Parameters.AddWithValue("@Username", NewUser.Username);
                    command.Parameters.AddWithValue("@Name", NewUser.Name);
                    command.Parameters.AddWithValue("@LastName", NewUser.LastName);

                    command.Parameters.AddWithValue("@Password", NewUser.Password);

                    int rowBD = command.ExecuteNonQuery();

                    if (rowBD > 0)
                    {
                        MessageBox.Show("Редактирование завершено");
                    }
                }
                catch
                {
                    MessageBox.Show("Пользователь не изменён");
                }
                connection.Close();
            }
        }
    }
}
