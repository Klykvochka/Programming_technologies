

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class LastNamelLongValueException(string lastName, int maxLength)
        : FormatException($"LastName длина {lastName} больше максимально допустимой длины {maxLength}")
    {
        public string LastName => lastName;
        public int MaxLength => maxLength;
    }
