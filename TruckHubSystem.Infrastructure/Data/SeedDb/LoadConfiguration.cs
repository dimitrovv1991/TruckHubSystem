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
    internal class LoadConfiguration : IEntityTypeConfiguration<Load>
    {
        public void Configure(EntityTypeBuilder<Load> builder)
        {
            var data = new SeedData();

            builder.HasData(new Load[]
            {
                data.FirstLoad,
                data.SecondLoad,
                data.ThirdLoad,
                data.FourthLoad,
                data.FifthLoad
            });
        }
    }
}
