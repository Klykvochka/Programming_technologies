

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class PassportLongValueException(string passport, int maxLength)
        : FormatException($"Passport длина {passport} больше максимально допустимой длины {maxLength}")
    {
        public string Passport => passport;
        public int MaxLength => maxLength;
    }

