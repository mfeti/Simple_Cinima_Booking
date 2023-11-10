using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Cinima_Booking.Data;
using Simple_Cinima_Booking.Data.Services;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducer = await _service.GetAllAsync();
            return View(allProducer);
        }
		//Get Actor:Create
		public IActionResult Create()
		{
			return View();
		}
		//Post Actor:Create

		[HttpPost]
		public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
		{
			if (producer.ProfilePictureUrl == null || producer.FullName == null || producer.Bio == null || producer.FullName.Length < 3 || producer.FullName.Length > 50)
			{
				if (!ModelState.IsValid)
				{
					return View(producer);
				}
				return View(producer);
			}
			await _service.AddAsync(producer);
			return RedirectToAction(nameof(Index));
		}


		//Get Actor:Details
		public async Task<IActionResult> Details(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null)
			{
				return View("NotFound");
			}
			return View(producerDetails);
		}
		//Get Actor:Edit
		public async Task<IActionResult> Edit(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null)
			{
				return View("NotFound");
			}
			return View(producerDetails);
		}
		//Post Producer:Edit

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer producer)
		{
			if( producer.ProfilePictureUrl == null || producer.FullName == null || producer.Bio == null || producer.FullName.Length < 3 || producer.FullName.Length > 50)
			{
				if (!ModelState.IsValid)
				{
					return View(producer);
				}
				return View(producer);
			}
			await _service.UpdateAsync(id, producer);
			return RedirectToAction(nameof(Index));
		}
		//Get Actor:Delete
		public async Task<IActionResult> Delete(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null)
			{
				return View("NotFound");
			}
			return View(actorDetails);
		}
		//Post Actor:Delete

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmation(int id)
		{
			var producerDetails = await _service.GetByIdAsync(id);
			if (producerDetails == null)
			{
				return View("NotFound");
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
