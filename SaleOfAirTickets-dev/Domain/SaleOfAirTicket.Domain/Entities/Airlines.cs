using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;


namespace SaleOfAirTicket.Domain.Entities;
public class Airlines : Entity<Guid>
{
    public Name Name { get; }
    public Country Country { get; }

    private readonly ICollection<Tariffs> _Tariffs = [];
    public IReadOnlyCollection<Tariffs> Tariffs => _Tariffs.ToList().AsReadOnly();

    private readonly ICollection<Flights> _flights = [];
    public IReadOnlyCollection<Flights> Flights => _flights.ToList().AsReadOnly();

    protected Airlines()
    {

    }
    protected Airlines(Guid id, Name name, Country country)
        : base(id)
    {

        
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        Country = country ?? throw new ArgumentNullValueException(nameof(country));

    }

    public Airlines(Name name, Country country)
        : this(Guid.NewGuid(), name, country)
    {

    }
    public void AddTariff(Tariffs tariff)
    {
        if (_Tariffs.Contains(tariff))
            return;

        _Tariffs.Add(tariff);
    }

    public Tariffs MakeTariff(Name name, Price price)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (price == null)
            throw new ArgumentNullException(nameof(price));

        var tariff = new Tariffs(this, name, price);

        if (_Tariffs.Contains(tariff))
            throw new TariffAlreadyExistException(tariff);

        _Tariffs.Add(tariff);
        return tariff;
    }

    public void AddFlight(Flights flight)
    {
        if (_flights.Contains(flight))
            return;

        _flights.Add(flight);
    }

    public Flights MakeFlight(Airports departureAirport, Airports arrivalAirport, DateTime departureTime, DateTime arrivalTime, CountSeats countSeats)
    {
        if (departureAirport == null)
            throw new ArgumentNullException(nameof(departureAirport));

        var flights = new Flights(this, departureAirport, arrivalAirport, departureTime, arrivalTime, countSeats);

        if (_flights.Contains(flights))
            throw new FlightAlreadyExistException(flights);

        _flights.Add(flights);
        return flights;
    }

    public bool AirlineInitializeSeats(Flights flight)
    {
        if (!_flights.Contains(flight)) 
            throw new ThereAreNoThisFlightsException();

        if (Id != flight.Airline.Id)
            throw new ThereAreNoThisFlightsException();

        flight.InitializeSeats(this, Tariffs);
        return true;
    }
}

