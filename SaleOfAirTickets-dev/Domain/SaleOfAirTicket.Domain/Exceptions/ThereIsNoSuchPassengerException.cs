using SaleOfAirTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Exceptions;
    internal class ThereIsNoSuchPassengerException(Customers customer, Passengers passenger)
        : InvalidOperationException($"Нет такогоко пассажира у данного покупателя.")
    {
        public Passengers Passenger => passenger;
        public Customers Customer => customer;
    }