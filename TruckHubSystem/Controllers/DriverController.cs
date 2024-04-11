using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Driver;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
        private readonly TruckHubDbContext data;

        public DriverController(TruckHubDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllDriversQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new DriverDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            DriverFormModel driverModel = new DriverFormModel();
            return View(driverModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DriverFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var driverToAdd = new Driver()
            {
                FirstName = model.FirstName,
                FamilyName = model.FamilyName,
                PhoneNumber = model.PhoneNumber,
                YearDrivingLicenseAcquired = model.YearDrivingLicenseAcquired
            };

            await data.Drivers.AddAsync(driverToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Driver");
        }
    }
}
