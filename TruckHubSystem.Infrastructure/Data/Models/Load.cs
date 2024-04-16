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
        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Factory Factory {  get; set; } = null!;

        [Required]
        [Comment("Is load available")]
        public bool IsLoadAvailable { get; set; } = true;
    }
}
