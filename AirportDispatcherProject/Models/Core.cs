using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherProject.Models
{
    public class Core
    {
        public AirportDbEntities context = new AirportDbEntities();
        //public MySqlConnection connection = new MySqlConnection("нету");

        //public MySqlConnection GetConnection()
        //{
        //    return connection;
        //}
    }
}
