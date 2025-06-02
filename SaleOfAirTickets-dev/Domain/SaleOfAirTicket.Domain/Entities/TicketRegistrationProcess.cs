using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Enums;
using SaleOfAirTicket.Domain.Exceptions;



namespace SaleOfAirTicket.Domain.Entities;
public class TicketRegistrationProcess : Entity<Guid>
{
    public Customers Customer { get; }
    public Tickets Ticket { get; }
    public Flights Flight { get; }
    public Seats Seat { get; private set; }
    public PurchaseStatus Status { get; private set; }
    public DateTime Date { get; private set; }

    public bool IsCancelled => Status == PurchaseStatus.Cancelled;
    public bool IsUnknown => Status == PurchaseStatus.Unknown;
    public bool IsBought => Status == PurchaseStatus.Bought;


    protected TicketRegistrationProcess()
    {

    }
    protected TicketRegistrationProcess(
        Guid id,
        Tickets ticket,
        Flights flights,
        Seats seat,
        Customers customer,
        PurchaseStatus status,
        DateTime date)
        : base(id)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        Ticket = ticket ?? throw new ArgumentNullValueException(nameof(ticket));
        Flight = flights ?? throw new ArgumentNullValueException(nameof(flights));
        Seat = seat ?? throw new ArgumentNullValueException(nameof(seat));
        Status = status;
        Date = date;
    }

    public TicketRegistrationProcess(
        Tickets ticket,
        Flights flights,
        Seats seat,
        Customers customer,
        DateTime date)
        : this(Guid.NewGuid(), ticket, flights, seat, customer, PurchaseStatus.Unknown, date)
    {

    }

    public PurchaseStatus GetStatus()
    {
        return Status;
    }
    internal bool SetCancel(Customers customer)
    {
        if (Customer != customer)
            throw new AnotherCustomerWantCancelBookingException(customer);

        if (IsCancelled)
        {
            throw new BookingAlredyCancelException(this);
        }

        Ticket.SetCancel(Flight, Seat);
        Status = PurchaseStatus.Cancelled;
        Date = DateTime.UtcNow;
        return true;
    }

    public bool SetBought(Customers customer)
    {

        if (Customer != customer)
            throw new AnotherCustomerWantBookException(this, customer);

        if (IsCancelled)
            throw new BookingAlredyCancelException(this);

        if (IsBought)
            throw new BookingAlredyBoughtException(this);

        if (!Ticket.SetPurchase(Flight, Seat))
            return false;

        Status = PurchaseStatus.Bought;
        return true;
    }

}

