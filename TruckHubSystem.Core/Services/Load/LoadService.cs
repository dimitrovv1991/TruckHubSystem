using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Load;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data.Common;

namespace TruckHubSystem.Core.Services.Load
{
    public class LoadService : ILoadService
    {
        private readonly IRepository repository;

        public LoadService(IRepository _repository)
        {
             repository = _repository;
        }

        public async Task<IEnumerable<LoadDetailsViewModel>> AllAvailableLoadsAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Load>()
                .Select(l => new LoadDetailsViewModel()
                {
                    Name = l.Name,
                    Weigth = l.Weigth,
                    Id = l.Id,
                    LoadCategoryName = l.LoadCategory.Name,
                    FactoryName = l.Factory.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LoadDetailsViewModel>> AllAvailableLoadsFromOtherUsersFactories(string id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Load>()
                .Where(l=>l.Factory.CreatorId!=id)
                .Select(l => new LoadDetailsViewModel()
                {
                    Name = l.Name,
                    Weigth = l.Weigth,
                    Id = l.Id,
                    LoadCategoryName = l.LoadCategory.Name,
                    FactoryName = l.Factory.Name
                })
                .ToListAsync();
        }

        public async Task<LoadDetailsViewModel> SelectLoadById(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Load>()
                .Where(l => l.Id == id)
                .Select(l=> new LoadDetailsViewModel()
                {
                    Name=l.Name,
                    Weigth = l.Weigth,
                    Id = l.Id,
                    FactoryName=l.Factory.Name,
                    LoadCategoryName=l.LoadCategory.Name
                })
                .FirstAsync();
        }
    }
}
