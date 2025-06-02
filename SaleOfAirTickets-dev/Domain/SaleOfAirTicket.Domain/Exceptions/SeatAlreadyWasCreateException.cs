using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;

internal class SeatAlreadyWasCreateException(Seats seats)
        : InvalidOperationException($"Место уже есть.")
{
    public Seats Seats => seats;
}

