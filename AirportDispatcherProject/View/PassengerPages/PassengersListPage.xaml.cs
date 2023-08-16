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
    /// Логика взаимодействия для PassengersListPage.xaml
    /// </summary>
    public partial class PassengersListPage : Page
    {
        Core db = new Core();
        List<Passenger> elementsList = new List<Passenger>();
        MainWindow mw = Application.Current.MainWindow as MainWindow;
        //TicketsViewModel tvm = new TicketsViewModel();

        public PassengersListPage()
        {
            InitializeComponent();
            PassengerListView.ItemsSource = db.context.Passenger.ToList();
        }

        private void ShowTable()
        {
            List<Passenger> arrayPassengers = db.context.Passenger.ToList();

            if (SelectComboBox.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayPassengers = arrayPassengers.Where(x => x.FullName.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                PassengerListView.ItemsSource = arrayPassengers;
            }

            if (SelectComboBox.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayPassengers = arrayPassengers.Where(x => x.PhoneNumber.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                PassengerListView.ItemsSource = arrayPassengers;
            }

            if (SelectComboBox.SelectedIndex == 3)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayPassengers = arrayPassengers.Where(x => x.PassportNumber.Contains(SeacrhTextBox.Text)).ToList();
                }
                PassengerListView.ItemsSource = arrayPassengers;
            }

            if (SelectComboBox.SelectedIndex == 4)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayPassengers = arrayPassengers.Where(x => x.Address.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                PassengerListView.ItemsSource = arrayPassengers;
            }
        }

        private void SeacrhTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void AddPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddPassengerPage());
        }

        private void DellCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Passenger item = activeCheckBox.DataContext as Passenger;

            elementsList.Add(item);
        }

        private void DellCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Passenger item = activeCheckBox.DataContext as Passenger;

            elementsList.Remove(item);
        }

        private void DellPassengerButtonClick(object sender, RoutedEventArgs e)
        {

            if (elementsList.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show(
                "Выбранные элементы будут удалены. Продолжить?",
                "Удаление",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    foreach (var item in elementsList)
                    {
                        List<Ticket> ticketsList = db.context.Ticket.Where(ticket => ticket.PassengerName == item.IdPassenger).ToList();
                        if (ticketsList.Count > 0)
                        {
                            foreach (var ticket in ticketsList)
                            {
                                db.context.Ticket.Remove(ticket);
                            }
                        }
                        db.context.Passenger.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                "Не выбран ни один элемент",
                "Удаление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }

            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show(
                "Данные удалены",
                "Удаление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }

            PassengerListView.ItemsSource = db.context.Passenger.ToList();
            elementsList.Clear();
        }

        private void PassengerListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Passenger selectedPassenger = PassengerListView.SelectedItem as Passenger;

            if (selectedPassenger != null)
            {
                Application.Current.Resources["selectedPassenger"] = selectedPassenger;

                Application.Current.Resources["selectedPassengerId"] = selectedPassenger.IdPassenger;
                Application.Current.Resources["selectedPassengerFirstName"] = selectedPassenger.FirstName;
                Application.Current.Resources["selectedPassengerSecondName"] = selectedPassenger.SecondName;
                Application.Current.Resources["selectedPassengerPatronymicName"] = selectedPassenger.PatronymicName;
                Application.Current.Resources["selectedPassengerPhoneNumber"] = selectedPassenger.PhoneNumber;
                Application.Current.Resources["selectedPassengerAddress"] = selectedPassenger.Address;
                Application.Current.Resources["selectedPassengerPassportNumber"] = selectedPassenger.PassportNumber;
                Application.Current.Resources["selectedPassengerPlaseOfPassportIssue"] = selectedPassenger.PlaseOfPassportIssue;
            }
            mw.EditFrame.Navigate(new PassengerInfoPage());
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage());
            mw.EditFrame.Content = null;
        }

        private void ReloadButtonClick(object sender, RoutedEventArgs e)
        {
            PassengerListView.ItemsSource = db.context.Passenger.ToList();
        }
    }
}
