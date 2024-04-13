using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> All(int page=1)
        {
            var currentUserId = GetUserId();
            int pageSize = 8;

            IEnumerable<LoadDetailsViewModel> loads;

            loads = await data
                .Loads
                .Select(l => new LoadDetailsViewModel()
                {
                    Id = l.Id,
                    FactoryName = l.Factory.Name,
                    LoadCategoryName = l.LoadCategory.Name,
                    Name = l.Name,
                    Weigth = l.Weigth
                })
            .ToListAsync();

            ViewBag.PageNumber = page;

            var paginatedLoads = loads.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return View(paginatedLoads);
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
