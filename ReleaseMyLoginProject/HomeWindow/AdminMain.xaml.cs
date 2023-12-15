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
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
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
            PagesNavigation.Navigate(new System.Uri("Pages/PageAdmin/PageEdit.xaml", UriKind.RelativeOrAbsolute));
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

    }
}
