

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class FirstNameLongValueException(string firstName, int maxLength)
        : FormatException($"FirstName длина {firstName} больше максимально допустимой длины {maxLength}")
    {
        public string Firstname => firstName;
        public int MaxLength => maxLength;
    }
