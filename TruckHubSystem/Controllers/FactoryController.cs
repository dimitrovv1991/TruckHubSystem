using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckHubSystem.Core.Models.Booking;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class FactoryController : Controller
    {
        private readonly TruckHubDbContext data;

        public FactoryController(TruckHubDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var factoriesToDisplay = await data
                .Factories
                .Select(f => new FactoryDetailsViewModel()
                {
                    Name = f.Name,
                    Location = f.Location,
                    LoadsReceived = f.LoadsReceived.Count(),
                    LoadsSent = f.LoadsSent.Count()
                })
                .ToListAsync();

            return View(factoriesToDisplay);
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
            FactoryFormModel factoryModel = new FactoryFormModel();
            return View(factoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FactoryFormModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var factoryToAdd = new Factory()
            {
                Name = model.Name,
                Location = model.Location,
            };

            await data.Factories.AddAsync(factoryToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Factory");
        }
    }
}
