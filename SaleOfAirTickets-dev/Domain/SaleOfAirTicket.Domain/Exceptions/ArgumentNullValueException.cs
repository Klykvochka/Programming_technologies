using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTicket.Domain.Exceptions
{
    public class ArgumentNullValueException(string paramName)
        : ArgumentNullException(paramName, $"Argument \"{paramName}\" value is null");
}
