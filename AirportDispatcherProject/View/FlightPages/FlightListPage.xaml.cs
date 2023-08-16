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
using AirportDispatcherProject.View.FlightPages;

namespace AirportDispatcherProject.View
{
    /// <summary>
    /// Логика взаимодействия для FlightListPage.xaml
    /// </summary>
    public partial class FlightListPage : Page
    {
        public FlightListPage()
        {
            InitializeComponent();
        }

        private void AddFlightButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddFlightPage());
        }
        private void EditFlightButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditFlightPage());
        }

        private void AddTicketButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SelectComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
