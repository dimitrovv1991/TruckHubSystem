using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Infrastructure.Attributes;
using TruckHubSystem.Infrastructure.Data.Models;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;
using static TruckHubSystem.Infrastructure.Constants.Messages;

namespace TruckHubSystem.Core.Models.Truck
{
    public class TruckFormModel
    {
        [Required]
        [StringLength(TruckManufacturerNameMaxLength, MinimumLength = TruckManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(TruckManufacturerNameMaxLength, MinimumLength = TruckModelNameMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [YearRange(YearManufacturedMin, ErrorMessage = YearErrorMessage)]
        public int YearManufactured { get; set; }

        [Required]
        [StringLength(TruckLicensePlateMaxLength, MinimumLength = TruckLicensePlateMinLength)]
        public string LicensePlate { get; set; } = null!;

        [Required]
        [Range(LoadWeigthMinKg, LoadWeightMaxKg, ErrorMessage = LoadWeightErrorMessage)]
        public int CapacityKg { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public bool Available { get; set; } = true;

    }
}
