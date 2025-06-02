using SaleOfAirTicket.Domain.ValueObjects.Base;
using SaleOfAirTicket.Domain.ValueObjects.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTicket.Domain.ValueObjects;

/// <summary>
/// Представляет собой тип эл. почты.
/// </summary>
/// <param name="email">Эл. почта.</param>
public class Email(string email) : ValueObject<string>(new EmailValidator(), email);

