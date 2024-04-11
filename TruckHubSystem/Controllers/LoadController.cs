using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Load;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class LoadController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllLoadsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new LoadDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(LoadFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }
    }
}
