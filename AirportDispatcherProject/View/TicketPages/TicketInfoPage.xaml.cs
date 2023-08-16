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

namespace AirportDispatcherProject.View.TicketPages
{
    /// <summary>
    /// Логика взаимодействия для TicketInfoPage.xaml
    /// </summary>
    public partial class TicketInfoPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;
        TicketsListPage tlp = new TicketsListPage();

        public TicketInfoPage()
        {
            InitializeComponent();

            TicketNumberTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedTicketNumber"]);

            int ticketFlight = Convert.ToInt32(Application.Current.Resources["selectedTicketFlight"]);
            FlightTextBlock.Text = Convert.ToString(db.context.Flights.Where(x => x.IdFlight == ticketFlight).FirstOrDefault().FlightNumber);

            int ticketPassenger = Convert.ToInt32(Application.Current.Resources["selectedTicketPassenger"]);
            PassengerTextBlock.Text = Convert.ToString(db.context.Passenger.Where(x => x.IdPassenger == ticketPassenger).FirstOrDefault().FullName);

            BookingDateTimeTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedTicketBookingDateTime"]);
        }

        private void DellTicketButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedTicketId = Convert.ToInt32(Application.Current.Resources["selectedTicketId"]);

            MessageBoxResult result = MessageBox.Show(
            "Вернуть данный билет?",
            "Возврат билета",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                db.context.Ticket.Remove(db.context.Ticket.Where(x => x.IdTicket == selectedTicketId).FirstOrDefault());
            }
            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show(
                "Данные удалены",
                "Удаление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            tlp.TicketListView.ItemsSource = db.context.Ticket.ToList();
        }

        private void FlightTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ticket ticket = Application.Current.Resources["selectedTicket"] as Ticket;
            Flights selectedFlight = db.context.Flights.Where(x => x.IdFlight == ticket.Flight).FirstOrDefault();

            Application.Current.Resources["selectedFlight"] = selectedFlight;

            Application.Current.Resources["selectedFlightId"] = selectedFlight.IdFlight;
            Application.Current.Resources["selectedFlightNumber"] = selectedFlight.FlightNumber;
            Application.Current.Resources["selectedFlightCompanyCode"] = selectedFlight.CompanyCode;
            Application.Current.Resources["selectedFlightCompanyName"] = selectedFlight.CompanyName;
            Application.Current.Resources["selectedFlightDateOfDeparture"] = selectedFlight.DateOfDeparture;
            Application.Current.Resources["selectedFlightTimeOfDeparture"] = selectedFlight.TimeOfDeparture;
            Application.Current.Resources["selectedFlightPointOfDepartureId"] = selectedFlight.PointOfDepartureId;
            Application.Current.Resources["selectedFlightPointOfArrivalId"] = selectedFlight.PointOfArrivalId;
            Application.Current.Resources["selectedFlightAirplaneId"] = selectedFlight.AirplaneId;
            Application.Current.Resources["selectedFlightFreeSeatsCount"] = selectedFlight.FreeSeatsCount;

            mw.EditFrame.Navigate(new FlightInfoPage());
        }

        private void PassengerTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ticket ticket = Application.Current.Resources["selectedTicket"] as Ticket;
            Passenger selectedPassenger = db.context.Passenger.Where(x => x.IdPassenger == ticket.PassengerName).FirstOrDefault();

            Application.Current.Resources["selectedPassenger"] = selectedPassenger;

            Application.Current.Resources["selectedPassengerId"] = selectedPassenger.IdPassenger;
            Application.Current.Resources["selectedPassengerFirstName"] = selectedPassenger.FirstName;
            Application.Current.Resources["selectedPassengerSecondName"] = selectedPassenger.SecondName;
            Application.Current.Resources["selectedPassengerPatronymicName"] = selectedPassenger.PatronymicName;
            Application.Current.Resources["selectedPassengerPhoneNumber"] = selectedPassenger.PhoneNumber;
            Application.Current.Resources["selectedPassengerAddress"] = selectedPassenger.Address;
            Application.Current.Resources["selectedPassengerPassportNumber"] = selectedPassenger.PassportNumber;
            Application.Current.Resources["selectedPassengerPlaseOfPassportIssue"] = selectedPassenger.PlaseOfPassportIssue;

            mw.EditFrame.Navigate(new PassengerInfoPage());

        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Content = null;
        }
    }
}
