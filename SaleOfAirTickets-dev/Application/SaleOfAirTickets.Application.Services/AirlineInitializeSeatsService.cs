using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;
public class AirlineInitializeSeatsService(
    IFlightsRepository flightRepository,
    IRepository<Airlines, Guid> airlineRepository,
    IMapper mapper)
    : IAirlineInitializeSeatsService
{
    public async Task<bool> AirlineInitializeSeats(FlightModel information, CancellationToken cancellationToken)
    {
        var airline = await airlineRepository.GetByIdAsync(information.AirlineId, cancellationToken);
        if (airline is null)
            return false;

        var flight = await flightRepository.GetByIdAsync(information.Id, cancellationToken);
        if (flight is null)
            return false;

        if (!airline.AirlineInitializeSeats(flight))
            return false;

        return true;
    }
}

