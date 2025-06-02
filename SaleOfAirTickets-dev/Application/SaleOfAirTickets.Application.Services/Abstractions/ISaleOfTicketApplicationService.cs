using SaleOfAirTickets.Application.Models.Tickets;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ISaleOfTicketApplicationService
{
    Task<bool> SaleOfAirTicketAsync(TicketSaleInfoModel information, CancellationToken cancellationToken);
}

