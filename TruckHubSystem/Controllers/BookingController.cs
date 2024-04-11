using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TruckHubSystem.Core.Models.Booking;

namespace TruckHubSystem.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllBookingsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details (int id)
        {
            var model = new BookingDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookingFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }



    }
}
