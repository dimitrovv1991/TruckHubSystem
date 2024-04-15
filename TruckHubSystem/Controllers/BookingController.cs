using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TruckHubSystem.Core.Contracts.Booking;
using TruckHubSystem.Core.Contracts.Driver;
using TruckHubSystem.Core.Contracts.Load;
using TruckHubSystem.Core.Contracts.Truck;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Factory;
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
        private readonly TruckHubDbContext data;


        public BookingController(ILoadService _loadService,
            ITruckService _truckService,
            IDriverService _driverService,
            IBookingService _bookingService,
            TruckHubDbContext _data)
        {
            loadService = _loadService;
            truckService = _truckService;
            driverService = _driverService;
            bookingService = _bookingService;
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllBookingsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookingSummary()
        {
            var selectedLoadId = (int)TempData["SelectedLoadId"];
            var selectedTruckId = (int)TempData["SelectedTruckId"];
            var selectedDriverId = (int)TempData["SelectedDriverId"];


            var loadTruckDriver = new List<int> { selectedLoadId, selectedTruckId, selectedDriverId};


            var selectedLoad = await loadService.SelectLoadById(selectedLoadId);
            var selectedTruck = await truckService.SelectedTruckById(selectedTruckId);
            var selectedDriver = await driverService.SelectedDriverById(selectedDriverId);

            var bookingModel = new BookingFormModel
            {
                LoadName = selectedLoad.Name,
                LoadingFactoryName = selectedLoad.FactoryName,
                LoadWeigth = selectedLoad.Weigth,
                TruckManufacturer = selectedTruck.Manufacturer,
                TruckImage = selectedTruck.ImageUrl,
                TruckPlateNumber = selectedTruck.LicensePlate,
                DriverFirstName = selectedDriver.FirstName,
                DriverLastName = selectedDriver.FamilyName,
                SelectedDriverId = selectedDriverId,
                SelectedLoadId = selectedLoadId,
                SelectedTruckId = selectedTruckId
            };

            return View(bookingModel);
        }


        [HttpPost]
        public async Task<IActionResult> BookingSummary(BookingFormModel bookingModel)
        {
            int selectedLoadId = bookingModel.SelectedLoadId;
            int selectedTruckId = bookingModel.SelectedTruckId;
            int selectedDriverId = bookingModel.SelectedDriverId;

            var selectedLoad = await loadService.SelectLoadById(selectedLoadId);
            var selectedTruck = await truckService.SelectedTruckById(selectedTruckId);
            var selectedDriver = await driverService.SelectedDriverById(selectedDriverId);
            
            await bookingService.CreateBookingAsync(selectedLoad, selectedTruck, selectedDriver);

            
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

            return RedirectToAction("BookingSummary");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var currentUserId = GetUserId();


            var bookings = await data.Bookings
               .Select(b => new BookingDetailsFormModel()
               {
                   DriverFirstName = b.Driver.FirstName,
                   DriverLastName = b.Driver.FamilyName,
                   LoadName = b.Load.Name,

               })
               .Where(b => b.CreatorId == currentUserId)
               .ToListAsync();

            return View(factories);
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
