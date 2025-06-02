

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class CountryShortValueException(string country, int minLength)
    : FormatException($"Country длина {country} короче чем минимальная длина {minLength}")
    {
        public string Country => country;
        public int MinLength => minLength;
    }
