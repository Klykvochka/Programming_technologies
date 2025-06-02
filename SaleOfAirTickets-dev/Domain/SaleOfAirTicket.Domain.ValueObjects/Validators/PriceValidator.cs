using SaleOfAirTicket.Domain.ValueObjects.Exeptions;
using static SaleOfAirTicket.Domain.ValueObjects.Base.IValidator;

namespace SaleOfAirTicket.Domain.ValueObjects.Validators;

public class PriceValidator : IValidator<decimal>
{

    public void Validate(decimal value)
    {
        if (value <= 0)
            throw new PriceNonPositiveException(ExceptionMessages.PRICE_NON_POSITIVE, nameof(value), value);
        if (!IsValidPrice(value))
            throw new PriceHasMoreThanTwoDecimalPlacesException(ExceptionMessages.PRICE_HAS_NOT_MORE_THEN_TWO_DECIMAL_PLACES, nameof(value), value);
    }

    private bool IsValidPrice(decimal value)
    {
        value = value * 100;
        value -= (int)value;
        return value == 0m;
    }
}