using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class AnotherCustomerWantBookException(TicketRegistrationProcess booking, Customers customer)
        : InvalidOperationException($"Покупатель {customer.FirstName} не может оформить бронь {booking.Id} другого покупателя {booking.Customer.LastName}).")
    {
        public TicketRegistrationProcess Booking => booking;
        public Customers Customer => customer;
    }
}
