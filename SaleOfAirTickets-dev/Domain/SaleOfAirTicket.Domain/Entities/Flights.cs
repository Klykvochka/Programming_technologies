using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTicket.Domain.Entities;
public class Flights : Entity<Guid>
{
    //public Moderator Moderator { get; }
    public Airlines Airline { get; }
    public Airports DepartureAirport { get; private set; }
    public Airports ArrivalAirport { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime ArrivalTime { get; private set; }
    public CountSeats CountSeats { get;}

    private readonly ICollection<Seats> _seats = [];
    public IReadOnlyCollection<Seats> Seats => _seats.ToList().AsReadOnly();

    protected Flights()
    {

    }
    protected Flights(Guid id, 
        Airlines airline,
        Airports departureAirport, 
        Airports arrivalAirport,
        DateTime departureTime, 
        DateTime arrivalTime,
        CountSeats countSeats) 
        : base(id)
    {
        if (arrivalAirport == departureAirport)
            throw new TheFlightIsFlyingToTheSameAirportException(this, arrivalAirport, departureAirport);
        if (arrivalTime <= departureTime)
            throw new InvalidFlightTimeException(this, arrivalTime, departureTime);
        Airline = airline ?? throw new ArgumentNullValueException(nameof(airline));
        ArrivalAirport = arrivalAirport ?? throw new ArgumentNullValueException(nameof(arrivalAirport));
        DepartureAirport = departureAirport ?? throw new ArgumentNullValueException(nameof(departureAirport));
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        CountSeats = countSeats ?? throw new ArgumentNullValueException(nameof(countSeats));

    }

    public Flights(
        Airlines airline,
        Airports departureAirport, 
        Airports arrivalAirport, 
        DateTime departureTime, 
        DateTime arrivalTime,
        CountSeats countSeats)
        : this(Guid.NewGuid(), airline, departureAirport, arrivalAirport, departureTime, arrivalTime, countSeats)
    {

    }
    public void InitializeSeats(Airlines airline, IReadOnlyCollection<Tariffs> tariffs)
    {
        if (Airline != airline)
            throw new AnotherAirlineInitializeSeatsException(this, airline);
        int tariffCount = tariffs.Count;

        for (int i = 1; i <= CountSeats.Value; i++)
        {
            var seatNumber = new SeatNumber(i);
            var tariff = tariffs.ElementAt((i - 1) % tariffCount);
            _seats.Add(new Seats(Airline, this, tariff, seatNumber));
        }
    }
    public IReadOnlyCollection<Seats> GetAvailableSeats()
    {
        return _seats.Where(s => s.Free).ToList() ?? throw new ThereAreNoEmptySeatsException(this);
    }

    public IReadOnlyCollection<Seats> GetAvailableSeatsToTheTariff(Name TariffName)
    {
        return this.GetAvailableSeats().Where(s => s.Tariff.Name == TariffName).ToList() ?? throw new ThereAreNoEmptySeatsException(this);
    }
    public bool ItSeatIsFree(SeatNumber seatNumber)
    {
        return _seats.Any(s => s.SeatNumber == seatNumber);
    }
    public bool ThereAreFreeSeats()
    {
        return _seats.Any(s => s.Free);
    }

    public bool BookSeat(Seats seat)
    {
        if (!_seats.Contains(seat))
            throw new TheSeatIsNotPartOfThisFlightException(this, seat);

        if (!seat.Free)
            return false;
        seat.TakeTheSeat();
        return true;
    }

    public void FreeSeat(Seats seat)
    {
        if (!_seats.Contains(seat))
            throw new TheSeatIsNotPartOfThisFlightException(this, seat);

        if (seat.Free)
            throw new SeatAlreadyFreeException(seat);
        seat.FreeTheSeat();
    }
}

