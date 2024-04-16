using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Core.Models.Load;

namespace TruckHubSystem.Core.Contracts.Factory
{
    public interface IFactoryService
    {
        Task<IEnumerable<FactoryDetailsViewModel>> AllFactoriesByUserIdAsync(string userId);

        Task<IEnumerable<LoadCategoryServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        ICollection<LoadCategoryServiceModel> GetCategories();
        Task AddSentLoadToTheOriginFactory(LoadDetailsViewModel load);
    }
}
