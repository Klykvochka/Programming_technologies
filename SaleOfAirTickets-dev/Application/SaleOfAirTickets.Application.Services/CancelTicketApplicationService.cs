using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTickets.Application.Models.Tickets;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;
    public class CancelTicketApplicationService(
IRepository<Tickets, Guid> ticketRepository,
IRepository<Customers, Guid> customerRepository
        ) : ICancelTicketApplicationService
{ 
   public async Task<bool> CancelTicketAsync(TicketModel information, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(information.CustomerId, cancellationToken);
        if (customer is null)
            return false;

        var ticket = await ticketRepository.GetByIdAsync(information.Id, cancellationToken);
        if (ticket is null)
            return false;

        if (!customer.CancelTicket(ticket))
            return false;

        if (!await customerRepository.UpdateAsync(customer, cancellationToken))
            return false;

        return true;
    }
}