using SaleOfAirTickets.Application.Models.Customer;
using SaleOfAirTickets.Application.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;

public interface IAirlineInitializeSeatsService
{
    Task<bool> AirlineInitializeSeats(FlightModel information, CancellationToken cancellationToken);
}
