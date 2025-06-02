

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class EmailShortValueException(string email, int minLength)
    : FormatException($"Email длина {email} короче чем минимальная длина {minLength}")
    {
        public string Email => email;
        public int MinLength => minLength;
    }

