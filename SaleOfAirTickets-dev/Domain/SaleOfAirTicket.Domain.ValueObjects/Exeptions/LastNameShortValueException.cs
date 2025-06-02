
namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class LastNameShortValueException(string lastName, int minLength)
    : FormatException($"LastName длина {lastName} короче чем минимальная длина {minLength}")
    {
        public string LastName => lastName;
        public int MinLength => minLength;
    }