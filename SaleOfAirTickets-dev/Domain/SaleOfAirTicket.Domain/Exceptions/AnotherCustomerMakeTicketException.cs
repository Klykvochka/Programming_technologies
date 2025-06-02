using SaleOfAirTicket.Domain.Entities;


namespace SaleOfAirTicket.Domain.Exceptions;
    internal class AnotherCustomerMakeTicketException(Customers customer)
        : InvalidOperationException($"Покупатель {customer.FirstName} не может выкупить билет другого покупателя ).")
    {

        public Customers Customer => customer;
    }

