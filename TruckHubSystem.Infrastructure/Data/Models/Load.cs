using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;
using static TruckHubSystem.Infrastructure.Constants.Messages;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Load")]
    public class Load
    {
        [Key]
        [Comment("Load identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(LoadNameMaxLength)]
        [Comment("Load name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(LoadWeigthMinKg, LoadWeightMaxKg, ErrorMessage = LoadWeightErrorMessage)]
        [Comment("Load weight")]
        public int Weigth { get; set;}

        [Required]
        public int LoadCategoryId { get; set; }

        [ForeignKey(nameof(LoadCategoryId))]
        public LoadCategory LoadCategory { get; set; } = null!;

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("City of loading the goods")]
        public string LoadingCity { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment("City of unloading the goods")]
        public string DestinationCity { get; set; } = string.Empty;

        [Required]
        public int LoadingFactoryId { get; set; }

        [ForeignKey(nameof(LoadingFactoryId))]
        public Factory LoadingFactory {  get; set; } = null!;

        [Required]
        public int UnloadingFactoryId { get; set; }

        [ForeignKey(nameof(UnloadingFactoryId))]
        public Factory UnloadingFactory { get; set; } = null!;

        [Required]
        [Range(MinDistanceInKm,MaxDistanceInKm, ErrorMessage = CityDistanceError)]
        [Comment("Distance between the cities")]
        public int DistanceInKm { get; set; }

        [Required]
        [Range(typeof(decimal), MinimumLoadPrice, MaximumLoadPrice, ConvertValueInInvariantCulture = true)]
        [Comment("Load price")]
        public decimal Price { get; set; }
    }
}
