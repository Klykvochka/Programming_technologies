using SaleOfAirTicket.Domain.Handler;
using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class BookingAlredyBookedException(TicketRegistrationProcess booking) 
        : InvalidOperationException("Booking is already booked.")
    {
       public TicketRegistrationProcess Booking => booking;
    }

