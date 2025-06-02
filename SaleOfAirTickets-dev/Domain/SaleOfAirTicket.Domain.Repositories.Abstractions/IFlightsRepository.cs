using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Repositories.Abstractions;
public interface IFlightsRepository : IRepository<Flights, Guid>
{
    Task<IEnumerable<Flights?>> GetFlightByFromWhereToWhereWhenAsync(string departureCity, string arrivalCity,
        DateTime DateUtc, CancellationToken cancellationToken);
}

