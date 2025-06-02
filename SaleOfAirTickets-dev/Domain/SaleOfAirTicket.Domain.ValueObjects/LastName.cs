using SaleOfAirTicket.Domain.ValueObjects.Validators;
using SaleOfAirTicket.Domain.ValueObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип фамилии.
/// </summary>
/// <param name="lastName">Фамилия.</param>
public class LastName(string lastName)
    : ValueObject<string>(new LastNameValidator(), lastName);

