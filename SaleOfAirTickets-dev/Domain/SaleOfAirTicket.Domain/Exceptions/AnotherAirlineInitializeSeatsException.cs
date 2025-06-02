using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions
{
    public class AnotherAirlineInitializeSeatsException(Flights flight, Airlines airline)
    : InvalidOperationException($"Aвиалиния Id = {airline.Id} Не может инециализировать места на рейсе Id = {flight.Id} другой авиакомпании.")
    {
        public Flights Flight => flight;
        public Airlines Airline => airline;
    }
}
