using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Models.Driver;
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
            string creator);
    }
}
