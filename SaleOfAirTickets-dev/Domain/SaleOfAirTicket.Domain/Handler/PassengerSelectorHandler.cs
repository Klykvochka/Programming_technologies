using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Exceptions;


namespace SaleOfAirTicket.Domain.Handler;
internal class PassengerSelectorHandler : BookingHandler
{
    private readonly IReadOnlyCollection<Passengers> _passengers;

    public PassengerSelectorHandler(List<Passengers> passengers)
    {
        _passengers = passengers ?? throw new ArgumentNullException(nameof(passengers));
    }
    public override void Handle(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));


        if (record.Flight == null)
            throw new ThereAreNoAvailableFlightsException();


        if (record.Tariff == null)
            throw new TariffNotSpecifiedException();

        if (record.Seat == null)
            throw new SeatNotSelectedException();

        Passengers? Passenger = _passengers
            .FirstOrDefault(p => p.FirstName == record.PassangerFirstName && p.LastName == record.PassangerLastName);

        if (Passenger != null)
            record.Passenger = Passenger;

        else
            throw new ThereAreNoThisPassengerException();

    }
}
