using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Tariffs;
using SaleOfAirTickets.Application.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ITicketsApplicationService
{
    Task<TicketModel?> GetTicketByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<TicketModel>> GetTicketAsync(CancellationToken cancellationToken);

    Task<TicketModel?> CreateTicketAsync(TicketCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdateTicketAsync(TicketModel Ticket, CancellationToken cancellationToken);

    Task<bool> DeleteTicketAsync(Guid id, CancellationToken cancellationToken);
}

