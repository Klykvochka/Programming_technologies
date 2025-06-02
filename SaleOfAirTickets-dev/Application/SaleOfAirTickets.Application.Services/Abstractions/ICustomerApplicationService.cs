using SaleOfAirTickets.Application.Models.Customer;


namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ICustomerApplicationService
{
    Task<CustomerModel?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<CustomerModel>> GetCustomersAsync(CancellationToken cancellationToken);

    Task<CustomerModel?> CreateCustomerAsync(CustomerCreateModel customerInformation, CancellationToken cancellationToken);

    Task<bool> UpdateCustomerAsync(CustomerModel customer, CancellationToken cancellationToken);

    Task<bool> DeleteCustomerAsync(Guid id, CancellationToken cancellationToken);
}

