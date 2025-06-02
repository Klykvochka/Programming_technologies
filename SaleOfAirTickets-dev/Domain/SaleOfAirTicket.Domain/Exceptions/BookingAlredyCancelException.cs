using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.Handler;


namespace SaleOfAirTicket.Domain.Exceptions;
    internal class BookingAlredyCancelException(TicketRegistrationProcess booking)
        : InvalidOperationException("Booking is already cancelled.")
    {
        public TicketRegistrationProcess Booking => booking;
    }


