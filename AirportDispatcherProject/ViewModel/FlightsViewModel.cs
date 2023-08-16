using AirportDispatcherLibrary;
using AirportDispatcherProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirportDispatcherProject.ViewModel
{
    class FlightsViewModel
    {
        Core db = new Core();
        FlightMethods fm = new FlightMethods();

        public bool AddFlight(int airplaneId, int companyId, DateTime dateOfDeparture, TimeSpan timeOfDeparture, int deparureAirportId, int arrivalAirportId)
        {
            Flights newFlight = new Flights()
            {
                AirplaneId = airplaneId,
                FlightNumber = fm.FlightNumberGenerate(db.context.Flights.ToList().Last().FlightNumber),
                CompanyName = companyId,
                CompanyCode = companyId,
                DateOfDeparture = dateOfDeparture,
                TimeOfDeparture = timeOfDeparture,
                PointOfDepartureId = deparureAirportId,
                PointOfArrivalId = arrivalAirportId,
                FreeSeatsCount = db.context.Airplane.Where(x => x.IdAirplane == airplaneId).FirstOrDefault().SeatsCount
            };

            db.context.Flights.Add(newFlight);
            db.context.SaveChanges();

            return true;
        }

        ///// <summary>
        /////     Проверка, существует ли запись о пассажире с такими паспортными данными в БД
        ///// </summary>
        ///// <param name="passportNumber">   Номер паспорта</param>
        ///// <returns>
        /////     true - не существует
        /////     false - существует
        ///// </returns>
        //public bool PassengerDbCheck(string passportNumber)
        //{
        //    //MySqlCommand command = new MySqlCommand("SELECT * FROM Passengers WHERE PassportNumber = @passportNumber", db.GetConnection());
        //    //command.Parameters.AddWithValue("passportNumber", passportNumber);
        //    //db.GetConnection().Open();
        //    //return 1 == command.ExecuteNonQuery();

        //    List<Passenger> tableList = db.context.Passenger.ToList();
        //    List<string> passengersList = new List<string>();

        //    foreach (Passenger item in tableList)
        //    {
        //        if (item.PassportNumber == passportNumber)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        ///         Редактирование существующих данных о рейсе в БД
        /// </summary>
        /// <param name="companyName">          Название компании</param>
        /// <param name="dateTimeOfDeparture">  Дата и время отправки</param>
        /// <param name="dateTimeOfArrival">    Дата и время прибытия</param>
        /// <param name="departureAirportId">   ID аэропорта отправки</param>
        /// <param name="arrivalAirportId">     ID аэропорта прибытия</param>
        /// <param name="airplaneId">           ID самолёта</param>
        /// <returns> true - данные отредактированы</returns>
        public bool EditFlight(int companyNameId, DateTime dateOfDeparture, TimeSpan timeOfDeparture, int departureAirportId, int arrivalAirportId, int airplaneId)
        {
            Flights newFlight = new Flights
            {
                CompanyName = companyNameId,
                DateOfDeparture = dateOfDeparture,
                TimeOfDeparture = timeOfDeparture,
                PointOfDepartureId = departureAirportId,
                PointOfArrivalId = arrivalAirportId,
                AirplaneId = airplaneId
            };

            int selectedFlightId = Convert.ToInt32(Application.Current.Resources["selectedFlightId"]);
            Flights selectedFlight = db.context.Flights.Where(x => x.IdFlight == selectedFlightId).FirstOrDefault();

            selectedFlight.CompanyName = newFlight.CompanyName;
            selectedFlight.DateOfDeparture = newFlight.DateOfDeparture;
            selectedFlight.TimeOfDeparture = newFlight.TimeOfDeparture;
            selectedFlight.PointOfArrivalId = newFlight.PointOfArrivalId;
            selectedFlight.AirplaneId = newFlight.AirplaneId;

            db.context.SaveChanges();

            return true;
        }
    }
}
