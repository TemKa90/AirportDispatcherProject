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

namespace AirportDispatcherProject.View.FlightPages
{
    /// <summary>
    /// Логика взаимодействия для AddFlightPage.xaml
    /// </summary>
    public partial class AddFlightPage : Page
    {
        Core db = new Core();
        FlightsListPage flp = new FlightsListPage();

        public AddFlightPage()
        {
            InitializeComponent();

            CompanyComboBox.ItemsSource = db.context.Companies.OrderBy(x => x.CompanyName).ToList();
            CompanyComboBox.DisplayMemberPath = "CompanyName";
            CompanyComboBox.SelectedValuePath = "IdCompany";

            DepartureAirportComboBox.ItemsSource = db.context.PointOfDeparture.OrderBy(x => x.Name).ToList();
            DepartureAirportComboBox.DisplayMemberPath = "Name";
            DepartureAirportComboBox.SelectedValuePath = "IdAirport";

            ArrivalAirportComboBox.ItemsSource = db.context.PointOfArrival.OrderBy(x => x.Name).ToList();
            ArrivalAirportComboBox.DisplayMemberPath = "Name";
            ArrivalAirportComboBox.SelectedValuePath = "IdAirport";

            AirplaneComboBox.ItemsSource = db.context.Airplane.OrderBy(x => x.Name).ToList();
            AirplaneComboBox.DisplayMemberPath = "Name";
            AirplaneComboBox.SelectedValuePath = "IdAirplane";
        }

        private void AddFlightButtonClick(object sender, RoutedEventArgs e)
        {
            FlightsViewModel fvm = new FlightsViewModel();

            if (
                AirplaneComboBox.Text != String.Empty
                && CompanyComboBox.Text != String.Empty
                && DateOfDepartureDatePicker.Text != String.Empty
                && TimeOfDepartureTextBox.Text != String.Empty
                && DepartureAirportComboBox.Text != String.Empty
                && ArrivalAirportComboBox.Text != String.Empty

                && !String.IsNullOrWhiteSpace(AirplaneComboBox.Text)
                && !String.IsNullOrWhiteSpace(CompanyComboBox.Text)
                && !String.IsNullOrWhiteSpace(DateOfDepartureDatePicker.Text)
                && !String.IsNullOrWhiteSpace(TimeOfDepartureTextBox.Text)
                && !String.IsNullOrWhiteSpace(DepartureAirportComboBox.Text)
                && !String.IsNullOrWhiteSpace(ArrivalAirportComboBox.Text)
                )
            {
                if (fvm.AddFlight(Convert.ToInt32(AirplaneComboBox.SelectedValue), Convert.ToInt32(CompanyComboBox.SelectedValue), 
                                    Convert.ToDateTime(DateOfDepartureDatePicker.SelectedDate), TimeSpan.Parse(TimeOfDepartureTextBox.Text),
                                    Convert.ToInt32(DepartureAirportComboBox.SelectedValue), Convert.ToInt32(ArrivalAirportComboBox.SelectedValue))
                    )
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
    }
}
