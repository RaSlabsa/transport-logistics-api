using Microsoft.EntityFrameworkCore;
using transport_logistics_api.Data.Entities;
using System;
using System.Numerics;

namespace transport_logistics_api.Data
{
    public class TransportLogicDB : DbContext
    {
        public TransportLogicDB(DbContextOptions<TransportLogicDB> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(u => u.ClientType)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(u => u.OrderStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Vehicle>()
                .Property(u => u. VehicleType)
                .HasConversion<string>();

            modelBuilder.Entity<Trip>()
                .Property(u => u.TripStatus)
                .HasConversion<string>();

            modelBuilder.Entity<TripLog>()
                .Property(u => u.EventType)
                .HasConversion<string>();
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
