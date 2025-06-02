using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class InvalidSeatNumberException(SeatNumber seatNumber, Flights flight)
    : InvalidOperationException($"Некорректный номер места {seatNumber} для рейса {flight.Id}.")
    {
        public Flights Flight => flight;
    }