using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Truck;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllTrucksQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new TruckDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TruckFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }
    }
}
