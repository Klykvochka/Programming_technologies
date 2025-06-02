using GradeBookMicroservice.Application.Models.Base;

namespace SaleOfAirTickets.Application.Models.Tickets;
public record class TicketCreateModel(
    Guid Id,
    Guid CustomerId,
    Guid PassengerId,
    Guid SeatId) : ICreateModel;
