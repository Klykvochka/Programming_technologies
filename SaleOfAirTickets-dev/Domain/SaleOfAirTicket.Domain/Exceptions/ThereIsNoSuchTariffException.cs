using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
internal class ThereIsNoSuchTariffException(Flights flight)
    : InvalidOperationException($"Место на рейсе id = {flight.Id}  нет такого тарифа либо нет доступного места с таким тарифом.")
{
    public Flights Flight => flight;
}
