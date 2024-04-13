using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Core.Models.Truck;

namespace TruckHubSystem.Core.Contracts.Driver
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDetailsViewModel>> AllAvailableDriversAsync();

        Task<DriverDetailsViewModel> SelectedDriverById(int id);
    }
}
