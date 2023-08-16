using AirportDispatcherProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherProject.ViewModel
{
    public class TicketsViewModel
    {
        Core db = new Core();

        /// <summary>
        ///     Продажа билета выбранному пассажиру на выбранный рейс
        /// </summary>
        /// <param name="flight">           Id рейса</param>
        /// <param name="passengerName">    Id пассажира</param>
        /// <param name="ticketNumber">     Номер предыдущего билета</param>
        /// <param name="bookingDateTime">  Дата бронирования билета</param>
        /// <returns>   true - успешная продажа билета</returns>
        public bool SellTicket(int flight, int passengerName, string ticketNumber, DateTime bookingDateTime)
        {
            Flights selectedFlight = db.context.Flights.Where(x => x.IdFlight == flight).FirstOrDefault();
            if (selectedFlight.FreeSeatsCount > 0)
            {
                Ticket newTicket = new Ticket()
                {
                    Flight = flight,
                    PassengerName = passengerName,
                    TicketNumber = ticketNumber,
                    BookingDateTime = bookingDateTime
                };

                selectedFlight.FreeSeatsCount -= 1;

                db.context.Ticket.Add(newTicket);
                db.context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        ///// <summary>
        /////     Проверка, существует ли запись о билете с таким номером в БД
        ///// </summary>
        ///// <param name="ticketNumber">   Номер билета</param>
        ///// <returns>
        /////     true - не существует
        /////     false - существует
        ///// </returns>
        //public bool TicketDbCheck(string ticketNumber)
        //{
        //    List<Ticket> tableList = db.context.Ticket.ToList();
        //    List<string> ticketNumList = new List<string>();

        //    foreach (Ticket item in tableList)
        //    {
        //        if (item.TicketNumber == ticketNumber)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}