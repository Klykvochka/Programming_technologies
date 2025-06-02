using GradeBookMicroservice.Application.Models.Base;

namespace SaleOfAirTickets.Application.Models.Tickets;
public record class TicketSaleInfoModel(
    Guid Id,
    Guid CustomerId,
    Guid AirlineId,
    Guid FlightId,
    Guid DepartureAirportId,
    string DepartureCity,
    string ArrivalCity,
    DateTime DepartureDate,
    string NameTariff,
    int SeatNumber,
    string PassengerFirstName,
    string PassengerLastName) : IModel<Guid>;

