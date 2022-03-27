using AirportDispatcherProject.View.TicketPages;
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
    /// Логика взаимодействия для TicketListPage.xaml
    /// </summary>
    public partial class TicketListPage : Page
    {
        public TicketListPage()
        {
            InitializeComponent();
        }

        private void AddTicketButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddTicketPage());
        }
    }
}
