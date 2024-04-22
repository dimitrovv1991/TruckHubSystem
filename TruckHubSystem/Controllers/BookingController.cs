using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TruckHubSystem.Core.Contracts.Booking;
using TruckHubSystem.Core.Contracts.Driver;
using TruckHubSystem.Core.Contracts.Factory;
using TruckHubSystem.Core.Contracts.Load;
using TruckHubSystem.Core.Contracts.Truck;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Core.Services.Factory;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ILoadService loadService;
        private readonly ITruckService truckService;
        private readonly IDriverService driverService;
        private readonly IBookingService bookingService;
        private readonly IFactoryService factoryService;
        private readonly TruckHubDbContext data;


        public BookingController(ILoadService _loadService,
            ITruckService _truckService,
            IDriverService _driverService,
            IBookingService _bookingService,
            IFactoryService _factoryService,
            TruckHubDbContext _data)
        {
            loadService = _loadService;
            truckService = _truckService;
            driverService = _driverService;
            bookingService = _bookingService;
            factoryService = _factoryService;
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllBookingsQueryModel model)
        {
            var allBookings = await bookingService.AllAsync(
                model.SearchTerm,
                model.Sorting,
                model.Status,
                model.CurrentPage,
                model.BookingsPerPage
                );

            model.TotalBookingsCount = allBookings.TotalBookingsCount;

            model.Bookings = allBookings.Bookings;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookingSummary()
        {
            var selectedLoadId = (int)TempData["SelectedLoadId"];
            var selectedTruckId = (int)TempData["SelectedTruckId"];
            var selectedDriverId = (int)TempData["SelectedDriverId"];
            var selectedFactoryId = (int)TempData["SelectedFactoryId"];


            var selectedLoad = await loadService.SelectLoadById(selectedLoadId);
            var selectedTruck = await truckService.SelectedTruckById(selectedTruckId);
            var selectedDriver = await driverService.SelectedDriverById(selectedDriverId);
            var selectedFactory = await factoryService.SelectedFactoryById(selectedFactoryId);

            ;

            var bookingModel = 
                await bookingService.CreateBookingSummaryModel(
                    selectedLoad, selectedTruck, selectedDriver, selectedFactory);
            var currentUserFactories =  await data.Factories.Where(f => f.CreatorId == GetUserId()).ToListAsync();

            ViewBag.UserFactories = currentUserFactories;

            return View(bookingModel);
        }


        [HttpPost]
        public async Task<IActionResult> BookingSummary(BookingFormModel bookingModel)
        {
            int selectedLoadId = bookingModel.SelectedLoadId;
            int selectedTruckId = bookingModel.SelectedTruckId;
            int selectedDriverId = bookingModel.SelectedDriverId;
            int selectedFactoryId = bookingModel.SelectedFactoryId;

            var selectedLoad = await loadService.SelectLoadById(selectedLoadId);
            var selectedTruck = await truckService.SelectedTruckById(selectedTruckId);
            var selectedDriver = await driverService.SelectedDriverById(selectedDriverId);
            var selectedFactory = await factoryService.SelectedFactoryById(selectedFactoryId);

            var currentUserId = GetUserId();
            await truckService.TruckNotAvailable(selectedTruckId);
            await loadService.LoadNotAvailable(selectedLoadId);
            await driverService.DriverNotAvailable(selectedDriverId);


            await factoryService.AddSentLoadToTheOriginFactory(selectedLoad);
            await bookingService.CreateBookingAsync(
                selectedLoad, selectedTruck, selectedDriver, selectedFactory, currentUserId);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingFormModel model)
        {
            return RedirectToAction(nameof(BookingSummary), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> SelectFactory()
        {
            var currentUserId = GetUserId();


            var factories = await data.Factories
               .Select(f => new FactoryDetailsViewModel()
               {
                   Id = f.Id,
                   Name = f.Name,
                   Location = f.Location,
                   CreatorId = f.CreatorId
               })
               .Where(f => f.CreatorId == currentUserId)
               .ToListAsync();
            ;

            return View(factories);
        }

        [HttpPost]
        public async Task<IActionResult> SelectFactory(int selectedFactoryId)
        {
            TempData["SelectedFactoryId"] = selectedFactoryId;

            return RedirectToAction("SelectLoad");
        }

        [HttpGet]
        public async Task<IActionResult> SelectLoad ()
        {
            var userId = GetUserId();

            var loads = await loadService.AllAvailableLoadsFromOtherUsersFactories(userId);

            return View(loads);
        }

        [HttpPost]
        public async Task<IActionResult> SelectLoad(int selectedLoadId)
        {
            TempData["SelectedLoadId"] = selectedLoadId;
            TempData.Keep("SelectedFactoryId");

            return RedirectToAction("SelectTruck");
        }

        [HttpGet]
        public async Task<IActionResult> SelectTruck()
        {
            var trucks = await truckService.AllAvailableTrucksAsync();

            return View(trucks);
        }

        [HttpPost]
        public async Task<IActionResult> SelectTruck(int selectedTruckId)
        {
            TempData["SelectedTruckId"] = selectedTruckId;
            TempData.Keep("SelectedFactoryId");
            TempData.Keep("SelectedLoadId");
            return RedirectToAction("SelectDriver");
        }

        [HttpGet]
        public async Task<IActionResult> SelectDriver()
        {
            var drivers = await driverService.AllAvailableDriversAsync();

            return View(drivers);
        }

        [HttpPost]
        public async Task<IActionResult> SelectDriver(int selectedDriverId)
        {
            TempData["SelectedDriverId"] = selectedDriverId;
            TempData.Keep("SelectedLoadId");
            TempData.Keep("SelectedTruckId");
            TempData.Keep("SelectedFactoryId");

            return RedirectToAction("BookingSummary");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var bookings = await bookingService.GetMyActiveBookings(GetUserId());

            return View(bookings);
        }

        public async Task<IActionResult> Receive(int id)
        {
            var booking = await data.Bookings
                .Select(b=> new BookingDetailsFormModel
                {
                    Id=b.Id,
                    TruckPlateNumber = b.Truck.LicensePlate,
                    LoadName = b.Load.Name,
                    LoadWeigth = b.Load.Weigth
                })
                .Where(b=>b.Id == id)
                .FirstAsync();

            

            return View(booking);
        }

        public async Task<IActionResult> ReceiveConfirmed(int id)
        {
            var currentBooking = data.Bookings.FirstOrDefault(b => b.Id == id);

            await bookingService.BookingReceived(id);
            await truckService.TruckAvailable(currentBooking.TruckId);
            await driverService.DriverAvailable(currentBooking.DriverId);
            await factoryService.DeleteSentLoadFromTheOriginFactory(currentBooking.LoadId);
            await factoryService.AddReceivedLoad(currentBooking.LoadId, currentBooking.ReceivingFactoryId);

            return RedirectToAction("Mine");
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
