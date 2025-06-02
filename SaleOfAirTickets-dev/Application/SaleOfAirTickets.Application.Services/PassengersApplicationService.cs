using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Passengers;
using SaleOfAirTickets.Application.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services;
public class PassengersApplicationService(IRepository<Passengers, Guid> passengerRepository, IMapper mapper) : IPassengersApplicationService
{
    public async Task<IEnumerable<PassengerModel>> GetPassengersAsync(CancellationToken cancellationToken = default)
        => (await passengerRepository.GetAllAsync(cancellationToken: default, true))
        .Select(mapper.Map<PassengerModel>);

    public async Task<PassengerModel?> GetPassengerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var passenger = await passengerRepository.GetByIdAsync(id, cancellationToken);
        return passenger is null ? null : mapper.Map<PassengerModel>(passenger);
    }

    public async Task<PassengerModel?> CreatePassengerAsync(
        PassengerCreateModel passengerInformation,
        CancellationToken cancellationToken = default)
    {
        if (await passengerRepository.GetByIdAsync(passengerInformation.Id, cancellationToken) is not null)
            return null;

        Passengers passenger = new(
            new FirstName(passengerInformation.FirstName),
            new LastName(passengerInformation.LastName),
            string.IsNullOrWhiteSpace(passengerInformation.PhoneNumber) ? null! : new PhoneNumber(passengerInformation.PhoneNumber),
            string.IsNullOrWhiteSpace(passengerInformation.Email) ? null! : new Email(passengerInformation.Email),
            new Passport(passengerInformation.Passport),
            passengerInformation.Birthday
        );

        var createdPassenger = await passengerRepository.AddAsync(passenger, cancellationToken);
        return createdPassenger is null ? null : mapper.Map<PassengerModel>(createdPassenger);
    }

    public async Task<bool> UpdatePassengerAsync(
        PassengerModel passenger,
        CancellationToken cancellationToken = default)
    {
        var entity = await passengerRepository.GetByIdAsync(passenger.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Passengers>(passenger);
        return await passengerRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeletePassengerAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var passenger = await passengerRepository.GetByIdAsync(id, cancellationToken);
        return passenger is null ? false : await passengerRepository.DeleteAsync(passenger, cancellationToken);
    }


}

