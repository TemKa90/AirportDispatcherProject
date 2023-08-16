using AirportDispatcherProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherProject.ViewModel
{
    public class UsersViewModel
    {
        Core db = new Core();

        /// <summary>
        ///     Выполнение авторизации
        /// </summary>
        /// <param name="login">    Логин</param>
        /// <param name="password">    Пароль</param>
        /// <returns>
        ///     true - авторизация прошла
        ///     false  - авторизация не прошла
        /// </returns>
        public bool UserAuth(string login, string password)
        {
            List<Users> arrayUsers = db.context.Users.ToList();
            Console.WriteLine("Метод работает");

            //проверка присутствия данных о клиенте в БД
            int countRecord = arrayUsers
                .Where(x => x.Login == login && x.Password == password)
                .Count();
            if (countRecord == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Занесение нового пользователя в БД
        /// </summary>
        /// <param name="login">    Логин</param>
        /// <param name="password">     Пароль</param>
        /// <returns>
        ///     true - регистрация прошла
        ///     false  - регистрация не прошла
        /// </returns>
        public bool UserReg(string login, string password)
        {
            Users newUser = new Users()
            {
                Login = login,
                Password = password
            };

            db.context.Users.Add(newUser);
            db.context.SaveChanges();

            return true;
        }
    }
}
