using SaleOfAirTicket.Domain.Entities;


namespace SaleOfAirTicket.Domain.Exceptions;
    internal class TicketAlredyNotActiveException(Tickets ticket)
        : InvalidOperationException($"Билет уже закрыт (id = {ticket.Id}).")
    {
        public Tickets Tickets => ticket;
    }
