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
    /// Логика взаимодействия для AddPassengerPage.xaml
    /// </summary>
    public partial class AddPassengerPage : Page
    {
        public AddPassengerPage()
        {
            InitializeComponent();
        }

        private void AddPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            PassengersViewModel pvm = new PassengersViewModel();

            if (pvm.PassengerDbCheck(PassportNumberTextBox.Text))
            {
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
                    if (pvm.AddPassenger(SecondNameTextBox.Text, FirstNameTextBox.Text, PatronymicNameTextBox.Text,
                                                PhoneNumberTextBox.Text, AddressTextBox.Text,
                                                PassportNumberTextBox.Text, PassportPlaceTextBox.Text))
                    {
                        MessageBox.Show("Добавление выполнено успешно!",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
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
            else
            {
                MessageBox.Show("Такой пассажир уже зарегистрирован.",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
