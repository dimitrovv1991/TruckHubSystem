using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Infrastructure.Data.SeedDb
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder) 
        {
            var data = new SeedData();

            builder.HasData(new Driver[] 
            {
                data.FirstDriver, 
                data.SecondDriver,
                data.ThirdDriver,
                data.FourthDriver,
                data.FifthDriver
            });
        }
    }
}
