using SaleOfAirTickets.Application.Models.Airlines;
using SaleOfAirTickets.Application.Models.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface IAirportsApplicationService
{
    Task<AirportModel?> GetAirportByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<AirportModel>> GetAirportsAsync(CancellationToken cancellationToken);

    Task<IEnumerable<AirportModel>> GetAirportsByCityAsync(string city, CancellationToken cancellationToken);

    Task<AirportModel?> CreateAirportAsync(AirportCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdateAirportAsync(AirportModel Airport, CancellationToken cancellationToken);

    Task<bool> DeleteAirportAsync(Guid id, CancellationToken cancellationToken);
}

