using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Infrastructure.Attributes;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;
using static TruckHubSystem.Infrastructure.Constants.Messages;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Driver")]
    public class Driver
    {
        [Key]
        [Comment("Driver identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DriverNameMaxLength)]
        [Comment("Driver's first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(DriverNameMaxLength)]
        [Comment("Driver's family name")]
        public string FamilyName { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Driver's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required]
        [YearRange(MinYearDrivingLicenceAcquired, ErrorMessage = YearErrorMessage)]
        public int YearDrivingLicenseAcquired { get; set; }

        [Required]
        [Comment("Is driver available")]
        public bool IsDriverAvailable { get; set; } = true;
    }
}
