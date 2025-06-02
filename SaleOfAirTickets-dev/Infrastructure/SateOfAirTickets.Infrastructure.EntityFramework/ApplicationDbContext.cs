using Microsoft.EntityFrameworkCore;
using SaleOfAirTicket.Domain.Entities;

namespace SaleOfAirTickets.Infrastructure.EntityFramework
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Airlines> Airline { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Tariffs> Tariffs { get; set; }
        public DbSet<TicketRegistrationProcess> TicketRegistrationProcess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


    }
}
