using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class TicketsConfiguration : IEntityTypeConfiguration<Tickets>
{
    public void Configure(EntityTypeBuilder<Tickets> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();

        builder.HasOne(t => t.Passenger)
            .WithMany()
            .HasForeignKey("PassengerId");

        builder.HasOne(t => t.Seat)
            .WithMany()
            .HasForeignKey("SeatId");

        builder.Property(t => t.IsActive)
               .IsRequired();

        builder.Ignore(t => t.IfIsActive);
    }
}

//dotnet ef migrations add Initial --startup-project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Presentation\SaleOfAirTickets.WebHost\SaleOfAirTickets.WebHost.csproj" --project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Infrastructure\SateOfAirTickets.Infrastructure.EntityFramework\SaleOfAirTickets.Infrastructure.EntityFramework.csproj"
//dotnet ef database update --startup-project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Presentation\SaleOfAirTickets.WebHost\SaleOfAirTickets.WebHost.csproj" --project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Infrastructure\SateOfAirTickets.Infrastructure.EntityFramework\SaleOfAirTickets.Infrastructure.EntityFramework.csproj"

//dotnet ef migrations remove --startup-project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Presentation\SaleOfAirTickets.WebHost\SaleOfAirTickets.WebHost.csproj" --project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Infrastructure\SateOfAirTickets.Infrastructure.EntityFramework\SaleOfAirTickets.Infrastructure.EntityFramework.csproj"
//dotnet ef database update 0 --startup-project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Presentation\SaleOfAirTickets.WebHost\SaleOfAirTickets.WebHost.csproj" --project "C:\Users\polin\source\repos\SaleOfAirTickets-dev\Infrastructure\SateOfAirTickets.Infrastructure.EntityFramework\SaleOfAirTickets.Infrastructure.EntityFramework.csproj"
