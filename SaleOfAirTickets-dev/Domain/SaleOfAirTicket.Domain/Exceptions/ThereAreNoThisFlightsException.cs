using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class ThereAreNoThisFlightsException()
    : ArgumentException("Нет такого рейса у этой авиалинии.")
    {
    }

