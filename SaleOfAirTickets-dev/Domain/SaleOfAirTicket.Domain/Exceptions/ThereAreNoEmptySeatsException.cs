using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class ThereAreNoEmptySeatsException(Flights flight)
        : InvalidOperationException($"Место на рейсе id = {flight.Id} нет доступных мест.")
{
    public Flights Flight => flight;
}
