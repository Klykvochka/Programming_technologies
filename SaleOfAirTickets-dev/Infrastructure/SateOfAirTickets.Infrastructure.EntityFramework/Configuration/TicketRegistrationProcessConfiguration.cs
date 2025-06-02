using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class TicketRegistrationProcessConfiguration : IEntityTypeConfiguration<TicketRegistrationProcess>
{
    public void Configure(EntityTypeBuilder<TicketRegistrationProcess> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired();

        builder.HasOne(t => t.Customer).
            WithMany()
            .HasForeignKey("CustomerId");

        builder.HasOne(t => t.Ticket)
              .WithOne()
              .HasForeignKey<TicketRegistrationProcess>("TicketId");

        builder.HasOne(t => t.Flight)
            .WithMany()
            .HasForeignKey("FlightId");

        builder.HasOne(t => t.Seat)
            .WithOne()
            .HasForeignKey<TicketRegistrationProcess>("SeatId");


        builder.Property(t => t.Date).IsRequired().HasConversion(
    src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
    dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
);

        builder.Ignore(t => t.IsCancelled);
        builder.Ignore(t => t.IsBought);
        builder.Ignore(t => t.IsUnknown);
    }
}
