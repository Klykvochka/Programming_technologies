

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class PhoneNumberShortValueException(string phoneNumber, int minLength)
    : FormatException($"PhoneNumber длина {phoneNumber} короче чем минимальная длина {minLength}")
    {
        public string PhoneNumber => phoneNumber;
        public int MinLength => minLength;
    }

