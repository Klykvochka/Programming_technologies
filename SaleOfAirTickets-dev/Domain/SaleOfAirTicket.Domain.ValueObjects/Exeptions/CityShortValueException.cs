

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class CityShortValueException(string city, int minLength)
    : FormatException($"City длина {city} короче чем минимальная длина {minLength}")
    {
        public string City => city;
        public int MinLength => minLength;
    }
