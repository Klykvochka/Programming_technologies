using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.Seats;
public record class SeatModel(
    Guid Id,
    Guid AirlineId,
    Guid FlightId,
    Guid TariffId,
    int SeatNumber) : IModel<Guid>;

