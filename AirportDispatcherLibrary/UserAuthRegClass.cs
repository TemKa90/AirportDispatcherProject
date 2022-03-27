using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class UserAuthRegClass
    {
        public bool UserAuth(string login, string password)
        {
            bool result;
            if (
                login != String.Empty
                && password != String.Empty
                && !String.IsNullOrWhiteSpace(login)
                && !String.IsNullOrWhiteSpace(password)
                )
            {
                //проверка присутствия данных о клиенте в БД
                int countRecord = arrayClients
                 .Where(x => x.Login == login && x.Password == password)
                 .Count();
                if (countRecord == 1)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
                //Добавить MessageBox.Show("Не введен логин или пароль");
            }
            return result;
        }

        public bool UserReg(int flightNumber, string companyName, DateTime departureDateTime, int seatsCount)
        {
            bool result;
            return result;
        }
    }
}
