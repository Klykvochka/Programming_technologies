
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;
namespace SaleOfAirTicket.Domain.Handler;
internal class SeatSelectionHandler : BookingHandler
{
    private readonly SeatNumber _seatNumber;

    public SeatSelectionHandler(SeatNumber seatNumber)
    {
        _seatNumber = seatNumber ?? throw new ArgumentNullException(nameof(seatNumber));
    }
    public override void Handle(Record record)
    {
        if (record == null)
            throw new ArgumentNullException(nameof(record));

        if (record.Flight == null)
            throw new ThereAreNoAvailableFlightsException();

        if (record.Tariff == null)
            throw new TariffNotSpecifiedException();

        if (!record.Flight.ItSeatIsFree(_seatNumber))
            throw new InvalidSeatNumberException(_seatNumber, record.Flight);

        Seats? selectedSeat = record.Flight.GetAvailableSeats()
            .FirstOrDefault(s => (s.SeatNumber == _seatNumber) && (s.Tariff.Name == record.Tariff.Name));

        if (selectedSeat != null && selectedSeat.IsAvailable)
        {
            record.Seat = selectedSeat;
            NextHandler?.Handle(record);
        }

        else
        {
            throw new ThereAreNoEmptySeatsException(record.Flight);
        }

    }
}
