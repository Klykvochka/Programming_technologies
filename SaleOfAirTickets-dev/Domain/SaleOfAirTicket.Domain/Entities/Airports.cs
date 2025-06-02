using SaleOfAirTicket.Domain.Entities.Base;
using SaleOfAirTicket.Domain.Exceptions;
using SaleOfAirTicket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Entities;
public class Airports : Entity<Guid>
{
    public Name Name { get; }
    public Country Country { get; }
    public City City { get; }

    protected Airports()
    {

    }
    protected Airports(Guid id, Name name, Country country, City city)
        : base(id)
    {

        Country = country ?? throw new ArgumentNullValueException(nameof(country));
        City = city ?? throw new ArgumentNullValueException(nameof(city));
        Name = name ?? throw new ArgumentNullValueException(nameof(name));

    }

    public Airports(Name name, Country country, City city)
        : this(Guid.NewGuid(), name, country, city)
    {

    }


}

