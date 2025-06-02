

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class NameShortValueException(string name, int minLength)
    : FormatException($"Name длина {name} короче чем минимальная длина {minLength}")
    {
        public string Name => name;
        public int MinLength => minLength;
    }
