using ReleaseMyLoginProject.Pages.PageHome;
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

namespace ReleaseMyLoginProject.HomeWindow
{
    /// <summary>
    /// Логика взаимодействия для HomeMain.xaml
    /// </summary>
    public partial class HomeMain : Window
    {
        public HomeMain()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();

        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Uri("Pages/PageHome/HomePage.xaml", UriKind.Relative));

        }

       

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/PageHome/CoupSchedulePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/PageHome/InfoStudent.xaml", UriKind.RelativeOrAbsolute));
        }

        public bool IsDarkTheme { get; set; } = false;
        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (IsDarkTheme)
            {
                // Применить светлую тему 
                ResourceDictionary lightTheme = new ResourceDictionary() { Source = new Uri("Themes/Light.xaml", UriKind.Relative) };

                Application.Current.Resources.MergedDictionaries.Add(lightTheme);



            }
            else
            {
                // Применить темную тему 
                ResourceDictionary darkTheme = new ResourceDictionary() { Source = new Uri("Themes/Dark.xaml", UriKind.Relative) };
                Application.Current.Resources.MergedDictionaries.Add(darkTheme);


            }

            IsDarkTheme = !IsDarkTheme;

        }

        
        private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cb.SelectedItem;
            string selectedSize = selectedItem.Content.ToString();

            if (selectedSize == "1280 на 1024")
            {
                this.Height = 924; // Установка высоты окна
                this.Width = 1280; // Установка ширины окна
            }
            else if (selectedSize == "1280 на 960")
            {
                this.Height = 960; // Установка высоты окна
                this.Width = 1280; // Установка ширины окна
            }
            else if (selectedSize == "1350 на 1000")
            {
                this.Height = 980; // Установка высоты окна
                this.Width = 1350; // Установка ширины окна
            }
            else if (selectedSize == "1000 на 650")
            {
                this.Height = 650; // Установка высоты окна
                this.Width = 1000; // Установка ширины окна
            }
        }
    }
}
