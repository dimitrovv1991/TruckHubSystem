using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Booking;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Core.Models.Factory;
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

        public async Task BookingReceived(int id)
        {
            var booking = await repository.GetByIdAsync<Infrastructure.Data.Models.Booking>(id);

            if (booking!=null)
            {
                booking.BookingStatusId = 2;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<Infrastructure.Data.Models.Booking> CreateBookingAsync(
            LoadDetailsViewModel selectedLoad, 
            TruckDetailsViewModel selectedTruck, 
            DriverDetailsViewModel selectedDriver,
            FactoryDetailsViewModel selectedFactory,
            string creator)
        {
            var booking = new Infrastructure.Data.Models.Booking
            {
                BookingCreatorId = creator,
                DriverId = selectedDriver.Id,
                LoadId = selectedLoad.Id,
                TruckId = selectedTruck.Id,
                ReceivingFactoryId = selectedFactory.Id,
                BookingStatusId = 1,
            };
            ;

            await repository.AddAsync(booking);
            await repository.SaveChangesAsync();

            return booking;
        }

        public async Task<BookingFormModel> CreateBookingSummaryModel(
            LoadDetailsViewModel selectedLoad, 
            TruckDetailsViewModel selectedTruck,
            DriverDetailsViewModel selectedDriver,
            FactoryDetailsViewModel selectedFactory)
        {
            BookingFormModel bookingModel = new BookingFormModel
            {
                LoadName = selectedLoad.Name,
                LoadingFactoryName = selectedLoad.FactoryName,
                LoadWeigth = selectedLoad.Weigth,
                TruckManufacturer = selectedTruck.Manufacturer,
                TruckImage = selectedTruck.ImageUrl,
                TruckPlateNumber = selectedTruck.LicensePlate,
                DriverFirstName = selectedDriver.FirstName,
                DriverLastName = selectedDriver.FamilyName,
                FactoryName = selectedFactory.Name,
                FactoryLocation = selectedFactory.Location,
                SelectedFactoryId = selectedFactory.Id,
                SelectedDriverId = selectedDriver.Id,
                SelectedLoadId = selectedLoad.Id,
                SelectedTruckId = selectedTruck.Id
            };

            return bookingModel;
        }

        public async Task<IEnumerable<BookingDetailsFormModel>> GetMyActiveBookings(string currentUserId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Booking>()
               .Select(b => new BookingDetailsFormModel()
               {
                   Id = b.Id,
                   BookingCreatorId = b.BookingCreatorId,
                   DriverFirstName = b.Driver.FirstName,
                   DriverLastName = b.Driver.FamilyName,
                   TruckPlateNumber = b.Truck.LicensePlate,
                   LoadingFactoryName = b.Load.Factory.Name,
                   LoadingCityName = b.Load.Factory.Location,
                   LoadName = b.Load.Name,
                   LoadWeigth = b.Load.Weigth,
                   BookingStatusId = b.BookingStatusId,
                   ReceivingFactoryId = b.ReceivingFactoryId,
                   ReceivingFactoryCityName = b.ReceivingFactory.Location,
                   ReceivingFactoryName = b.ReceivingFactory.Name
               })
               .Where(b => b.BookingCreatorId == currentUserId)
               .ToListAsync();
        }

        public async Task<BookingDetailsFormModel> SelectBookingById(int id)
        {
            var booking = await repository.GetByIdAsync<Infrastructure.Data.Models.Booking>(id);


            var bookingDetails = new BookingDetailsFormModel
            {
                TruckPlateNumber = booking.Truck.LicensePlate,
                LoadName = booking.Load.Name,
                LoadWeigth = booking.Load.Weigth
            };


            return bookingDetails;
        }
    }
}
