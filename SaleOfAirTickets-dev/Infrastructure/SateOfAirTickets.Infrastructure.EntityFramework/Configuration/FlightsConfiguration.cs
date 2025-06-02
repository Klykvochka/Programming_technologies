using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class FlightsConfiguration : IEntityTypeConfiguration<Flights>
{
    public void Configure(EntityTypeBuilder<Flights> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.HasOne(f => f.Airline)
             .WithMany(a => a.Flights)
             .HasForeignKey("AirlineId")
             .IsRequired();

        builder.HasOne(f => f.DepartureAirport)
            .WithMany()
            .HasForeignKey("DepartureAirportId");

        builder.HasOne(f => f.ArrivalAirport)
            .WithMany()
            .HasForeignKey("ArrivalAirportId");

        builder.Property(f => f.DepartureTime).IsRequired().HasConversion(
            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
        );

        builder.Property(f => f.ArrivalTime).IsRequired().HasConversion(
            src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
            dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
        );

        builder.HasMany(f => f.Seats)
            .WithOne(s => s.Flight)
            .HasForeignKey("FlightId");

        builder.Property(f => f.CountSeats)
            .IsRequired()
            .HasConversion(
                CountSeats => CountSeats.Value,
                i => new CountSeats(i));
    }
}

