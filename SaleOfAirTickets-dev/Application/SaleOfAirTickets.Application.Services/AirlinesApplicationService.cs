using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Airlines;
using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Services.Abstractions;


namespace SaleOfAirTickets.Application.Services;
public class AirlinesApplicationService(IRepository<Airlines, Guid> airlineRepository, IMapper mapper) : IAirlinesApplicationService
{
    public async Task<IEnumerable<AirlineModel>> GetAirlinesAsync(CancellationToken cancellationToken = default)
        => (await airlineRepository.GetAllAsync(cancellationToken, true)).Select(mapper.Map<AirlineModel>);

    public async Task<AirlineModel?> GetAirlineByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lot = await airlineRepository.GetByIdAsync(id, cancellationToken);
        var res = mapper.Map<AirlineModel>(lot);
        return lot is null ? null : mapper.Map<AirlineModel>(lot);
    }

    public async Task<AirlineModel?> CreateAirlineAsync(AirlineCreateModel airlineInformation, CancellationToken cancellationToken = default)
    {

        Airlines airline = new(new Name(airlineInformation.Name), new Country(airlineInformation.Country));

        var createdAirline = await airlineRepository.AddAsync(airline, cancellationToken);
        return createdAirline is null ? null : mapper.Map<AirlineModel>(createdAirline);
    }

    public async Task<bool> UpdateAirlineAsync(AirlineModel airline, CancellationToken cancellationToken = default)
    {
        var entity = await airlineRepository.GetByIdAsync(airline.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Airlines>(airline);
        return await airlineRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAirlineAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var lot = await airlineRepository.GetByIdAsync(id, cancellationToken);
        return lot is null ? false : await airlineRepository.DeleteAsync(lot, cancellationToken);
    }
}
