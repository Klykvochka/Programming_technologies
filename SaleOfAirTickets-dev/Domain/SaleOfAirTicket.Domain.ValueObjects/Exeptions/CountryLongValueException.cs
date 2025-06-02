

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class CountryLongValueException(string country, int maxLength)
        : FormatException($"Country длина {country} больше максимально допустимой длины {maxLength}")
    {
        public string Country => country;
        public int MaxLength => maxLength;
    }

