﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Load;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data.Common;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Core.Services.Load
{
    public class LoadService : ILoadService
    {
        private readonly IRepository repository;

        public LoadService(IRepository _repository)
        {
             repository = _repository;
        }

        public async Task<Infrastructure.Data.Models.Load> AddLoad(Infrastructure.Data.Models.Load loadToAdd)
        {
            await repository.AddAsync(loadToAdd);

            var currentLoad = await repository.AllReadOnly<Infrastructure.Data.Models.Load>()
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            return currentLoad;
        }

        public async Task AddLoadToCurrentLoads(Infrastructure.Data.Models.Load loadToAdd)
        {
            var currentLoad = new CurrentLoad()
            {
                LoadId = loadToAdd.Id,
                FactoryId = loadToAdd.FactoryId
            };

            await repository.AddAsync(currentLoad);
            await repository.SaveChangesAsync();
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
                .Where(l => l.Factory.CreatorId != id)
                .Select(l => new LoadDetailsViewModel()
                {
                    Name = l.Name,
                    Weigth = l.Weigth,
                    Id = l.Id,
                    LoadCategoryName = l.LoadCategory.Name,
                    FactoryName = l.Factory.Name,
                    IsLoadAvailable = l.IsLoadAvailable
                })
                .ToListAsync();
        }

        public async Task LoadNotAvailable(int id)
        {
            Infrastructure.Data.Models.Load load = await repository.GetByIdAsync<Infrastructure.Data.Models.Load>(id);

            if (load != null)
            {
                load.IsLoadAvailable = false;

                await repository.SaveChangesAsync();
            }
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
                    FactoryId = l.FactoryId,
                    LoadCategoryName=l.LoadCategory.Name
                })
                .FirstAsync();
        }
    }
}
