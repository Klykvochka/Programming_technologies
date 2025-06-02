using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.Handler
{
    internal abstract class BookingHandler
    {
        protected BookingHandler? NextHandler;

        public BookingHandler SetNext(BookingHandler nextHandler)
        {
            NextHandler = nextHandler;
            return nextHandler;
        }

        public abstract void Handle(Record record);
    }
}

