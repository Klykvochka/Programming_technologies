using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;


namespace SaleOfAirTicket.Domain.Entities;
public class Tariffs : Entity<Guid>
{
    public Name Name { get; }
    public Price Price { get; }
    public Airlines Airline { get; }

    protected Tariffs()
    {

    }
    protected Tariffs(Guid id, 
        Airlines airline, 
        Name name, 
        Price price)
        : base(id)
    {

        Airline = airline ?? throw new ArgumentNullValueException(nameof(airline));
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        Price = price ?? throw new ArgumentNullValueException(nameof(price));

    }

    public Tariffs(Airlines airline, Name name, Price price)
        : this(Guid.NewGuid(), airline, name, price)
    {

    }
}

