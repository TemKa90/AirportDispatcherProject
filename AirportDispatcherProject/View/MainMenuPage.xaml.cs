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

namespace AirportDispatcherProject.View
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        Core db = new Core();
        MainWindow mw = Application.Current.MainWindow as MainWindow;

        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void TicketsPageButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TicketsListPage());
        }

        private void FlightsPageButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FlightsListPage());
        }

        private void PassengersPageButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PassengersListPage());
        }
    }
}
