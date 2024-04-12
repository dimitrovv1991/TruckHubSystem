using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TruckHubSystem.Infrastructure.Attributes;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;
using static TruckHubSystem.Infrastructure.Constants.Messages;



namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Truck")]
    public class Truck
    {
        [Key]
        [Comment("Truck Identifier")]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(TruckManufacturerNameMaxLength)]
        [Comment("Manufactrurer")]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(TruckModelNameMaxLength)]
        [Comment("Model")]
        public string Model { get; set; } = null!;

        [Required]
        [YearRange(YearManufacturedMin, ErrorMessage = YearErrorMessage)]
        [Comment("Year manufactured")]
        public int YearManufactured { get; set; }

        [Required]
        [MaxLength(TruckLicensePlateMaxLength)]
        [Comment("License plate number")]
        public string LicensePlate { get; set;} = null!;

        [Required]
        [Comment("Capacity in kilograms")]
        public int CapacityKg {  get; set; }

        [Required]
        [Comment("Truck image url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Is truck available")]
        public bool Available { get; set; } = true;
    }
}
