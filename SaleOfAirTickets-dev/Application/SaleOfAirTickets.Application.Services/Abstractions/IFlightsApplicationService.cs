using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface IFlightsApplicationService
{
    Task<FlightModel?> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<FlightModel>> GetFlightsAsync(CancellationToken cancellationToken);

    Task<IEnumerable<FlightModel>> GetFlightByFromWhereToWhereWhenAsync(string departureCity, string arrivalCity, DateTime DateUtc, CancellationToken cancellationToken);

    Task<FlightModel?> CreateFlightAsync(FlightCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdateFlightAsync(FlightModel Flight, CancellationToken cancellationToken);

    Task<bool> DeleteFlightAsync(Guid id, CancellationToken cancellationToken);
}

