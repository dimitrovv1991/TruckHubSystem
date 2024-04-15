using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Booking;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data.Common;

namespace TruckHubSystem.Core.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<Infrastructure.Data.Models.Booking> CreateBookingAsync(
            LoadDetailsViewModel selectedLoad, 
            TruckDetailsViewModel selectedTruck, 
            DriverDetailsViewModel selectedDriver)
        {
            var booking = new Infrastructure.Data.Models.Booking
            {
                DriverId = selectedDriver.Id,
                LoadId = selectedLoad.Id,
                TruckId = selectedTruck.Id,
                BookingStatusId = 1,
            };

            await repository.AddAsync(booking);
            await repository.SaveChangesAsync();

            return booking;
        }
    }
}
