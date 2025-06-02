using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ISeatsApplicationService
{
    Task<SeatModel?> GetSeatByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<SeatModel>> GetSeatsAsync(CancellationToken cancellationToken);

    Task<SeatModel?> CreateSeatAsync(SeatCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdateSeatAsync(SeatModel Seat, CancellationToken cancellationToken);

    Task<bool> DeleteSeatAsync(Guid id, CancellationToken cancellationToken);
}


