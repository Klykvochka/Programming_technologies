using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Enums;
using SaleOfAirTicket.Domain.Exceptions;


namespace SaleOfAirTicket.Domain.Entities;
public class Tickets : Entity<Guid>
{
    public Customers Customer { get; }
    public Passengers Passenger { get; }
    public Seats Seat { get; }
    public bool IsActive { get; private set; }
    public bool IfIsActive => IsActive == true;

    protected Tickets()
    {

    }
    protected Tickets(Guid id, Customers customer, Passengers passengers, Seats seat) : base(id)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Passenger = passengers ?? throw new ArgumentNullException(nameof(passengers));
        Seat = seat ?? throw new ArgumentNullValueException(nameof(seat));
        IsActive = true;
    }

    public Tickets(Customers customer, Passengers passengers, Seats seat)
        : this(Guid.NewGuid(), customer, passengers, seat)
    {

    }

    internal bool SetCancel(Flights flight, Seats seat)
    {
        if (flight == null)
        {
            throw new ArgumentNullException(nameof(flight));
        }
        if (seat == null)
        {
            throw new ArgumentNullException(nameof(seat));
        }
        if (IfIsActive == false)
            throw new TicketAlredyNotActiveException(this);
        IsActive = false;
        flight.FreeSeat(seat);
        return true;
    }
    internal bool SetPurchase(Flights flight, Seats seat)
    {
        if (flight == null)
            throw new ArgumentNullException(nameof(flight));

        if (seat == null)
            throw new ArgumentNullException(nameof(seat));

        if (!flight.BookSeat(seat))
            return false;
        return true;
    }

}
