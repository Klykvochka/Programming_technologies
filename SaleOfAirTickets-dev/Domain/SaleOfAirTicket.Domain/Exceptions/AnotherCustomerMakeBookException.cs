using SaleOfAirTicket.Domain.Entities;
 

namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class AnotherCustomerMakeBookingException( Customers customer)
        : InvalidOperationException($"Покупатель {customer.FirstName} не может выкупить бронь  другого покупателя ).")
    {

        public Customers Customer => customer;
    }
}
