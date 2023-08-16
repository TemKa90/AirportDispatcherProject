using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportDispatcherLibrary
{
    public class FlightMethods
    {
        /// <summary>
        ///     Расчёт номера следующего рейса
        /// </summary>
        /// <param name="flightNumber">     Номер предыдущего существующего рейса</param>
        /// <returns>   Номер следующего рейса</returns>
        public string FlightNumberGenerate(string flightNumber)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lettersArr = new string(flightNumber.Where(Char.IsLetter).ToArray()).ToCharArray();

            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] digitsArr = new string(flightNumber.Where(Char.IsDigit).ToArray()).ToCharArray();

            int d0 = Array.IndexOf(digits, digitsArr[0]);
            int d1 = Array.IndexOf(digits, digitsArr[1]);
            int d2 = Array.IndexOf(digits, digitsArr[2]);

            int l0 = Array.IndexOf(alphabet, lettersArr[0]);
            int l1 = Array.IndexOf(alphabet, lettersArr[1]);
            int l2 = Array.IndexOf(alphabet, lettersArr[2]);

            if (digitsArr[2] == digits[9])
            {
                if (digitsArr[1] == digits[9])
                {
                    if (digitsArr[0] == digits[9])
                    {
                        if (lettersArr[2] == alphabet[25])
                        {
                            if (lettersArr[1] == alphabet[25])
                            {
                                d0 = 0;
                                d1 = 0;
                                d2 = 0;
                                digitsArr[0] = digits[d0];
                                digitsArr[1] = digits[d1];
                                digitsArr[2] = digits[d2];

                                l0 += 1;
                                l1 = 0;
                                l2 = 0;
                                lettersArr[0] = alphabet[l0];
                                lettersArr[1] = alphabet[l1];
                                lettersArr[2] = alphabet[l2];
                            }
                            else
                            {
                                d0 = 0;
                                d1 = 0;
                                d2 = 0;
                                digitsArr[0] = digits[d0];
                                digitsArr[1] = digits[d1];
                                digitsArr[2] = digits[d2];

                                l1 += 1;
                                l2 = 0;
                                lettersArr[1] = alphabet[l1];
                                lettersArr[2] = alphabet[l2];
                            }
                        }
                        else
                        {
                            d0 = 0;
                            d1 = 0;
                            d2 = 0;
                            digitsArr[0] = digits[d0];
                            digitsArr[1] = digits[d1];
                            digitsArr[2] = digits[d2];

                            l2 += 1;
                            lettersArr[2] = alphabet[l2];
                        }
                    }
                    else
                    {
                        d0 += 1;
                        d1 = 0;
                        d2 = 0;
                        digitsArr[0] = digits[d0];
                        digitsArr[1] = digits[d1];
                        digitsArr[2] = digits[d2];
                    }
                }
                else
                {
                    d1 += 1;
                    d2 = 0;
                    digitsArr[1] = digits[d1];
                    digitsArr[2] = digits[d2];
                }
            }
            else
            {
                d2 += 1;
                digitsArr[2] = digits[d2];
            }

            return new string(lettersArr) + "-" + new string(digitsArr);
        }
    }
}
