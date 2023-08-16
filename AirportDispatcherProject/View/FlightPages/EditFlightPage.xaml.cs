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
    /// Логика взаимодействия для EditFlightPage.xaml
    /// </summary>
    public partial class EditFlightPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public EditFlightPage()
        {
            InitializeComponent();

            CompanyComboBox.ItemsSource = db.context.Companies.OrderBy(x => x.CompanyName)
            .ToList();
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

        private void EditPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            FlightsViewModel fvm = new FlightsViewModel();
            if (
                CompanyComboBox.Text != String.Empty
                && DateOfDepartureDatePicker.Text != String.Empty
                && DepartureAirportComboBox.Text != String.Empty
                && TimeOfDepartureTextBox.Text != String.Empty
                && ArrivalAirportComboBox.Text != String.Empty
                && AirplaneComboBox.Text != String.Empty

                && !String.IsNullOrWhiteSpace(CompanyComboBox.Text)
                && !String.IsNullOrWhiteSpace(DateOfDepartureDatePicker.Text)
                && !String.IsNullOrWhiteSpace(TimeOfDepartureTextBox.Text)
                && !String.IsNullOrWhiteSpace(DepartureAirportComboBox.Text)
                && !String.IsNullOrWhiteSpace(ArrivalAirportComboBox.Text)
                && !String.IsNullOrWhiteSpace(AirplaneComboBox.Text)
                )
            {
                try
                {
                    if (fvm.EditFlight(Convert.ToInt32(CompanyComboBox.Text), Convert.ToDateTime(DateOfDepartureDatePicker.Text),
                    TimeSpan.Parse(TimeOfDepartureTextBox.Text), Convert.ToInt32(DepartureAirportComboBox.Text),
                    Convert.ToInt32(ArrivalAirportComboBox.Text), Convert.ToInt32(AirplaneComboBox.Text)))
                    {
                        MessageBox.Show("Данные обновлены",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                        mw.EditFrame.NavigationService.GoBack();
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Что-то пошло не так. Пожалуйста, перепроверьте введённые данные.", 
                        "Упс!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
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
