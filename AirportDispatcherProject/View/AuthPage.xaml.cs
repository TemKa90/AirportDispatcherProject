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
using AirportDispatcherLibrary;
using AirportDispatcherProject.ViewModel;

namespace AirportDispatcherProject.View
{
    /// <summary>
    ///     Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        UsersViewModel userObject = new UsersViewModel();

        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            if (
                AuthLoginTextBox.Text != String.Empty
                && AuthPasswordBox.Password != String.Empty
                && !String.IsNullOrWhiteSpace(AuthLoginTextBox.Text)
                && !String.IsNullOrWhiteSpace(AuthPasswordBox.Password)
                )
            {
                if (userObject.UserAuth(AuthLoginTextBox.Text, AuthPasswordBox.Password))
                {
                    Console.WriteLine("Условие соблюдено");
                    this.NavigationService.Navigate(new MainMenuPage());
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Не введен логин или пароль");
            }
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}
