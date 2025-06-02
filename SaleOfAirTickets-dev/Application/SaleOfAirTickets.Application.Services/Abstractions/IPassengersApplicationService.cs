using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Passengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface IPassengersApplicationService
{
    Task<PassengerModel?> GetPassengerByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<PassengerModel>> GetPassengersAsync(CancellationToken cancellationToken);

    Task<PassengerModel?> CreatePassengerAsync(PassengerCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdatePassengerAsync(PassengerModel Passenger, CancellationToken cancellationToken);

    Task<bool> DeletePassengerAsync(Guid id, CancellationToken cancellationToken);
}

