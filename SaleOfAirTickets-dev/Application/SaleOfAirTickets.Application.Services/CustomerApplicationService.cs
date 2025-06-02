using AutoMapper;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Repositories.Abstractions;
using SaleOfAirTicket.Domain.ValueObjects;
using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Services.Abstractions;

namespace SaleOfAirTickets.Application.Services;
public class CustomerApplicationService(IRepository<Customers, Guid> customerRepository, IMapper mapper) : ICustomerApplicationService
{
    public async Task<IEnumerable<CustomerModel>> GetCustomersAsync(CancellationToken cancellationToken = default)
    => (await customerRepository.GetAllAsync(cancellationToken = default, true)).Select(mapper.Map<CustomerModel>);

    public async Task<CustomerModel?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetByIdAsync(id, cancellationToken);
        return customer is null ? null : mapper.Map<CustomerModel>(customer);
    }

    public async Task<CustomerModel?> CreateCustomerAsync(
        CustomerCreateModel customerInformation,
        CancellationToken cancellationToken = default)
    {
        if (await customerRepository.GetByIdAsync(customerInformation.Id, cancellationToken) is not null)
            return null;

        Customers customer = new(
            new FirstName(customerInformation.FirstName),
            new LastName(customerInformation.LastName),
            string.IsNullOrWhiteSpace(customerInformation.PhoneNumber) ? null! : new PhoneNumber(customerInformation.PhoneNumber),
            string.IsNullOrWhiteSpace(customerInformation.Email) ? null! : new Email(customerInformation.Email)
            );

        var createdCustomer = await customerRepository.AddAsync(customer, cancellationToken);
        return createdCustomer is null ? null : mapper.Map<CustomerModel>(createdCustomer);
    }

    public async Task<bool> UpdateCustomerAsync(
        CustomerModel customer,
        CancellationToken cancellationToken = default)
    {
        var entity = await customerRepository.GetByIdAsync(customer.Id, cancellationToken);
        if (entity is null)
            return false;

        entity = mapper.Map<Customers>(customer);
        return await customerRepository.UpdateAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteCustomerAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var customer = await customerRepository.GetByIdAsync(id, cancellationToken);
        return customer is null ? false : await customerRepository.DeleteAsync(customer, cancellationToken);
    }

}

