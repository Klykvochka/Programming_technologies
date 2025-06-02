using SaleOfAirTicket.Domain.Entities;


namespace SaleOfAirTicket.Domain.Repositories.Abstractions;
public interface IAirportsRepository : IRepository<Airports, Guid>
{
    Task<IEnumerable<Airports?>> GetAirportsByCityAsync(string city, CancellationToken cancellationToken);
}

