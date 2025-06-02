using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.Tariffs;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;


public class SeatsApplicationService(
    IRepository<Seats, Guid> seatRepository,
    IRepository<Tariffs, Guid> tariffRepository,
    IRepository<Airlines, Guid> airlineRepository,
    IRepository<Flights, Guid> flightRepository,
    IMapper mapper) : ISeatsApplicationService
{
    public async Task<IEnumerable<SeatModel>> GetSeatsAsync(CancellationToken cancellationToken = default)
        => (await seatRepository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<SeatModel>);

    public async Task<SeatModel?> GetSeatByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var seat = await seatRepository.GetByIdAsync(id, cancellationToken);
        return seat is null ? null : mapper.Map<SeatModel>(seat);
    }

    public async Task<SeatModel?> CreateSeatAsync(
        SeatCreateModel seatInformation,
        CancellationToken cancellationToken = default)
    {
        var tariff = await tariffRepository.GetByIdAsync(seatInformation.TariffId, cancellationToken);
        if (tariff is null)
            return null;

        var airline = await airlineRepository.GetByIdAsync(seatInformation.AirlineId, cancellationToken);
        if (airline is null)
            return null;

        var flight = await flightRepository.GetByIdAsync(seatInformation.FlightId, cancellationToken);
        if (flight is null)
            return null;

        if (await seatRepository.GetByIdAsync(seatInformation.Id, cancellationToken) is not null)
            return null;

        Seats seat = new(
            airline,
            flight,
            tariff,
            new SeatNumber(seatInformation.SeatNumber)
        );

        var createdSeat = await seatRepository.AddAsync(seat, cancellationToken);
        return createdSeat is null ? null : mapper.Map<SeatModel>(createdSeat);
    }

    public async Task<bool> UpdateSeatAsync(
        SeatModel seat,
        CancellationToken cancellationToken = default)
    {
        var entity = await seatRepository.GetByIdAsync(seat.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Seats>(seat);
        return await seatRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteSeatAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var seat = await seatRepository.GetByIdAsync(id, cancellationToken);
        return seat is null ? false : await seatRepository.DeleteAsync(seat, cancellationToken);
    }
}


