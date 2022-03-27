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
            //проверка корректности заполнения логина
            if (
                AuthLoginTextBox.Text != String.Empty
                && AuthPasswordBox.Password != String.Empty
                && !String.IsNullOrWhiteSpace(AuthLoginTextBox.Text)
                && !String.IsNullOrWhiteSpace(AuthPasswordBox.Password)
                )
            {
                //проверка присутствия данных в БД
                //int countRecord = этоБаза
                // .Where(x => x.Login == AuthLoginTextBox.Text && x.Password == AuthPasswordBox.Password)
                // .Count();
                //if (countRecord == 1)
                //{
                //    this.NavigationService.Navigate(new MainMenuPage());
                //}
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
