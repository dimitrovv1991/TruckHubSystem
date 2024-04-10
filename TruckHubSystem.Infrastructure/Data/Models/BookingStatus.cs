using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TruckHubSystem.Infrastructure.Constants.DataConstants;

namespace TruckHubSystem.Infrastructure.Data.Models
{
    [Comment("Booking status")]
    public class BookingStatus
    {
        [Key]
        [Comment("Booking status indentifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookingStatusNameMaxLength)]
        [Comment("Booking status")]
        public string Name { get; set; } = string.Empty;


        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
