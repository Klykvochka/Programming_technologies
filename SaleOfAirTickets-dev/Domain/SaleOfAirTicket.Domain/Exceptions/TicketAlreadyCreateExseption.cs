using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class TicketAlreadyCreateExseption(Tickets tickets)
        : InvalidOperationException($"Билет (id = {tickets.Id}) уже создан.")
    {
        public Tickets Ticket => tickets;
    }
}
