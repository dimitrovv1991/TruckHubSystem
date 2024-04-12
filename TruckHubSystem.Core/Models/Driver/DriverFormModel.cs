using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Infrastructure.Attributes;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;
using static TruckHubSystem.Infrastructure.Constants.Messages;

namespace TruckHubSystem.Core.Models.Driver
{
    public class DriverFormModel
    {
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
    }
}
