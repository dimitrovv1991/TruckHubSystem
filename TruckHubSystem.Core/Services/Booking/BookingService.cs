using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TruckHubSystem.Core.Contracts.Booking;
using TruckHubSystem.Core.Enums;
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

        public async Task<AllBookingsQueryModel> AllAsync(
            string search = null, 
            BookingSorting sorting = BookingSorting.Newest, 
            BookingStatus status = BookingStatus.All,
            int currentPage = 1, 
            int bookingsPerPage = 8)
        {
            if (currentPage < 1)
            {
                currentPage = 1;
            }

            if (bookingsPerPage <= 0)
            {
                bookingsPerPage = 8;
            }


            var allBookings = repository.AllReadOnly<Infrastructure.Data.Models.Booking>();

            if (status == BookingStatus.InProgress)
            {
                allBookings = allBookings
                    .Where(b => b.BookingStatusId == 1);
            }
            else if (status == BookingStatus.Finished)
            {
                allBookings = allBookings
                    .Where(b => b.BookingStatusId == 2);
            }

            if (search!=null)
            {
                string normalizedSearchTerm = search.ToLower();

                allBookings = allBookings
                .Where(b => normalizedSearchTerm.Contains(b.Load.Name.ToLower())
                || normalizedSearchTerm.Contains(b.Load.Factory.Location.ToLower())
                || normalizedSearchTerm.Contains(b.Load.Factory.Name.ToLower())
                || normalizedSearchTerm.Contains(b.ReceivingFactory.Location.ToLower())
                || normalizedSearchTerm.Contains(b.ReceivingFactory.Name.ToLower())
                || normalizedSearchTerm.Contains(b.Truck.LicensePlate.ToLower())
                || normalizedSearchTerm.Contains(b.Driver.FirstName.ToLower())
                || normalizedSearchTerm.Contains(b.Driver.FamilyName.ToLower())


                || b.Load.Name.ToLower().Contains(normalizedSearchTerm)
                || b.Load.Factory.Location.ToLower().Contains(normalizedSearchTerm)
                || b.Load.Factory.Name.ToLower().Contains(normalizedSearchTerm)
                || b.ReceivingFactory.Location.ToLower().Contains(normalizedSearchTerm)
                || b.ReceivingFactory.Name.ToLower().Contains(normalizedSearchTerm)
                || b.Truck.LicensePlate.ToLower().Contains(normalizedSearchTerm)
                || b.Driver.FirstName.ToLower().Contains(normalizedSearchTerm)
                || b.Driver.FamilyName.ToLower().Contains(normalizedSearchTerm));
            }

            allBookings = sorting switch
            {
                BookingSorting.Oldest => allBookings.OrderBy(b => b.Id),
                BookingSorting.Newest => allBookings.OrderByDescending(b=>b.Id)
            };

            var bookings = await allBookings
                .Skip((currentPage - 1) * bookingsPerPage)
                .Take(bookingsPerPage)
                .Select(b => new BookingDetailsFormModel()
                {
                    Id = b.Id,
                    BookingCreatorId = b.BookingCreatorId,
                    BookingStatusId = b.BookingStatusId,
                    DriverFirstName = b.Driver.FirstName,
                    DriverLastName = b.Driver.FamilyName,
                    LoadingCityName = b.Load.Factory.Location,
                    LoadingFactoryName = b.Load.Factory.Name,
                    LoadName = b.Load.Name,
                    LoadWeigth = b.Load.Weigth,
                    ReceivingFactoryCityName = b.ReceivingFactory.Location,
                    ReceivingFactoryId = b.ReceivingFactory.Id,
                    ReceivingFactoryName = b.ReceivingFactory.Name,
                    TruckImage = b.Truck.ImageUrl,
                    TruckManufacturer = b.Truck.Manufacturer,
                    TruckPlateNumber = b.Truck.LicensePlate
                })
                .ToListAsync();

            int totalBookings = await allBookings.CountAsync();

            return new AllBookingsQueryModel()
            {
                Bookings = bookings,
                TotalBookingsCount = totalBookings
            };
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
