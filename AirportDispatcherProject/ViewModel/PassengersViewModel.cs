using AirportDispatcherProject.Models;
using AirportDispatcherProject.View.PassengerPages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirportDispatcherProject.ViewModel
{
    class PassengersViewModel
    {
        Core db = new Core();

        /// <summary>
        ///     Добавление в БД записи о новом пассажире
        /// </summary>
        /// <param name="secondName">       Фамилия</param>
        /// <param name="firstName">        Имя</param>
        /// <param name="patronymicName">   Отчество</param>
        /// <param name="phoneNumber">      Номер телефона</param>
        /// <param name="address">          Адрес проживания</param>
        /// <param name="passportNumber">   Номер и серия паспорта</param>
        /// <param name="passportPlace">    Место выдачи паспорта</param>
        /// <returns> true - запись добавлена</returns>
        public bool AddPassenger(string secondName, string firstName, string patronymicName, string phoneNumber, string address, string passportNumber, string passportPlace)
        {
            Passenger newPassenger = new Passenger()
            {
                SecondName = secondName,
                FirstName = firstName,
                PatronymicName = patronymicName,
                PhoneNumber = phoneNumber,
                Address = address,
                PassportNumber = passportNumber,
                PlaseOfPassportIssue = passportPlace
            };

            db.context.Passenger.Add(newPassenger);
            db.context.SaveChanges();

            return true;
        }


        /// <summary>
        ///     Проверка, существует ли запись о пассажире с такими паспортными данными в БД
        /// </summary>
        /// <param name="passportNumber">   Номер паспорта</param>
        /// <returns>
        ///     true - не существует
        ///     false - существует
        /// </returns>
        public bool PassengerDbCheck(string passportNumber)
        {
            //MySqlCommand command = new MySqlCommand("SELECT * FROM Passengers WHERE PassportNumber = @passportNumber", db.GetConnection());
            //command.Parameters.AddWithValue("passportNumber", passportNumber);
            //db.GetConnection().Open();
            //return 1 == command.ExecuteNonQuery();

            List<Passenger> tableList = db.context.Passenger.ToList();
            List<string> passengersList = new List<string>();

            foreach (Passenger item in tableList)
            {
                if (item.PassportNumber == passportNumber)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        ///         Редактирование существующих данных о пассажире в БД
        /// </summary>
        /// <param name="secondName">       Фамилия</param>
        /// <param name="firstName">        Имя</param>
        /// <param name="patronymicName">   Отчество</param>
        /// <param name="phoneNumber">      Номер телефона</param>
        /// <param name="address">          Адрес проживания</param>
        /// <param name="passportNumber">   Номер и серия паспорта</param>
        /// <param name="passportPlace">    Место выдачи паспорта</param>
        /// <returns> true - данные отредактированы</returns>
        public bool EditPassenger(string secondName, string firstName, string patronymicName, string phoneNumber, string address, string passportNumber, string passportPlace)
        {
            Passenger newPassenger = new Passenger
            {
                SecondName = secondName,
                FirstName = firstName,
                PatronymicName = patronymicName,
                PhoneNumber = phoneNumber,
                Address = address,
                PassportNumber = passportNumber,
                PlaseOfPassportIssue = passportPlace
            };

            int selectedPassengerId = Convert.ToInt32(Application.Current.Resources["selectedPassengerId"]);
            Passenger selectedPassenger = db.context.Passenger.Where(x => x.IdPassenger == selectedPassengerId).FirstOrDefault();

            selectedPassenger.SecondName = newPassenger.SecondName;
            selectedPassenger.FirstName = newPassenger.FirstName;
            selectedPassenger.PatronymicName = newPassenger.PatronymicName;
            selectedPassenger.PhoneNumber = newPassenger.PhoneNumber;
            selectedPassenger.Address = newPassenger.Address;
            selectedPassenger.PassportNumber = newPassenger.PassportNumber;
            selectedPassenger.PlaseOfPassportIssue = newPassenger.PlaseOfPassportIssue;

            db.context.SaveChanges();

            return true;
        }
    }
}
