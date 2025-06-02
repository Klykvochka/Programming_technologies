using GradeBookMicroservice.Application.Models.Base;
using SaleOfAirTickets.Application.Models.Tariffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOfAirTickets.Application.Services.Abstractions;
public interface ITariffsApplicationService
{
    Task<TariffModel?> GetTariffByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<TariffModel>> GetTariffAsync(CancellationToken cancellationToken);

    Task<TariffModel?> CreateTariffAsync(TariffCreateModel Information, CancellationToken cancellationToken);

    Task<bool> UpdateTariffAsync(TariffModel Tariff, CancellationToken cancellationToken);

    Task<bool> DeleteTariffAsync(Guid id, CancellationToken cancellationToken);
}

