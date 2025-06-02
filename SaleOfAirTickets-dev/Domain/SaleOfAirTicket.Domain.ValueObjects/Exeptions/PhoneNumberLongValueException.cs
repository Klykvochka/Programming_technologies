

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class PhoneNumberLongValueException(string phoneNumber, int maxLength)
        : FormatException($"PhoneNumber длина {phoneNumber} больше максимально допустимой длины {maxLength}")
    {
        public string PhoneNumber => phoneNumber;
        public int MaxLength => maxLength;
    }

