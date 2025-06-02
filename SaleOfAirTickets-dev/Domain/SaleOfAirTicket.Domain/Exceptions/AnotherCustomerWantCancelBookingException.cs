using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Handler;


namespace SaleOfAirTicket.Domain.Exceptions;
    internal class AnotherCustomerWantCancelBookingException( Customers customer)
        : InvalidOperationException($"Покупатель {customer.FirstName} не может закрыть бронь  другого покупателя.")
    {
        public Customers Customer => customer;
    }

