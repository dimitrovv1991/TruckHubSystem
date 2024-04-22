using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Enums;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;

namespace TruckHubSystem.Core.Contracts.Booking
{
    public interface IBookingService
    {
        public Task<Infrastructure.Data.Models.Booking> CreateBookingAsync(
            LoadDetailsViewModel selectedLoad,
            TruckDetailsViewModel selectedTruck,
            DriverDetailsViewModel selectedDriver,
            FactoryDetailsViewModel selectedFactory,
            string creator);

        public Task<AllBookingsQueryModel> AllAsync(
            string search = null,
            BookingSorting sorting = BookingSorting.Newest,
            BookingStatus status = BookingStatus.All,
            int currentPage = 1,
            int bookingsPerPage = 8);
        public Task BookingReceived(int id);

        public Task<BookingDetailsFormModel> SelectBookingById(int id);

        public Task<BookingFormModel> CreateBookingSummaryModel(
            LoadDetailsViewModel selectedLoad,
            TruckDetailsViewModel selectedTruck,
            DriverDetailsViewModel selectedDriver,
            FactoryDetailsViewModel selectedFactory);

        public Task<IEnumerable<BookingDetailsFormModel>> GetMyActiveBookings(string currentUserId);
    }
}
