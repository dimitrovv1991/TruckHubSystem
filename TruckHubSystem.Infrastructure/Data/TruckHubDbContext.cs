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

        public DbSet<TransmissionType> TransmissionTypes { get; set; } = null!;

        public DbSet<Truck> Trucks { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Load>()
                .HasOne(l => l.LoadingFactory)
                .WithMany(f => f.LoadsSent)
                .HasForeignKey(l => l.LoadingFactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Load>()
                .HasOne(l => l.UnloadingFactory)
                .WithMany(f => f.LoadsReceived)
                .HasForeignKey(l => l.UnloadingFactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Load>()
                .Property(l => l.Price)
                .HasColumnType("decimal(18, 2)");


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

            builder.Entity<TransmissionType>()
                .HasData(new TransmissionType()
                {
                    Id = 1,
                    Name = "Automatic"
                },
                new TransmissionType()
                {
                    Id = 2,
                    Name = "Manual"
                });


            base.OnModelCreating(builder);
        }
    }
}