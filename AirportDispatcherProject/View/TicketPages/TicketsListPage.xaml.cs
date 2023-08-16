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
using AirportDispatcherProject.View.TicketPages;
using AirportDispatcherProject.ViewModel;

namespace AirportDispatcherProject.View
{
    /// <summary>
    /// Логика взаимодействия для FlightListPage.xaml
    /// </summary>
    public partial class TicketsListPage : Page
    {
        Core db = new Core();
        List<Ticket> elementsList = new List<Ticket>();
        MainWindow mw = Application.Current.MainWindow as MainWindow;
        TicketsViewModel tvm = new TicketsViewModel();

        public TicketsListPage()
        {
            InitializeComponent();
            TicketListView.ItemsSource = db.context.Ticket.ToList();
        }

        private void ShowTable()
        {
            List<Ticket> arrayTickets = db.context.Ticket.ToList();

            if (SelectComboBox.SelectedIndex == 1)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayTickets = arrayTickets.Where(x => x.TicketNumber.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                TicketListView.ItemsSource = arrayTickets;
            }

            if (SelectComboBox.SelectedIndex == 2)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayTickets = arrayTickets.Where(x => x.Passenger.FullName.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                TicketListView.ItemsSource = arrayTickets;
            }

            if (SelectComboBox.SelectedIndex == 3)
            {
                if (!String.IsNullOrEmpty(SeacrhTextBox.Text))
                {
                    arrayTickets = arrayTickets.Where(x => x.Flights.Companies.CompanyName.ToLower().Contains(SeacrhTextBox.Text.ToLower())).ToList();
                }
                TicketListView.ItemsSource = arrayTickets;
            }
        }

        private void SeacrhTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void SellTicketButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Navigate(new SellTicketPage());
        }

        private void DellCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Ticket item = activeCheckBox.DataContext as Ticket;

            elementsList.Add(item);
        }

        private void DellCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox activeCheckBox = (CheckBox)sender;
            Ticket item = activeCheckBox.DataContext as Ticket;

            elementsList.Remove(item);
        }

        private void DellTicketButtonClick(object sender, RoutedEventArgs e)
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
                        db.context.Ticket.Remove(item);
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

            TicketListView.ItemsSource = db.context.Ticket.ToList();
            elementsList.Clear();
        }

        private void TicketListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ticket selectedTicket = TicketListView.SelectedItem as Ticket;

            Application.Current.Resources["selectedTicket"] = selectedTicket;

            Application.Current.Resources["selectedTicketId"] = selectedTicket.IdTicket;
            Application.Current.Resources["selectedTicketFlight"] = selectedTicket.Flight;
            Application.Current.Resources["selectedTicketPassenger"] = selectedTicket.PassengerName;
            Application.Current.Resources["selectedTicketNumber"] = selectedTicket.TicketNumber;
            Application.Current.Resources["selectedTicketBookingDateTime"] = selectedTicket.BookingDateTime;

            mw.EditFrame.Navigate(new TicketInfoPage());
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainMenuPage());
            mw.EditFrame.Content = null;
        }

        private void ReloadButtonClick(object sender, RoutedEventArgs e)
        {
            TicketListView.ItemsSource = db.context.Ticket.ToList();
        }
    }
}
