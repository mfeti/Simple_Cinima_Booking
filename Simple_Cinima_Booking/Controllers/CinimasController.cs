using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Cinima_Booking.Data;
using Simple_Cinima_Booking.Data.Services;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Controllers
{
    public class CinimasController : Controller
    {
        private readonly ICinimasService _service;
        public CinimasController(ICinimasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinimas = await _service.GetAllAsync();
            return View(allCinimas);
        }
		//Get Actor:Create
		public IActionResult Create()
		{
			return View();
		}
		//Post Actor:Create

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinima cinima)
		{
			if (cinima.Logo == null || cinima.Name == null || cinima.Description == null || cinima.Name.Length < 3 || cinima.Name.Length > 50)
			{
				if (!ModelState.IsValid)
				{
					return View(cinima);
				}
				return View(cinima);
			}
			await _service.AddAsync(cinima);
			return RedirectToAction(nameof(Index));
		}


		//Get Actor:Details
		public async Task<IActionResult> Details(int id)
		{
			var cinimaDetails = await _service.GetByIdAsync(id);
			if (cinimaDetails == null)
			{
				return View("NotFound");
			}
			return View(cinimaDetails);
		}
		//Get Actor:Edit
		public async Task<IActionResult> Edit(int id)
		{
			var cinimaDetails = await _service.GetByIdAsync(id);
			if (cinimaDetails == null)
			{
				return View("NotFound");
			}
			return View(cinimaDetails);
		}
		//Post Producer:Edit

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo,Description")] Cinima cinima)
		{
			if (cinima.Logo == null || cinima.Name == null || cinima.Description == null || cinima.Name.Length < 3 || cinima.Name.Length > 50)
			{
				if (!ModelState.IsValid)
				{
					return View(cinima);
				}
				return View(cinima);
			}
			await _service.UpdateAsync(id, cinima);
			return RedirectToAction(nameof(Index));
		}
		//Get Actor:Delete
		public async Task<IActionResult> Delete(int id)
		{
			var cinimaDetails = await _service.GetByIdAsync(id);
			if (cinimaDetails == null)
			{
				return View("NotFound");
			}
			return View(cinimaDetails);
		}
		//Post Actor:Delete

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmation(int id)
		{
			var cinimaDetails = await _service.GetByIdAsync(id);
			if (cinimaDetails == null)
			{
				return View("NotFound");
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
