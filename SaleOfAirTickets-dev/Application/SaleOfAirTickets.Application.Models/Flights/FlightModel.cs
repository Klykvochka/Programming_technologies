using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Airports;
using SaleOfAirTickets.Application.Models.Seats;
using SaleOfAirTickets.Application.Models.TicketRegistrationProcess;


namespace SaleOfAirTickets.Application.Models.Flights;
public record class FlightModel(
    Guid Id,
    Guid AirlineId,
    Guid DepartureAirportId,
    Guid ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    int CountSeats) : IModel<Guid>
{
    public IEnumerable<SeatModel> Seats { get; init; }
}
