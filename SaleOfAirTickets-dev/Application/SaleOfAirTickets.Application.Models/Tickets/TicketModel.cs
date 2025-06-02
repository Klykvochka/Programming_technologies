using GradeBookMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Models.Tickets;
public record class TicketModel(
    Guid Id,
    Guid CustomerId,
    Guid PassengerId,
    Guid SeatId) : IModel<Guid>;
