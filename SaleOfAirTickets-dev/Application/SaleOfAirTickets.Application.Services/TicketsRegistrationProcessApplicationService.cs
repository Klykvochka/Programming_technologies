using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.TicketRegistrationProcess;
using SaleOfAirTickets.Application.Models.Tickets;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;
internal class TicketsRegistrationProcessApplicationService(
    IRepository<TicketRegistrationProcess, Guid> ticketRegistrationProcessRepository,
    IRepository<Customers, Guid> customerRepository,
    IRepository<Tickets, Guid> ticketsRepository,
    IRepository<Flights, Guid> flightRepository,
    IRepository<Seats, Guid> seatsRepository,
    IMapper mapper) : ITicketsRegistrationProcessApplicationService
{
    public async Task<IEnumerable<TicketRegistrationProcessModel>> GetTicketsRegistrationProcessesAsync(CancellationToken cancellationToken = default)
        => (await ticketRegistrationProcessRepository.GetAllAsync(cancellationToken: default, true))
            .Select(mapper.Map<TicketRegistrationProcessModel>);

    public async Task<TicketRegistrationProcessModel?> GetTicketsRegistrationProcessByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticketsRegistrationProcess = await ticketRegistrationProcessRepository.GetByIdAsync(id, cancellationToken);
        return ticketsRegistrationProcess is null ? null : mapper.Map<TicketRegistrationProcessModel>(ticketsRegistrationProcess);
    }

    public async Task<TicketRegistrationProcessModel?> CreateTicketsRegistrationProcessAsync(
        TicketRegistrationProcessCreateModel ticketsRegistrationProcessInformation,
        CustomerCreateModel customerInformation,
        TicketCreateModel ticketInformation,
        FlightCreateModel flightInformation,
        SeatCreateModel seatInformation,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetByIdAsync(customerInformation.Id, cancellationToken);
        if (customer is null)
            return null;

        var ticket = await ticketsRepository.GetByIdAsync(ticketInformation.Id, cancellationToken);
        if (ticket is null)
            return null;

        var flight = await flightRepository.GetByIdAsync(flightInformation.Id, cancellationToken);
        if (flight is null)
            return null;

        var seat = await seatsRepository.GetByIdAsync(flightInformation.Id, cancellationToken);
        if (seat is null)
            return null;


        if (await ticketRegistrationProcessRepository.GetByIdAsync(ticketsRegistrationProcessInformation.Id, cancellationToken) is not null)
            return null;

        TicketRegistrationProcess ticketsRegistrationProcess = new(
            ticket,
            flight,
            seat,
            customer,
            ticketsRegistrationProcessInformation.Date
        );

        var createdTicketsRegistrationProcess = await ticketRegistrationProcessRepository.AddAsync(ticketsRegistrationProcess, cancellationToken);
        return createdTicketsRegistrationProcess is null ? null : mapper.Map<TicketRegistrationProcessModel>(createdTicketsRegistrationProcess);
    }

    public async Task<bool> UpdateTicketsRegistrationProcessAsync(
        TicketRegistrationProcessModel ticketRegistrationProcess,
        CancellationToken cancellationToken = default)
    {
        var entity = await ticketRegistrationProcessRepository.GetByIdAsync(ticketRegistrationProcess.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<TicketRegistrationProcess>(ticketRegistrationProcess);
        return await ticketRegistrationProcessRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeletTicketsRegistrationProcessAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var ticketRegistrationProcess = await ticketRegistrationProcessRepository.GetByIdAsync(id, cancellationToken);
        return ticketRegistrationProcess is null ? false : await ticketRegistrationProcessRepository.DeleteAsync(ticketRegistrationProcess, cancellationToken);
    }
}


