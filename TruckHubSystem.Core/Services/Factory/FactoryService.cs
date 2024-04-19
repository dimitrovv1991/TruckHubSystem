using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Factory;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Common;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Core.Services.Factory
{
    public class FactoryService : IFactoryService
    {
        private readonly IRepository repository;
        private readonly TruckHubDbContext dbContext;

        public FactoryService(IRepository _repository, TruckHubDbContext dbContext)
        {
            repository = _repository;
            this.dbContext = dbContext;

        }

        public async Task AddReceivedLoad(int loadId, int receivingFactoryId)
        {
            var load = await repository.AllReadOnly<Infrastructure.Data.Models.Load>()
                .Where(l=>l.Id == loadId)
                .FirstAsync();

            var receivedLoad = new LoadReceived
            {
                LoadId = load.Id,
                FactoryId = receivingFactoryId
            };

            await repository.AddAsync(receivedLoad);
            await repository.SaveChangesAsync();
        }

        public async Task AddSentLoadToTheOriginFactory(LoadDetailsViewModel load)
        {
            var loadSent = new LoadSent
            {
                FactoryId = load.FactoryId,
                LoadId = load.Id
            };

            repository.AddAsync(loadSent);
        }

        public async Task<IEnumerable<LoadCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<LoadCategory>()
                .Select(c=>new LoadCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<LoadCategory>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<FactoryDetailsViewModel>> AllFactoriesByUserIdAsync(string userId)
        {
            var factories = repository.AllReadOnly<FactoryDetailsViewModel>()
                .Select(f => new FactoryDetailsViewModel()
                 {
                     Id = f.Id,
                     Name = f.Name,
                     Location = f.Location,
                     LoadsReceived = f.LoadsReceived,
                     LoadsSent = f.LoadsSent,
                     CurrentLoads = dbContext.Loads.Count(l=>l.Id==f.Id),
                     CreatorId = f.CreatorId
                 });

            return await factories
                .Where(f=>f.CreatorId==userId)
                .ToListAsync();
        }

        public async Task DeleteSentLoadFromTheOriginFactory(int id)
        {
            var currentLoad = await repository.AllReadOnly<CurrentLoad>()
                .Where(l => l.LoadId == id)
                .FirstAsync();

            await repository.DeleteAsync<CurrentLoad>(currentLoad.Id);
            await repository.SaveChangesAsync();
        }

        public ICollection<LoadCategoryServiceModel> GetCategories()
        {
            return repository.AllReadOnly<LoadCategory>()
                .Select(c => new LoadCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }

        public async Task LoadOriginFactoryById(int id, LoadDetailsViewModel load)
        {
           
        }

        public async Task<FactoryDetailsViewModel> SelectedFactoryById(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Factory>()
               .Where(t => t.Id == id)
               .Select(t => new FactoryDetailsViewModel()
               {
                   Id = t.Id,
                   Name = t.Name,
                   Location = t.Location,
                   CreatorId = t.CreatorId
               })
               .FirstAsync();
        }
    }
}
