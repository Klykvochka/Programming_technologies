

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class PassportShortValueException(string passport, int minLength)
        : FormatException($"Passport длина {passport} короче чем минимальная длина {minLength}")
    {
        public string Passport => passport;
        public int MinLength => minLength;
    }
