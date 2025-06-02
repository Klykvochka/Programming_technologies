using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
internal class TheSeatIsNotPartOfThisFlightException(Flights flight, Seats seat)
    : ArgumentException($"Место(id = {seat.Id}) не является частью данного рейса id = {flight.Id}.")
{
    public Seats Seat => seat;
    public Flights Flight => flight;
}