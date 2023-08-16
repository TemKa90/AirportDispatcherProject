using AirportDispatcherProject.Models;
using AirportDispatcherProject.View.FlightPages;
using AirportDispatcherProject.View.PassengerPages;
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

namespace AirportDispatcherProject.View.TicketPages //Возможно страница не нужна
{
    /// <summary>
    /// Логика взаимодействия для EditTicketPage.xaml
    /// </summary>
    public partial class EditTicketPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public EditTicketPage()
        {
            InitializeComponent();

            FlightsComboBox.ItemsSource = db.context.Flights
                .OrderBy(x => x.PointOfDepartureId) //По имени PointOfDeparture
                .Where(x => x.FreeSeatsCount > 0).ToList();
            FlightsComboBox.DisplayMemberPath = "FlightData";
            FlightsComboBox.SelectedValuePath = "IdFlight";

            PassengersComboBox.ItemsSource = db.context.Passenger.OrderBy(x => x.SecondName).ToList();
            PassengersComboBox.DisplayMemberPath = "FullName";
            PassengersComboBox.SelectedValuePath = "IdPassenger";
        }

        private void FlightsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PassengersComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFlightButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddFlightPage());
        }

        private void AddPassengerButonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddPassengerPage());
        }

        private void EditTicketButtonClick(object sender, RoutedEventArgs e)
        {
            //Доделать
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.NavigationService.GoBack();
        }
    }
}
