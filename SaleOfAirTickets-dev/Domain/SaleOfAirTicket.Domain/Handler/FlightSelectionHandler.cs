using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Exceptions;

namespace SaleOfAirTicket.Domain.Handler;
internal class FlightSelectionHandler : BookingHandler
{
    private readonly IReadOnlyCollection<Flights> _availableFlights;

    public FlightSelectionHandler(IReadOnlyCollection<Flights> availableFlights)
    {
        _availableFlights = availableFlights ?? throw new ArgumentNullException(nameof(availableFlights));
    }
    public override void Handle(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));

        var matchingFlights = _availableFlights
            .Where(flight => flight.DepartureAirport.City == record.DepartureCity &&
                             flight.ArrivalAirport.City == record.ArrivalCity &&
                             flight.DepartureTime.Date == record.Date.Date &&
                             flight.ThereAreFreeSeats())
            .ToList();

        if (matchingFlights.Any())
        {
            record.Flight = matchingFlights.FirstOrDefault();
            NextHandler?.Handle(record);
        }
        else
            throw new ThereAreNoAvailableFlightsException();

    }
}

