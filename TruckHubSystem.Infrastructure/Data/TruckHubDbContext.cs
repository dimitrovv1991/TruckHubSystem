using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Infrastructure.Data
{
    public class TruckHubDbContext : IdentityDbContext
    {
        public TruckHubDbContext(DbContextOptions<TruckHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingStatus> BookingStatuses { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;

        public DbSet<Factory> Factories { get; set; } = null!;
        public DbSet<Load> Loads { get; set; } = null!;

        public DbSet<LoadCategory> LoadCategories { get; set; } = null!;

        public DbSet<LoadReceived> LoadsReceived {  get; set; } = null!;
        public DbSet<LoadSent> LoadsSent {  get; set; } = null!;

        public DbSet<Truck> Trucks { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoadReceived>()
                .HasKey(lr => lr.Id);

            builder.Entity<LoadReceived>()
                .HasOne(lr => lr.Factory)
                .WithMany()
                .HasForeignKey(lr => lr.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LoadReceived>()
                .HasOne(lr => lr.Load)
                .WithMany()
                .HasForeignKey(lr => lr.LoadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LoadSent>()
                .HasKey(lr => lr.Id);

            builder.Entity<LoadSent>()
                .HasOne(lr => lr.Factory)
                .WithMany()
                .HasForeignKey(lr => lr.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<LoadSent>()
                .HasOne(lr => lr.Load)
                .WithMany()
                .HasForeignKey(lr => lr.LoadId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<BookingStatus>()
                .HasData(new BookingStatus()
                {
                    Id = 1,
                    Name = "In progress"
                },
                new BookingStatus()
                {
                    Id = 2,
                    Name = "Completed"
                });


            builder
                .Entity<LoadCategory>()
                .HasData(new LoadCategory()
                {
                    Id = 1,
                    Name = "Building materials"
                },
                new LoadCategory()
                {
                    Id = 2,
                    Name = "Foods"
                },
                new LoadCategory()
                {
                    Id = 3,
                    Name = "Electronics"
                },
                new LoadCategory()
                {
                    Id = 4,
                    Name = "Medical Supplies"
                },
                new LoadCategory()
                {
                    Id = 5,
                    Name = "Chemicals"
                },
                new LoadCategory()
                {
                    Id = 6,
                    Name = "Automotive"
                },
                new LoadCategory()
                {
                    Id = 7,
                    Name = "Textiles"
                },
                new LoadCategory()
                {
                    Id = 8,
                    Name = "Others"
                });

            base.OnModelCreating(builder);
        }
    }
}