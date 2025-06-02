using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
internal class TheFlightIsFlyingToTheSameAirportException(Flights flight, Airports departureAirport, Airports arrivalAirport)
    : ArgumentException($"Рейс id = {flight.Id} Не может лететь в тот же Аэропорт).")
{
    public Airports DepartureAirport => departureAirport;
    public Airports ArrivalAirport => arrivalAirport;
    public Flights Flight => flight;
}

