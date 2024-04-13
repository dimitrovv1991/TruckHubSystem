using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Infrastructure.Constants;

namespace TruckHubSystem.Core.Models.Load
{
    public class LoadFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(DataConstants.LoadNameMaxLength, ErrorMessage = "The Name field must be at most {1} characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Weight field is required.")]
        [Range(DataConstants.LoadWeigthMinKg, DataConstants.LoadWeightMaxKg, ErrorMessage = "The Weight field must be between {1} and {2} kg.")]
        public int Weigth { get; set; }

        [Required(ErrorMessage = "The Load Category field is required.")]
        public int LoadCategoryId { get; set; }

        [Required(ErrorMessage = "The Factory field is required.")]
        public int FactoryId { get; set; }

        public List<LoadCategoryServiceModel> LoadCategories { get; set; } = new List<LoadCategoryServiceModel>();

    }
}
