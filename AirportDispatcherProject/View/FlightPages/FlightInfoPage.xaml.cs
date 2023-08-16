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

namespace AirportDispatcherProject.View.FlightPages
{
    /// <summary>
    /// Логика взаимодействия для FlightInfoPage.xaml
    /// </summary>
    public partial class FlightInfoPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;
        public FlightInfoPage()
        {
            InitializeComponent();

            FlightNumberTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedFlightNumber"]);
            CompanyNameTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedFlightCompanyName"]);
            DateOfDepartureTextBlock.Text = string.Format("{0:dd\\.MM\\.yyyy}", Application.Current.Resources["selectedFlightDateOfDeparture"]); //Выводит со временем
            TimeOfDepartureTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedFlightTimeOfDeparture"]);

            int pointOfDepartureId = Convert.ToInt32(Application.Current.Resources["selectedFlightPointOfDepartureId"]);
            PointOfDepartureTextBlock.Text = Convert.ToString(db.context.PointOfDeparture.Where(x => x.IdAirport == pointOfDepartureId).FirstOrDefault().Name);

            int pointOfArrivalId = Convert.ToInt32(Application.Current.Resources["selectedFlightPointOfArrivalId"]);
            PointOfArrivalTextBlock.Text = Convert.ToString(db.context.PointOfArrival.Where(x => x.IdAirport == pointOfArrivalId).FirstOrDefault().Name);

            int airplaneId = Convert.ToInt32(Application.Current.Resources["selectedFlightAirplaneId"]);
            AirplaneTextBlock.Text = Convert.ToString(db.context.Airplane.Where(x => x.IdAirplane == airplaneId).FirstOrDefault().Name);

            SeatsTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedFlightSeatsCount"]);
            FreeSeatsTextBlock.Text = Convert.ToString(Application.Current.Resources["selectedFlightFreeSeatsCount"]);
        }

        private void EditPassengerButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditFlightPage());
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            mw.EditFrame.Content = null;
        }
    }
}
