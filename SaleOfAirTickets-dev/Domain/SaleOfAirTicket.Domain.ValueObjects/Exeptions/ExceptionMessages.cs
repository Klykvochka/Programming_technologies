using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions
{
    /// <summary>
    /// Предоставляет строковые константы для сообщений об ошибках.
    /// </summary>
    internal static class ExceptionMessages
    {
        public const string VALIDATOR_MUST_BE_SPECIFIED = "Для типа должен быть указан валидатор";
        public const string CITY_NOT_NULL_OR_WHITE_SPACE = "City не должн быть пустым или состоять только из пробелов";
        public const string COUNTRY_NOT_NULL_OR_WHITE_SPACE = "Country не должн быть пустым или состоять только из пробелов";
        public const string EMAIL_NOT_NULL_OR_WHITE_SPACE = "Email не должн быть пустым или состоять только из пробелов";
        public const string FIRST_NAME_NOT_NULL_OR_WHITE_SPACE = "FirstName не должн быть пустым или состоять только из пробелов";
        public const string LAST_NAME_NOT_NULL_OR_WHITE_SPACE = "LastName не должн быть пустым или состоять только из пробелов";
        public const string PASSPORT_NOT_NULL_OR_WHITE_SPACE = "Passport не должн быть пустым или состоять только из пробелов";
        public const string PHONE_NUMBER_NOT_NULL_OR_WHITE_SPACE = "PhoneNumber не должн быть пустым или состоять только из пробелов";
        public const string NAME_NOT_NULL_OR_WHITE_SPACE = "Name не должн быть пустым или состоять только из пробелов";
        public const string PRICE_NON_POSITIVE = "Цена не должна быть отрицательной";
        public const string SEAT_NUMBER_NON_POSITIVE = "SeatNumber не должен быть отрицательным";
        public const string COUNT_SEATS_NON_POSITIVE = "CountSeats не должен быть отрицательным";
        public const string PRICE_HAS_NOT_MORE_THEN_TWO_DECIMAL_PLACES = "Цена имеет не более двух знаков после запятой";
    }
}
