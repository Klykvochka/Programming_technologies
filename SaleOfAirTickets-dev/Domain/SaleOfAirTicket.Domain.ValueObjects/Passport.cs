using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип серийного номера паспорта.
/// </summary>
/// <param name="passport">Серийный номер паспорта.</param>
public class Passport(string passport)
    : ValueObject<string>(new PassportValidator(), passport);


