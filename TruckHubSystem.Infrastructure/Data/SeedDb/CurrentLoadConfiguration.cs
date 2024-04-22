using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Infrastructure.Data.SeedDb
{
    internal class CurrentLoadConfiguration : IEntityTypeConfiguration<CurrentLoad>
    {
        public void Configure(EntityTypeBuilder<CurrentLoad> builder)
        {

            builder
                .HasKey(cl => cl.Id);

            builder
                .HasOne(cl => cl.Factory)
                .WithMany()
                .HasForeignKey(lr => lr.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(cl => cl.Load)
                .WithMany()
                .HasForeignKey(cl => cl.LoadId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new CurrentLoad[]
            {
                data.FirstCurrentLoad,
                data.SecondCurrentLoad,
                data.ThirdCurrentLoad,
                data.FourthCurrentLoad,
                data.FifthCurrentLoad
            });
        }
    }
}
