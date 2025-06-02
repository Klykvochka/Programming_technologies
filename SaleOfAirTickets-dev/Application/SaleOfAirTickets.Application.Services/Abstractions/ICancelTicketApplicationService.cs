using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Models.TicketRegistrationProcess;
using SaleOfAirTickets.Application.Models.Tickets;


namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ICancelTicketApplicationService
{
    Task<bool> CancelTicketAsync(TicketModel information, CancellationToken cancellationToken);
}

