

namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
    internal class PriceNonPositiveException(string message, string paramName, decimal value)
            : ArgumentException(message, paramName)
    {
        public decimal Value => value;
    }
