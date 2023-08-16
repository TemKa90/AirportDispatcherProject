using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherProject.Models
{
    public partial class Flights
    {
        public string FlightData
        {
            get { return PointOfDeparture.Name + " - " + PointOfArrival.Name + "/ Свободные места: " + FreeSeatsCount; }
        }
        //public string FlightDateTime
        //{
        //    get { return Date + " " + Time; }
        //}
    }
}
