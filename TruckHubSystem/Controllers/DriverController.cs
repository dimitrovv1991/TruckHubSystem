using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Driver;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class DriverController : Controller
    {
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DriverFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }
    }
}
