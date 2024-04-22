using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Infrastructure.Data.SeedDb
{
    internal class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            var data = new SeedData();

            builder.HasData(new Truck[]
            {
                data.FirstTruck,
                data.SecondTruck,
                data.ThirdTruck,
                data.FourthTruck,
                data.FifthTruck
            });
        }
    }
}
