using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class CheckStringClass
    {
        /// <summary>
        ///     Проверка входных данных на соответствие условиям
        /// </summary>
        /// <param name="login">
        ///     Логин пользователя
        /// </param>
        /// <returns>   
        ///     true - в случае соответствия
        ///     исключение - в случае несоответсвия
        ///</returns>
        public bool LoginCheck(string login)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz0123456789-_.";
            login = login.ToLower();
            if (!login.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Логин содержит недопустимые символы");
            }
            if (login == String.Empty)
            {
                throw new Exception("Вы не ввели логин");
            }
            if (login.EndsWith("."))
            {
                throw new Exception("Логин не может заканчиваться символом '.'");
            }
            return true;
        }

        /// <summary>
        ///     Проверка входных данных на соответствие условиям
        /// </summary>
        /// <param name="password">
        ///     Пароль пользователя
        /// </param>
        /// <returns>   
        ///     true - в случае соответствия
        ///     исключение - в случае несоответсвия
        ///</returns>
        public bool PasswordCheck(string password)
        {
            string correctSymbols = "abcdefghijklmnopqrstuvwxyz0123456789-_.";
            password = password.ToLower();
            if (!password.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Пароль содержит недопустимые символы");
            }
            if (password == String.Empty)
            {
                throw new Exception("Вы не ввели пароль");
            }
            return true;
        }
    }
}
