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
    internal class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            var data = new SeedData();

            builder.HasData(new Factory[]
            {
                data.FirstFactory,
                data.SecondFactory,
                data.ThirdFactory
            });
        }
    }
}
