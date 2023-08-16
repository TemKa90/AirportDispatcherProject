using AirportDispatcherProject.Models;
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

namespace AirportDispatcherProject.View.PassengerPages
{
    /// <summary>
    /// Логика взаимодействия для EditPassengerPage.xaml
    /// </summary>
    public partial class EditPassengerPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public EditPassengerPage()
        {
            InitializeComponent();

            SecondNameTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerSecondName"]);
            FirstNameTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerFirstName"]);
            PatronymicNameTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPatronymicName"]);
            PhoneNumberTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPhoneNumber"]);
            AddressTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerAddress"]);
            PassportNumberTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPassportNumber"]);
            PassportPlaceTextBox.Text = Convert.ToString(Application.Current.Resources["selectedPassengerPlaseOfPassportIssue"]);
        }

        private void EditPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            PassengersViewModel pvm = new PassengersViewModel();
            if (
                SecondNameTextBox.Text != String.Empty
                && FirstNameTextBox.Text != String.Empty
                && PatronymicNameTextBox.Text != String.Empty
                && PhoneNumberTextBox.Text != String.Empty
                && AddressTextBox.Text != String.Empty
                && PassportNumberTextBox.Text != String.Empty
                && PassportNumberTextBox.Text != String.Empty

                && !String.IsNullOrWhiteSpace(SecondNameTextBox.Text)
                && !String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                && !String.IsNullOrWhiteSpace(PatronymicNameTextBox.Text)
                && !String.IsNullOrWhiteSpace(PhoneNumberTextBox.Text)
                && !String.IsNullOrWhiteSpace(AddressTextBox.Text)
                && !String.IsNullOrWhiteSpace(PassportNumberTextBox.Text)
                && !String.IsNullOrWhiteSpace(PassportPlaceTextBox.Text)
                )
            {
                if (pvm.EditPassenger(SecondNameTextBox.Text, FirstNameTextBox.Text, PatronymicNameTextBox.Text,
                                        PhoneNumberTextBox.Text, AddressTextBox.Text,
                                        PassportNumberTextBox.Text, PassportPlaceTextBox.Text))
                {
                    MessageBox.Show("Данные обновлены",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                    mw.EditFrame.NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Неизвестная ошибка",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.None);
                }
                //if (пассажир существует)
                //{
                //    
                //}
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.NavigationService.GoBack();
        }
    }
}
