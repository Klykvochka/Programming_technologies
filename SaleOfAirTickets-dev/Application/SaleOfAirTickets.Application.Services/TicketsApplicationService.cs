using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.Tickets;
using SaleOfAirTickets.Application.Services.Abstractions;


namespace SaleOfAirTickets.Application.Services;
public class TicketsApplicationService(
IRepository<Seats, Guid> seatRepository,
IRepository<Tickets, Guid> ticketRepository,
IRepository<Customers, Guid> customerRepository,
IRepository<Passengers, Guid> passengerRepository,
IMapper mapper) : ITicketsApplicationService
{
    public async Task<IEnumerable<TicketModel>> GetTicketAsync(CancellationToken cancellationToken = default)
        => (await seatRepository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<TicketModel>);

    public async Task<TicketModel?> GetTicketByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticket = await ticketRepository.GetByIdAsync(id, cancellationToken);
        return ticket is null ? null : mapper.Map<TicketModel>(ticket);
    }


    public async Task<TicketModel?> CreateTicketAsync(
        TicketCreateModel ticketInformation,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetByIdAsync(ticketInformation.CustomerId, cancellationToken);
        if (customer is null)
            return null;

        var seat = await seatRepository.GetByIdAsync(ticketInformation.SeatId, cancellationToken);
        if (seat is null)
            return null;

        var passenger = await passengerRepository.GetByIdAsync(ticketInformation.PassengerId, cancellationToken);
        if (passenger is null)
            return null;

        if (await ticketRepository.GetByIdAsync(ticketInformation.Id, cancellationToken) is not null)
            return null;

        Tickets ticket = new(
            customer,
            passenger,
            seat
        );

        var createdTicket = await ticketRepository.AddAsync(ticket, cancellationToken);
        return createdTicket is null ? null : mapper.Map<TicketModel>(createdTicket);
    }

    public async Task<bool> UpdateTicketAsync(
        TicketModel ticket,
        CancellationToken cancellationToken = default)
    {
        var entity = await ticketRepository.GetByIdAsync(ticket.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Tickets>(ticket);
        return await ticketRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteTicketAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var ticket = await ticketRepository.GetByIdAsync(id, cancellationToken);
        return ticket is null ? false : await ticketRepository.DeleteAsync(ticket, cancellationToken);
    }


}
