using AirportDispatcherLibrary;
using AirportDispatcherProject.Models;
using AirportDispatcherProject.View.FlightPages;
using AirportDispatcherProject.View.PassengerPages;
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

namespace AirportDispatcherProject.View.TicketPages
{
    /// <summary>
    /// Логика взаимодействия для AddTicketPage.xaml
    /// </summary>
    public partial class SellTicketPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public SellTicketPage()
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

            //Ticket selectedTicket = Application.Current.Resources["selectedTicket"] as Ticket;
            //PriceTextBlock.Text = Convert.ToString(db.context.Flights.Where(x => x.IdFlight == selectedTicket.Flight).FirstOrDefault().Price);
            СurrencyTextBlock.Visibility = Visibility.Collapsed;
        }

        private void AddFlightButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddFlightPage());
        }

        private void AddPassengerButonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new AddPassengerPage());
        }

        private void FlightsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedFlight = Convert.ToInt32(FlightsComboBox.SelectedValue);
            PriceTextBlock.Text = Convert.ToString(Math.Round(db.context.Flights.Where(x => x.IdFlight == selectedFlight).FirstOrDefault().Price, 2));
            СurrencyTextBlock.Visibility = Visibility.Visible;
        }

        private void PassengersComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SellTicketButtonClick(object sender, RoutedEventArgs e)
        {
            TicketMethods tm = new TicketMethods();
            TicketsViewModel tvm = new TicketsViewModel();

            List<Ticket> ticketsList = db.context.Ticket.ToList();
            List<string> ticketNumbersList = new List<string>();

            foreach (Ticket item in ticketsList)
            {
                ticketNumbersList.Add(item.TicketNumber);
            }
            if (
                FlightsComboBox.Text != String.Empty
                && PassengersComboBox.Text != String.Empty

                && !String.IsNullOrWhiteSpace(FlightsComboBox.Text)
                && !String.IsNullOrWhiteSpace(PassengersComboBox.Text)
                )
            {
                if (tvm.SellTicket(Convert.ToInt32(FlightsComboBox.SelectedValue),
                                    Convert.ToInt32(PassengersComboBox.SelectedValue),
                                    tm.TicketNumberGenerate(ticketNumbersList.Last()),
                                    DateTime.Now))
                {
                    MessageBox.Show("Билет успешно продан",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("На данный рейс не осталось свободных мест");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }
    }
}
