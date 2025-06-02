using GradeBookMicroservice.Application.Models.Base;


namespace SaleOfAirTickets.Application.Models.TicketRegistrationProcess;
public record class TicketRegistrationProcessModel(
    Guid Id,
    Guid CustomerId,
    Guid TicketId,
    Guid FlightId,
    Guid SeatId,
    DateTime Date) : IModel<Guid>;
