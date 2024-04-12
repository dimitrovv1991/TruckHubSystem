using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TruckHubSystem.Core.Contracts.Factory;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Infrastructure.Data;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class LoadController : Controller
    {
        private readonly TruckHubDbContext data;
        private readonly IFactoryService factoryService;

        public LoadController(TruckHubDbContext context,
            IFactoryService _factoryService)
        {
            data = context;
            factoryService = _factoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var currentUserId = GetUserId();

            IEnumerable<FactoryDetailsViewModel> factories;

            factories = await factoryService.AllFactoriesByUserIdAsync(currentUserId);

            return View(factories);
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
            LoadFormModel loadModel = new LoadFormModel();
            return View(loadModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LoadFormModel loadModel)
        {
            if (ModelState.IsValid)
            {
                return View(loadModel);
            }


            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
