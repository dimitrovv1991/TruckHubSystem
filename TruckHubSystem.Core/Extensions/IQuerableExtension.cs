using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableHouseExtension
    {
        public static IQueryable<FactoryDetailsViewModel> ProjectToFactoryServiceModel(this IQueryable<Factory> factories)
        {
            return factories
                .Select(f => new FactoryDetailsViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location,
                    LoadsReceived = f.LoadsReceived.Count(),
                    LoadsSent = f.LoadsSent.Count(),
                    CreatorId = f.CreatorId
                });
        }
    }
}
