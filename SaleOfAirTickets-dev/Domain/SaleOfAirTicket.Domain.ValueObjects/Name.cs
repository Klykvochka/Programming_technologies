using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип названия.
/// </summary>
/// <param name="name">Название.</param>
public class Name(string name): ValueObject<string>(new NameValidator(), name);

