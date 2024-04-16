using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Booking")]
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Truck identifier")]
        public int TruckId { get; set; }

        [ForeignKey(nameof(TruckId))]
        public Truck Truck { get; set; } = null!;


        [Required]
        [Comment("Load identifier")]
        public int LoadId { get; set; }

        [ForeignKey(nameof(LoadId))]
        public Load Load { get; set; } = null!;

        [Required]
        [Comment("Driver identifier")]
        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; } = null!;

        [Required]
        [Comment("Booking status identifier")]
        public int BookingStatusId {  get; set; }

        [ForeignKey(nameof(BookingStatusId))]
        public BookingStatus BookingStatus { get; set; } = null!;


        [MaxLength(BookingNotesMaxLength)]
        public string Notes { get; set; } = string.Empty;
    }
}
