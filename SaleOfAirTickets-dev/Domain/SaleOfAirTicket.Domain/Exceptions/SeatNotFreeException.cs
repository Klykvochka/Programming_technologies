using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class SeatNotFreeException(Seats seats)
        : InvalidOperationException($"Место id = {seats.Id} number = {seats.SeatNumber} уже занято.")
{
    public Seats Seats => seats;
}

