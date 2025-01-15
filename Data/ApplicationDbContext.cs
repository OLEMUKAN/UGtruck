using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TruckLoadingApp.Models;

namespace TruckLoadingApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TRoute> TRoutes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DriverSchedule> DriverSchedules { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Client)
                .WithMany()
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRoute>()
                .HasOne(r => r.Origin)
                .WithMany()
                .HasForeignKey(r => r.OriginId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRoute>()
                .HasOne(r => r.Destination)
                .WithMany()
                .HasForeignKey(r => r.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRoute>()
                .HasOne(r => r.Driver)
                .WithMany()
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRoute>()
                .HasOne(r => r.Truck)
                .WithMany()
                .HasForeignKey(r => r.TruckId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Truck>()
                .HasOne(t => t.Driver)
                .WithMany()
                .HasForeignKey(t => t.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Load>()
                .HasOne(l => l.PickupLocation)
                .WithMany()
                .HasForeignKey(l => l.PickupLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Load>()
                .HasOne(l => l.DeliveryLocation)
                .WithMany()
                .HasForeignKey(l => l.DeliveryLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Load>()
                .HasOne(l => l.Shipment)
                .WithMany(s => s.Loads)
                .HasForeignKey(l => l.ShipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Load>()
                .HasOne(l => l.Booking)
                .WithMany()
                .HasForeignKey(l => l.BookingId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Client)
                .WithMany()
                .HasForeignKey(b => b.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Route)
                .WithMany()
                .HasForeignKey(b => b.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<TruckLoadingApp.Models.Load> Load { get; set; } = default!;
    }
}

