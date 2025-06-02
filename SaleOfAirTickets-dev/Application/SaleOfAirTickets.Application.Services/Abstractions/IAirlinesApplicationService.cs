using SaleOfAirTickets.Application.Models.Airlines;
using SaleOfAirTickets.Application.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface IAirlinesApplicationService
{
    Task<AirlineModel?> GetAirlineByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<AirlineModel>> GetAirlinesAsync(CancellationToken cancellationToken);

    Task<AirlineModel?> CreateAirlineAsync(AirlineCreateModel AirlineInformation, CancellationToken cancellationToken);

    Task<bool> UpdateAirlineAsync(AirlineModel Airline, CancellationToken cancellationToken);

    Task<bool> DeleteAirlineAsync(Guid id, CancellationToken cancellationToken);
}


