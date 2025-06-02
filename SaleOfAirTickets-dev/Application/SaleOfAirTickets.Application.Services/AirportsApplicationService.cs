using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Airports;
using SaleOfAirTickets.Application.Services.Abstractions;


namespace SaleOfAirTickets.Application.Services;
public class AirportsApplicationService(IAirportsRepository airportRepository, IMapper mapper) : IAirportsApplicationService
{
    public async Task<IEnumerable<AirportModel>> GetAirportsAsync(CancellationToken cancellationToken = default)
        => (await airportRepository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<AirportModel>);

    public async Task<AirportModel?> GetAirportByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lot = await airportRepository.GetByIdAsync(id, cancellationToken);
        return lot is null ? null : mapper.Map<AirportModel>(lot);
    }

    public async Task<IEnumerable<AirportModel>> GetAirportsByCityAsync(string city, CancellationToken cancellationToken = default)
    {
        var airports = await airportRepository.GetAirportsByCityAsync(city, cancellationToken);
        return airports is null ? Enumerable.Empty<AirportModel>() : mapper.Map<IEnumerable<AirportModel>>(airports);
    }

    public async Task<AirportModel?> CreateAirportAsync(AirportCreateModel airportInformation, CancellationToken cancellationToken = default)
    {

        Airports airport = new(new Name(airportInformation.Name), new Country(airportInformation.Country), new City(airportInformation.City));

        var createdAirport = await airportRepository.AddAsync(airport, cancellationToken);
        return createdAirport is null ? null : mapper.Map<AirportModel>(createdAirport);
    }

    public async Task<bool> UpdateAirportAsync(AirportModel airport, CancellationToken cancellationToken = default)
    {
        var entity = await airportRepository.GetByIdAsync(airport.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Airports>(airport);
        return await airportRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAirportAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lot = await airportRepository.GetByIdAsync(id, cancellationToken);
        return lot is null ? false : await airportRepository.DeleteAsync(lot, cancellationToken);
    }
}
