using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Infrastructure.Constants;

namespace TruckHubSystem.Core.Models.Load
{
    public class LoadDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
                
        public int Weigth { get; set; }

        public string LoadCategoryName { get; set; }

        public string FactoryName { get; set; }

        public int FactoryId {  get; set; }

        public List<LoadCategoryServiceModel> LoadCategories { get; set; } = new List<LoadCategoryServiceModel>();
    }
}
