using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTickets.Application.Models.Flights;
using SaleOfAirTickets.Application.Services.Abstractions;
namespace SaleOfAirTickets.Application.Services;
public class FlightsApplicationService(
    IFlightsRepository flightRepository,
    IAirportsRepository airportRepository,
    IRepository<Airlines, Guid> airlineRepository,
    IMapper mapper)
    : IFlightsApplicationService
{
    public async Task<IEnumerable<FlightModel>> GetFlightsAsync(CancellationToken cancellationToken = default)
        => (await flightRepository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<FlightModel>);

    public async Task<FlightModel?> GetFlightByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var flight = await flightRepository.GetByIdAsync(id, cancellationToken);
        return flight is null ? null : mapper.Map<FlightModel>(flight);
    }

    public async Task<FlightModel?> CreateFlightAsync(
        FlightCreateModel flightInformation,
        CancellationToken cancellationToken = default)
    {
        var airline = await airlineRepository.GetByIdAsync(flightInformation.AirlineId, cancellationToken);
        if (airline is null)
            return null;

        var departureAirport = await airportRepository.GetByIdAsync(flightInformation.DepartureAirportId, cancellationToken);
        if (departureAirport is null)
            return null;

        var arrivalAirport = await airportRepository.GetByIdAsync(flightInformation.ArrivalAirportId, cancellationToken);
        if (arrivalAirport is null)
            return null;

        if (await flightRepository.GetByIdAsync(flightInformation.Id, cancellationToken) is not null)
            return null;

        Flights flight = new(
            airline,
            departureAirport,
            arrivalAirport,
            flightInformation.DepartureTime,
            flightInformation.ArrivalTime,
            new(flightInformation.CountSeats)
                );

        var createdFlight = await flightRepository.AddAsync(flight, cancellationToken);
        return createdFlight is null ? null : mapper.Map<FlightModel>(createdFlight);
    }

    public async Task<bool> UpdateFlightAsync(
        FlightModel flight,
        CancellationToken cancellationToken = default)
    {
        var entity = await flightRepository.GetByIdAsync(flight.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Flights>(flight);
        return await flightRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<IEnumerable<FlightModel>> GetFlightByFromWhereToWhereWhenAsync(
        string departureCity,
        string arrivalCity,
        DateTime DateUtc,
        CancellationToken cancellationToken)
    {
        var flight = await flightRepository.GetFlightByFromWhereToWhereWhenAsync(departureCity, arrivalCity, DateUtc, cancellationToken);
        return flight is null ? Enumerable.Empty<FlightModel>() : mapper.Map<IEnumerable<FlightModel>>(flight);
    }

    public async Task<bool> DeleteFlightAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var flight = await flightRepository.GetByIdAsync(id, cancellationToken);
        return flight is null ? false : await flightRepository.DeleteAsync(flight, cancellationToken);
    }

}
