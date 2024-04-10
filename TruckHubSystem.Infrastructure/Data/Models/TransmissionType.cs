using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Truck transmission type")]
    public class TransmissionType
    {
        [Key]
        [Comment("TransmissionType Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TransmissionTypeNameMaxLength)]
        [Comment("Transmission type")]
        public string Name { get; set; } = string.Empty;

        public List<Truck> Trucks { get; set; } = new List<Truck>();
    }
}
