using SaleOfAirTicket.Domain.ValueObjects.Exeptions;
using static SaleOfAirTicket.Domain.ValueObjects.Base.IValidator;

namespace SaleOfAirTicket.Domain.ValueObjects.Validators;

public class CountSeatsValidator : IValidator<int>
{

    public void Validate(int value)
    {
        if (value <= 0)
            throw new CountSeatsNonPositiveException(ExceptionMessages.COUNT_SEATS_NON_POSITIVE, nameof(value), value);
    }

}

