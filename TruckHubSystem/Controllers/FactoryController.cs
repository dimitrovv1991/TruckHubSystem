using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TruckHubSystem.Core.Services.Factory;
using TruckHubSystem.Core.Models.Factory;
using TruckHubSystem.Infrastructure.Data;
using TruckHubSystem.Infrastructure.Data.Models;
using TruckHubSystem.Core.Contracts.Factory;
using TruckHubSystem.Core.Models.Load;
using TruckHubSystem.Infrastructure.Data.Common;
using TruckHubSystem.Core.Services.Load;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using TruckHubSystem.Core.Contracts.Load;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class FactoryController : Controller
    {
        private readonly TruckHubDbContext data;
        private readonly IFactoryService factoryService;
        private readonly ILoadService loadService;

        public FactoryController(
            TruckHubDbContext context,
            IFactoryService _factoryService,
            ILoadService _loadService)
        {
            data = context;
            factoryService = _factoryService;
            loadService = _loadService;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var currentUserId = GetUserId();

           
             var factories = await data.Factories
                .Select(f => new FactoryDetailsViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location,
                    LoadsReceived = data.LoadsReceived.Count(l => l.FactoryId == f.Id),
                    LoadsSent = data.LoadsSent.Count(l => l.FactoryId == f.Id),
                    CurrentLoads = data.CurrentLoads.Count(l => l.FactoryId == f.Id),
                    CreatorId = f.CreatorId
                })
                .Where(f=>f.CreatorId==currentUserId)
                .ToListAsync();
            ;

            return View(factories);
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
                    LoadsReceived = data.LoadsReceived.Count(l => l.FactoryId == f.Id),
                    LoadsSent = data.LoadsSent.Count(l => l.FactoryId == f.Id),
                    CurrentLoads = data.CurrentLoads.Count(l=>l.FactoryId == f.Id)
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
        public IActionResult AddLoad(int factoryId)
        {
            var categories = GetCategories();

            var viewModel = new LoadFormModel
            {
                FactoryId = factoryId,
                LoadCategories = categories.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoad(LoadFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var loadToAdd = new Load
            {
                Name = model.Name,
                LoadCategoryId = model.LoadCategoryId,
                FactoryId = model.FactoryId,
                Weigth = model.Weigth
            };

            var currentFactory = data
                .Factories
                .FirstOrDefault(fi => fi.Id == loadToAdd.FactoryId);

            currentFactory.LoadsReceived.Add(loadToAdd);

            await data.Loads.AddAsync(loadToAdd);
            await data.SaveChangesAsync();

            var load = data.Loads.OrderByDescending(l => l.Id).FirstOrDefault();

            var loadReceived = new LoadReceived
            {
                LoadId = load.Id,
                FactoryId = load.FactoryId
            };

            loadService.AddLoadToCurrentLoads(load);

            //await data.LoadsReceived.AddAsync(loadReceived);
            // await data.SaveChangesAsync();

            return RedirectToAction("Mine", "Factory");
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
            string currentUserId = GetUserId();

            var factoryToAdd = new Factory()
            {
                Name = model.Name,
                Location = model.Location,
                CreatorId = currentUserId
            };

            await data.Factories.AddAsync(factoryToAdd);
            await data.SaveChangesAsync();

            return RedirectToAction("Mine", "Factory");
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public ICollection<LoadCategoryServiceModel> GetCategories()
        {
            return data.LoadCategories
                .Select(c => new LoadCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }
    }
}
