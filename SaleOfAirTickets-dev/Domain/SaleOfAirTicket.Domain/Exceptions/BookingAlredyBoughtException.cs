using SaleOfAirTicket.Domain.Entities;
 

namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class BookingAlredyBoughtException(TicketRegistrationProcess booking)
        : InvalidOperationException("Booking is already bought.")
    {
        public TicketRegistrationProcess Booking => booking;
    }

}
