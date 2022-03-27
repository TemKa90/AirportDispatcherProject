﻿using System;
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
using AirportDispatcherLibrary;

namespace AirportDispatcherProject.View
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            UserAuthRegClass newObject = new UserAuthRegClass();
            newObject.UserAuth(AuthLoginTextBox.Text, AuthPasswordBox.Password);
        }
    }
}
