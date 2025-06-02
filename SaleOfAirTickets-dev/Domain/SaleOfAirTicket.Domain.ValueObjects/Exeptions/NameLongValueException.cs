
namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class NameLongValueException(string name, int maxLength)
        : FormatException($"Name длина {name} больше максимально допустимой длины {maxLength}")
    {
        public string Name => name;
        public int MaxLength => maxLength;
    }
