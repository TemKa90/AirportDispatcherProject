using AirportDispatcherProject.ViewModel;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void AddUserButtonClick(object sender, RoutedEventArgs e)
        {
            UsersViewModel userObject = new UsersViewModel();

            if (
                AuthLoginTextBox.Text != String.Empty
                && AuthPasswordBox.Password != String.Empty
                && !String.IsNullOrWhiteSpace(AuthLoginTextBox.Text)
                && !String.IsNullOrWhiteSpace(AuthPasswordBox.Password)
                )
            {
                if (userObject.UserReg(AuthLoginTextBox.Text, AuthPasswordBox.Password))
                {
                    MessageBox.Show("Добавление выполнено успешно !",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                //if (пользователь существует)
                //{
                //    
                //}
            }
            else
            {
                MessageBox.Show("Не введен логин или пароль");
            }
        }
    }
}
