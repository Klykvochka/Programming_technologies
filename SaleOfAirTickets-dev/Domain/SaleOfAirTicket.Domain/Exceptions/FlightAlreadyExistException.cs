using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions
{
    internal class FlightAlreadyExistException(Flights flights)
        : InvalidOperationException($"Такой рейс (id = {flights.Id}) уже существует.")
    {
        public Flights Flight => flights;
    }
}

