using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TruckHubSystem.Core.Models.Truck;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Models;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class TruckController : Controller
    {
        private readonly TruckHubDbContext data;

        public TruckController(TruckHubDbContext context)
        {
            data = context;
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var trucksToDisplay = await data
                .Trucks
                .Select(t => new TruckDetailsViewModel()
                {
                    Id = t.Id,
                    Model = t.Model,
                    Manufacturer = t.Manufacturer,
                    CapacityKg = t.CapacityKg,
                    LicensePlate = t.LicensePlate,
                    Available = t.Available,
                    ImageUrl = t.ImageUrl
                })
                .ToListAsync();

            return View(trucksToDisplay);
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
            TruckFormModel truckModel = new TruckFormModel();
            return View(truckModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TruckFormModel truckModel)
        {
            if (!ModelState.IsValid)
            {
                return View(truckModel);
            }

            var truckToAdd = new Truck()
            {
                Manufacturer = truckModel.Manufacturer,
                Model = truckModel.Model,
                LicensePlate = truckModel.LicensePlate,
                YearManufactured = truckModel.YearManufactured,
                CapacityKg = truckModel.CapacityKg,
                Available = truckModel.Available,
                ImageUrl = truckModel.ImageUrl                 
            };

            await data.Trucks.AddAsync(truckToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Truck");
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
