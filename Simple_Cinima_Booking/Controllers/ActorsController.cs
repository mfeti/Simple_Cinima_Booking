using Microsoft.AspNetCore.Mvc;
using Simple_Cinima_Booking.Data.Services;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

		//Get Actor:Create
		public IActionResult Create()
		{
			return View();
		}
        //Post Actor:Create

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (actor.ProfilePictureUrl == null || actor.FullName == null || actor.Bio == null || actor.FullName.Length < 3 || actor.FullName.Length > 50)
            {
                if (!ModelState.IsValid)
                {
					return View(actor);
				}
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        

		//Get Actor:Details
		public async Task<IActionResult> Details(int id)
		{
            var actorDetails = await _service.GetByIdAsync(id);
            if(actorDetails == null)
            {
                return View("NotFound");
            }
			return View(actorDetails);
		}
		//Get Actor:Edit
		public async Task<IActionResult> Edit(int id)
		{
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null)
			{
				return View("NotFound");
			}
			return View(actorDetails);
		}
		//Post Actor:Edit

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
		{
			if (actor.ProfilePictureUrl == null || actor.FullName == null || actor.Bio == null || actor.FullName.Length < 3 || actor.FullName.Length > 50)
			{
				if (!ModelState.IsValid)
				{
					return View(actor);
				}
				return View(actor);
			}
			await _service.UpdateAsync(id, actor);
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
			var actorDetails = await _service.GetByIdAsync(id);
			if (actorDetails == null)
			{
				return View("NotFound");
			}
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

	}
}
