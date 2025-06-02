using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class InvalidBookingException(Customers customer, TicketRegistrationProcess booking)
        : InvalidOperationException($"Невозможно приобрести билет по бронированию, не связанному с данным клиентом.")
{
    public TicketRegistrationProcess Booking => booking;
    public Customers Customer => customer;
}
