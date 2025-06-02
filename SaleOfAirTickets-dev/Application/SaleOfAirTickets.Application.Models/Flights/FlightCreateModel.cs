using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Flights;
public record class FlightCreateModel(
    Guid Id,
    Guid AirlineId,
    Guid DepartureAirportId,
    Guid ArrivalAirportId,
    DateTime DepartureTime,
    DateTime ArrivalTime,
    int CountSeats) : ICreateModel;
