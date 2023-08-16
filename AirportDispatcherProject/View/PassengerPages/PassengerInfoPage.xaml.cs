using AirportDispatcherProject.Models;
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

namespace AirportDispatcherProject.View.PassengerPages
{
    /// <summary>
    /// Логика взаимодействия для PassengerInfoPage.xaml
    /// </summary>
    public partial class PassengerInfoPage : Page
    {
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public PassengerInfoPage()
        {
            InitializeComponent();

            SecondNameTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerSecondName"]);
            FirstNameTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerFirstName"]);
            PatronymicNameTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPatronymicName"]);
            PhoneNumberTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPhoneNumber"]);
            AddressTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerAddress"]);
            PassportNumberTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPassportNumber"]);
            PassportPlaceTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPlaseOfPassportIssue"]);
        }

        private void EditPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditPassengerPage());
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Content = null;
        }
    }
}
