using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Seats;
public record class SeatCreateModel(
    Guid Id,
    Guid AirlineId,
    Guid FlightId,
    Guid TariffId,
    int SeatNumber) : ICreateModel;
