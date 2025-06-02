
namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;

    internal class FirstNameShortValueException(string firstName, int minLength)
        : FormatException($"FirstName длина {firstName} короче чем минимальная длина {minLength}")
    {
        public string FirstName => firstName;
        public int MinLength => minLength;
    }
