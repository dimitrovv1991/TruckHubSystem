using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Truck;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data.Common;

namespace TruckHubSystem.Core.Services.Truck
{
    public class TruckService : ITruckService
    {
        private readonly IRepository repository;

        public TruckService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<IEnumerable<TruckDetailsViewModel>> AllAvailableTrucksAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Truck>()
                .Select(t => new TruckDetailsViewModel()
                {
                    Id = t.Id,
                    Model = t.Model,
                    Manufacturer = t.Manufacturer,
                    LicensePlate = t.LicensePlate,
                    ImageUrl = t.ImageUrl,
                    Available = t.Available,
                    CapacityKg = t.CapacityKg,
                })
                .Where(t => t.Available == true)
                .ToListAsync();
        }

        public async Task<TruckDetailsViewModel> SelectedTruckById(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Truck>()
                .Where(t=>t.Id == id)
                .Select(t => new TruckDetailsViewModel()
                {
                    Id = t.Id,
                    Model = t.Model,
                    Manufacturer = t.Manufacturer,
                    LicensePlate = t.LicensePlate,
                    ImageUrl = t.ImageUrl,
                    Available = t.Available,
                    CapacityKg = t.CapacityKg,
                })
                .FirstAsync();
        }

        public async Task TruckAvailable(int id)
        {
            Infrastructure.Data.Models.Truck truck = await repository.GetByIdAsync<Infrastructure.Data.Models.Truck>(id);

            if (truck != null)
            {
                truck.Available = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task TruckNotAvailable(int id)
        {
            Infrastructure.Data.Models.Truck truck = await repository.GetByIdAsync<Infrastructure.Data.Models.Truck>(id);

            if (truck!=null)
            {
                truck.Available = false;

                await repository.SaveChangesAsync();
            }
        }
    }
}
