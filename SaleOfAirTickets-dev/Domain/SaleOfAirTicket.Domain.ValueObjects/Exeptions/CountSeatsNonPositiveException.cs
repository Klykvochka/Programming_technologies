namespace SaleOfAirTicket.Domain.ValueObjects.Exeptions;
internal class CountSeatsNonPositiveException(string message, string paramName, decimal value)
        : ArgumentException(message, paramName)
{
    public decimal Value => value;
}

