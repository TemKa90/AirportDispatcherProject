using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherProject.Models
{
    public partial class Passenger
    {
        public string FullName
        {
            get { return  SecondName + " " + FirstName + " " + PatronymicName; }
        }
    }
}
