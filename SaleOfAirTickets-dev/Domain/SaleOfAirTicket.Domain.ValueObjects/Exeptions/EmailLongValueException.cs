

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class EmailLongValueException(string email, int maxLength)
        : FormatException($"Email длина {email} больше максимально допустимой длины {maxLength}")
    {
        public string Email => email;
        public int MaxLength => maxLength;
    }
