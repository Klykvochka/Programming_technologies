using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;


namespace SaleOfAirTicket.Domain.Entities;
public class Seats : Entity<Guid>
{
    public Airlines Airline { get; }
    public Flights Flight { get; }
    public Tariffs Tariff { get; }
    public SeatNumber SeatNumber { get; }
    public bool IsAvailable { get; private set; }
    public bool Free => IsAvailable == true;
    public bool IsOccupied => IsAvailable == false;
    protected Seats()
    {

    }
    protected Seats(Guid id,
        Airlines airline,
        Flights flights,
        Tariffs tariff,
        SeatNumber seatNumber)
        : base(id)
    {
        Airline = airline ?? throw new ArgumentNullValueException(nameof(airline));
        Flight = flights ?? throw new ArgumentNullValueException(nameof(flights));
        Tariff = tariff ?? throw new ArgumentNullValueException(nameof(tariff));
        SeatNumber = seatNumber ?? throw new ArgumentNullValueException(nameof(seatNumber));
        IsAvailable = true;
    }

    public Seats(
        Airlines airline,
        Flights flights,
        Tariffs tariff,
        SeatNumber seatNumber)
        : this(
              Guid.NewGuid(),
              airline,
              flights, tariff,
              seatNumber)
    {

    }

    public bool FreeTheSeat()
    {
        if (!IsOccupied)
            throw new SeatAlreadyFreeException(this);
        IsAvailable = true;
        return true;
    }
    public bool TakeTheSeat()
    {
        if (IsOccupied)
            throw new SeatNotFreeException(this);
        IsAvailable = false;
        return true;
    }
}

