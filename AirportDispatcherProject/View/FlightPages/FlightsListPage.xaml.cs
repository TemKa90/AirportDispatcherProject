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
using AirportDispatcherProject.Models;
using AirportDispatcherProject.View.FlightPages;

namespace AirportDispatcherProject.View
{
    /// <summary>
    /// Логика взаимодействия для FlightListPage.xaml
    /// </summary>
    public partial class FlightsListPage : Page
    {
        Core db = new Core();
        List<Flights> elementsList = new List<Flights>();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public FlightsListPage()
        {
            InitializeComponent();
            FlightListView.ItemsSource = db.context.Flights.ToList();
        }

        private void ShowTable()
        {
            List<Flights> arrayFlights = db.context.Flights.ToList();

            if (SelectComboBox.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayFlights = arrayFlights.Where(x => x.FlightNumber.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                FlightListView.ItemsSource = arrayFlights;
            }

            if (SelectComboBox.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayFlights = arrayFlights.Where(x => x.Companies.CompanyName.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                FlightListView.ItemsSource = arrayFlights;
            }

            if (SelectComboBox.SelectedIndex == 3)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayFlights = arrayFlights.Where(x => Convert.ToString(x.FreeSeatsCount).ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                FlightListView.ItemsSource = arrayFlights;
            }
        }

        private void SeacrhTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void AddFlightButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddFlightPage());
        }

        private void DellCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Flights item = activeCheckBox.DataContext as Flights;

            elementsList.Add(item);
        }

        private void DellCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Flights item = activeCheckBox.DataContext as Flights;

            elementsList.Remove(item);
        }

        private void DellFlightButtonClick(object sender, RoutedEventArgs e)
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
                        List<Ticket> ticketsList = db.context.Ticket.Where(ticket => ticket.Flight == item.IdFlight).ToList();
                        if (ticketsList.Count > 0)
                        {
                            foreach (var ticket in ticketsList)
                            {
                                db.context.Ticket.Remove(ticket);
                            }
                        }
                        db.context.Flights.Remove(item);
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

            FlightListView.ItemsSource = db.context.Flights.ToList();
            elementsList.Clear();
        }

        private void FlightListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flights selectedFlight = FlightListView.SelectedItem as Flights;

            Application.Current.Resources["selectedFlight"] = selectedFlight;

            Application.Current.Resources["selectedFlightId"] = selectedFlight.IdFlight;
            Application.Current.Resources["selectedFlightNumber"] = selectedFlight.FlightNumber;
            Application.Current.Resources["selectedFlightCompanyCode"] = selectedFlight.Companies.CompanyCode;
            Application.Current.Resources["selectedFlightCompanyName"] = selectedFlight.Companies.CompanyName;
            Application.Current.Resources["selectedFlightDateOfDeparture"] = selectedFlight.DateOfDeparture;
            Application.Current.Resources["selectedFlightTimeOfDeparture"] = selectedFlight.TimeOfDeparture;
            Application.Current.Resources["selectedFlightPointOfDepartureId"] = selectedFlight.PointOfDepartureId;
            Application.Current.Resources["selectedFlightPointOfArrivalId"] = selectedFlight.PointOfArrivalId;
            Application.Current.Resources["selectedFlightAirplaneId"] = selectedFlight.AirplaneId;
            Application.Current.Resources["selectedFlightSeatsCount"] = selectedFlight.Airplane.SeatsCount; //Тут проблема, так как в базе нет таблицы Airplane
            Application.Current.Resources["selectedFlightFreeSeatsCount"] = selectedFlight.FreeSeatsCount;

            mw.EditFrame.Navigate(new FlightInfoPage());
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage());
            mw.EditFrame.Content = null;
        }

        private void ReloadButtonClick(object sender, RoutedEventArgs e)
        {
            FlightListView.ItemsSource = db.context.Flights.ToList();
        }
    }
}
