using System.ComponentModel.DataAnnotations;
using TruckHubSystem.Core.Enums;

namespace TruckHubSystem.Core.Models.Booking
{
    public class AllBookingsQueryModel
    {
        public int BookingsPerPage { get; } = 8;

        [Display(Name = "Search")]

        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Sort")]
        public BookingSorting Sorting { get; set; }

        [Display(Name = "Status")]

        public BookingStatus Status { get; set; }

        public int TotalBookingsCount { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<BookingDetailsFormModel> Bookings { get; set; } = new HashSet<BookingDetailsFormModel>();
    }
}
