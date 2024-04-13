using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Contracts.Driver;
using TruckHubSystem.Core.Contracts.Load;
using TruckHubSystem.Core.Contracts.Truck;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Infrastructure.Data;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ILoadService loadService;
        private readonly ITruckService truckService;
        private readonly IDriverService driverService;
        private readonly TruckHubDbContext data;


        public BookingController(ILoadService _loadService,
            ITruckService _truckService,
            IDriverService _driverService,
            TruckHubDbContext _data)
        {
            loadService = _loadService;
            truckService = _truckService;
            driverService = _driverService;
            data = _data;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllBookingsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BookingSummary(int id)
        {
            var selectedLoadId = (int)TempData["SelectedLoadId"];
            var selectedTruckId = (int)TempData["SelectedTruckId"];
            var selectedDriverId = (int)TempData["SelectedDriverId"];


            var loadTruckDriver = new List<int> { selectedLoadId, selectedTruckId, selectedDriverId};


            var selectedLoad = await loadService.SelectLoadById(selectedLoadId);
            var selectedTruck = await truckService.SelectedTruckById(selectedTruckId);
            var selectedDriver = await driverService.SelectedDriverById(selectedDriverId);

            var bookingModel = new BookingDetailsFormModel
            {
                LoadName = selectedLoad.Name,
                LoadingFactoryName = selectedLoad.FactoryName,
                LoadWeigth = selectedLoad.Weigth,
                TruckManufacturer = selectedTruck.Manufacturer,
                TruckImage = selectedTruck.ImageUrl,
                TruckPlateNumber = selectedTruck.LicensePlate,
                DriverFirstName = selectedDriver.FirstName,
                DriverLastName = selectedDriver.FamilyName
            };

            return View(bookingModel);
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
            var loads = await loadService.AllAvailableLoadsAsync();

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
    }
}
