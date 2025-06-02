using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.TicketRegistrationProcess;
using SaleOfAirTickets.Application.Models.Tickets;


namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ITicketsRegistrationProcessApplicationService
{
    Task<TicketRegistrationProcessModel?> GetTicketsRegistrationProcessByIdAsync(Guid id, 
        CancellationToken cancellationToken);

    Task<IEnumerable<TicketRegistrationProcessModel>> GetTicketsRegistrationProcessesAsync(CancellationToken cancellationToken);

    Task<TicketRegistrationProcessModel?> CreateTicketsRegistrationProcessAsync(
        TicketRegistrationProcessCreateModel ticketsRegistrationProcessInformation,
        CustomerCreateModel customerInformation,
        TicketCreateModel ticketInformation,
        FlightCreateModel flightInformation,
        SeatCreateModel seatInformation,
        CancellationToken cancellationToken);

    Task<bool> UpdateTicketsRegistrationProcessAsync(TicketRegistrationProcessModel TicketRegistrationProcess, 
        CancellationToken cancellationToken);

    Task<bool> DeletTicketsRegistrationProcessAsync(Guid id, 
        CancellationToken cancellationToken);
}

