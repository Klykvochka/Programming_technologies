using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Tariffs;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;

public class TariffApplicationService(IRepository<Tariffs, Guid> tariffRepository, IRepository<Airlines, Guid> airlineRepository, IMapper mapper) : ITariffsApplicationService
{
    public async Task<IEnumerable<TariffModel>> GetTariffAsync(CancellationToken cancellationToken = default)
        => (await tariffRepository.GetAllAsync(cancellationToken: default, true))
            .Select(mapper.Map<TariffModel>);

    public async Task<TariffModel?> GetTariffByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var tariff = await tariffRepository.GetByIdAsync(id, cancellationToken);
        return tariff is null ? null : mapper.Map<TariffModel>(tariff);
    }

    public async Task<TariffModel?> CreateTariffAsync(
        TariffCreateModel tariffInformation,
        CancellationToken cancellationToken = default)
    {
        var airline = await airlineRepository.GetByIdAsync(tariffInformation.AirlineId, cancellationToken);
        if (airline is null)
            return null;

        if (await tariffRepository.GetByIdAsync(tariffInformation.Id, cancellationToken) is not null)
            return null;

        Tariffs tariff = new(
            airline,
            new Name(tariffInformation.Name),
            new Price(tariffInformation.Price)
        );

        var createdTariff = await tariffRepository.AddAsync(tariff, cancellationToken);
        return createdTariff is null ? null : mapper.Map<TariffModel>(createdTariff);
    }

    public async Task<bool> UpdateTariffAsync(
        TariffModel tariff,
        CancellationToken cancellationToken = default)
    {
        var entity = await tariffRepository.GetByIdAsync(tariff.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Tariffs>(tariff);
        return await tariffRepository.UpdateAsync(entity, cancellationToken);
    }
    public async Task<bool> DeleteTariffAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var tariff = await tariffRepository.GetByIdAsync(id, cancellationToken);
        return tariff is null ? false : await tariffRepository.DeleteAsync(tariff, cancellationToken);
    }
}

