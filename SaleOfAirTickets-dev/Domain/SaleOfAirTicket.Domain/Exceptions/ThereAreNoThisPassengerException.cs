using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
internal class ThereAreNoThisPassengerException()
    : InvalidOperationException($"Нет такого пассажира");

