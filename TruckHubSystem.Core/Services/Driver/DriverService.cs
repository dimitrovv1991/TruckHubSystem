using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Driver;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Infrastructure.Data.Common;

namespace TruckHubSystem.Core.Services.Driver
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repository;

        public DriverService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<DriverDetailsViewModel>> AllAvailableDriversAsync()
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Driver>()
                .Select(d => new DriverDetailsViewModel()
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    FamilyName = d.FamilyName,
                    PhoneNumber = d.PhoneNumber,
                    YearDrivingLicenseAcquired = d.YearDrivingLicenseAcquired,
                    IsDriverAvailable = d.IsDriverAvailable                    
                })
                .ToListAsync();
        }

        public async Task DriverAvailable(int id)
        {
            Infrastructure.Data.Models.Driver driver =
                await repository.GetByIdAsync<Infrastructure.Data.Models.Driver>(id);

            if (driver != null)
            {
                driver.IsDriverAvailable = true;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DriverNotAvailable(int id)
        {
            Infrastructure.Data.Models.Driver driver = 
                await repository.GetByIdAsync<Infrastructure.Data.Models.Driver>(id);

            if (driver != null)
            {
                driver.IsDriverAvailable = false;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<DriverDetailsViewModel> SelectedDriverById(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Driver>()
                .Where(d=>d.Id == id)
                .Select(d => new DriverDetailsViewModel()
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    FamilyName = d.FamilyName,
                    PhoneNumber = d.PhoneNumber,
                    YearDrivingLicenseAcquired = d.YearDrivingLicenseAcquired
                })
                .FirstAsync();
        }
    }
}
