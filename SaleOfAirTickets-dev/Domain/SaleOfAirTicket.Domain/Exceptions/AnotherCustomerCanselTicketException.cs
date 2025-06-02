using SaleOfAirTicket.Domain.Entities;


namespace SaleOfAirTicket.Domain.Exceptions;
    internal class AnotherCustomerCanselTicketException(Customers customer)
        : InvalidOperationException($"Покупатель {customer.FirstName} не может закрыть билет другого покупателя ).")
    {

        public Customers Customer => customer;
    }


