using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Models.Truck;

namespace TruckHubSystem.Core.Contracts.Truck
{
    public interface ITruckService
    {
        Task<IEnumerable<TruckDetailsViewModel>> AllAvailableTrucksAsync();

        Task<TruckDetailsViewModel> SelectedTruckById(int id);

        Task TruckNotAvailable(int id);
        Task TruckAvailable(int id);

    }
}
