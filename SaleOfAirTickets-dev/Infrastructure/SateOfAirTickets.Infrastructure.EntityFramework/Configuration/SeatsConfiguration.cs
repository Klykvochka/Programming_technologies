using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;
using SaleOfAirTicket.Domain.ValueObjects;

namespace SaleOfAirTickets.Infrastructure.Repositories.Implementations;
public class SeatsConfiguration : IEntityTypeConfiguration<Seats>
{
    public void Configure(EntityTypeBuilder<Seats> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).IsRequired();

        builder.Property(s => s.SeatNumber)
            .IsRequired()
            .HasConversion(
            seatNumber => seatNumber.Value,
            i => new SeatNumber(i));

        builder.HasOne(s => s.Airline)
            .WithMany()
            .HasForeignKey("AirlineId");

        builder.HasOne(s => s.Flight)
            .WithMany(f => f.Seats)
            .HasForeignKey("FlightId");

        builder.HasOne(s => s.Tariff)
            .WithMany()
            .HasForeignKey("TariffId");

        builder.Ignore(s => s.Free);
        builder.Ignore(s => s.IsOccupied);
    }
}

