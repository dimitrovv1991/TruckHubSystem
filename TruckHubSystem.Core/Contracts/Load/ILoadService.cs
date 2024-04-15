using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;

namespace TruckHubSystem.Core.Contracts.Load
{
    public interface ILoadService
    {
        Task<IEnumerable<LoadDetailsViewModel>> AllAvailableLoadsAsync();

        Task<IEnumerable<LoadDetailsViewModel>> AllAvailableLoadsFromOtherUsersFactories(string id);

        Task<LoadDetailsViewModel> SelectLoadById(int id);
    }
}
