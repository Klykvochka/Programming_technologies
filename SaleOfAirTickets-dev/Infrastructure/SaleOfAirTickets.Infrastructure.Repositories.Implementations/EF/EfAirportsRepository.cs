using AuctionTrading.Infrastructure.Repositories.Implementations.EF;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Infrastructure.EntityFramework;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations.EF;
public class EfAirportsRepository(ApplicationDbContext context)
    : EfRepository<Airports, Guid>(context), IAirportsRepository
{
    private readonly DbSet<Airports> _airports = context.Set<Airports>();

    public async Task<IEnumerable<Airports?>> GetAirportsByCityAsync(string city, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(city))
            return Enumerable.Empty<Airports?>();

        return await _airports
            .AsNoTracking()
            .Where(a => a.City.Equals(new City(city)))
            .ToListAsync(cancellationToken);
    }

}
