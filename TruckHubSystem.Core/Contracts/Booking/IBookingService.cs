using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
