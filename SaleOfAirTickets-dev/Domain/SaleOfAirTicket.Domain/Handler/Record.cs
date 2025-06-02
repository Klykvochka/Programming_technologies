using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;
using System.Runtime.CompilerServices;


namespace SaleOfAirTicket.Domain.Handler;
internal class Record : Entity<Guid>
{
    public Customers Customer { get; }
    public Flights? Flight { get; set; }
    public Seats? Seat { get; set; }
    public DateTime Date { get; }
    public Tariffs? Tariff { get; set; }
    public Passengers? Passenger { get; set; }
    public TicketRegistrationProcess? Booking { get; set; }
    public City DepartureCity { get; }
    public City ArrivalCity { get; }
    public Name TariffName { get; }
    public FirstName PassangerFirstName { get; }
    public LastName PassangerLastName { get; }
    public Tickets? Ticket { get; set; }
    protected Record()
    {

    }
    protected Record(
        Guid id,
        Customers customer,
        City departureCity,
        City arrivalCity,
        DateTime date,
        Name tariffName,
        FirstName passangerFirstName,
        LastName passangerLastName
        )
        : base(id)
    {
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        DepartureCity = departureCity ?? throw new ArgumentNullValueException(nameof(departureCity));
        ArrivalCity = arrivalCity ?? throw new ArgumentNullValueException(nameof(arrivalCity));
        TariffName = tariffName ?? throw new ArgumentNullValueException(nameof(tariffName));
        PassangerFirstName = passangerFirstName ?? throw new ArgumentNullValueException(nameof(passangerFirstName));
        PassangerLastName = passangerLastName ?? throw new ArgumentNullValueException(nameof(passangerLastName));
        Date = date;

    }

    public Record(
        Customers customer,
        City departureCity,
        City arrivalCity,
        DateTime date,
        Name tariffName,
        FirstName passangerFirstName,
        LastName passangerLastName
        )
        : this(Guid.NewGuid(),
              customer,
              departureCity,
              arrivalCity,
              date, tariffName,
              passangerFirstName,
              passangerLastName)
    {

    }


}

