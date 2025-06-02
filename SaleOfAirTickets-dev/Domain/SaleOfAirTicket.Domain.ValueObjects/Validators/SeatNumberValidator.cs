using SaleOfAirTicket.Domain.ValueObjects.Exeptions;
using static SaleOfAirTicket.Domain.ValueObjects.Base.IValidator;

namespace SaleOfAirTicket.Domain.ValueObjects.Validators;

public class SeatNumberValidator : IValidator<int>
{

    public void Validate(int value)
    {
        if (value <= 0)
            throw new SeatNumberNonPositiveException(ExceptionMessages.SEAT_NUMBER_NON_POSITIVE, nameof(value), value);
    }

}