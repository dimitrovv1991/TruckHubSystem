using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Factory;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class FactoryController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllFactoriesQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new FactoryDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FactoryFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }
    }
}
