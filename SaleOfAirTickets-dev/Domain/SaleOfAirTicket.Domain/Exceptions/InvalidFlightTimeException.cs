using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class InvalidFlightTimeException(Flights flight, DateTime departureTime, DateTime arrivalTime)
        : ArgumentException($"На рейсе id = {flight.Id} не корректное время отбытия и прибытия).")
    {
        public DateTime DepartureTime => departureTime;
        public DateTime ArrivalTime => arrivalTime;
        public Flights Flight => flight;
    }