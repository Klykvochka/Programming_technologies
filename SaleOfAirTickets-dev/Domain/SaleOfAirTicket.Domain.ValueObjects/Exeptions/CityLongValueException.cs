

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class CityLongValueException(string city, int maxLength)
        : FormatException($"City длина {city} больше максимально допустимой длины {maxLength}")
    {
        public string City => city;
        public int MaxLength => maxLength;
    }