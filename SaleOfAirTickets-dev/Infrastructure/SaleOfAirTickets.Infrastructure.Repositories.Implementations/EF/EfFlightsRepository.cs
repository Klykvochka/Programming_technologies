using AuctionTrading.Infrastructure.Repositories.Implementations.EF;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations.EF
{
    public class EfFlightsRepository(ApplicationDbContext context)
    : EfRepository<Flights, Guid>(context), IFlightsRepository
    {
        private readonly DbSet<Flights> _flights = context.Set<Flights>();
        public async Task<IEnumerable<Flights?>> GetFlightByFromWhereToWhereWhenAsync(
            string departureCity, 
            string arrivalCity,
            DateTime DateUtc, 
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(departureCity))
                return Enumerable.Empty<Flights?>();
            if (string.IsNullOrWhiteSpace(arrivalCity))
                return Enumerable.Empty<Flights?>();

            return await _flights
            .AsNoTracking()
                .Where(f => f.DepartureAirport.City.Equals(new City(departureCity))
                && f.ArrivalAirport.City.Equals(new City(arrivalCity))
                && f.DepartureTime == DateUtc.ToUniversalTime())
                .ToListAsync(cancellationToken);
        }
    }
}
