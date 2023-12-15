﻿using Microsoft.Win32;
using ReleaseMyLoginProject.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReleaseMyLoginProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            OpenPage(PageTypes.LoginPage); // открываем авторизацию

        }

        private void OnCotoPage(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is PageTypes type)
                OpenPage(type);
        }
        private void OpenPage(PageTypes type) //функция открытия окон
        {

            Page page;
            switch (type)
            {
                case PageTypes.LoginPage:
                    page = new LoginPage();
                    break;
                case PageTypes.RegisterPage:
                    page = new RegisterPage();
                    break;
                default:
                    throw new ArgumentException("Неожидаемое значение", nameof(type));
            }

            frame.Navigate(page);
        }

        public bool IsDarkTheme { get; set; } = false;







        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





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

        private void Themes_Checked(object sender, RoutedEventArgs e)
        {
            //image2.Visibility = Visibility.Visible;

            //image1.Visibility = Visibility.Hidden;

        }

        private void Themes_Unchecked(object sender, RoutedEventArgs e)
        {

            //image1.Visibility = Visibility.Visible;
            //image2.Visibility = Visibility.Hidden;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
