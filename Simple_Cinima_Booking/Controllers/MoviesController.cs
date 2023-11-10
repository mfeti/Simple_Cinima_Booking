using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Simple_Cinima_Booking.Data.Services;
using Simple_Cinima_Booking.Data.ViewModels;

namespace Simple_Cinima_Booking.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinima);
            return View(allMovies);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinima);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Title, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //Get Movies/Details
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieById(id);
            return View(movieDetails);
        }
        //Get Movies/Create
        public async Task<IActionResult> Create() 
        {
            var movieDropdawnsData = await _service.GetNewMovieDropdawnsValue();

            ViewBag.Cinimas = new SelectList(movieDropdawnsData.Cinimas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdawnsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdawnsData.Actors, "Id", "FullName");

            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid) 
            {
				var movieDropdawnsData = await _service.GetNewMovieDropdawnsValue();
				ViewBag.Cinimas = new SelectList(movieDropdawnsData.Cinimas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdawnsData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdawnsData.Actors, "Id", "FullName");

				return View(movie);
            }
            await _service.AddNewMovie(movie);
            return RedirectToAction(nameof(Index));
        }

		//GET: Movies/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await _service.GetMovieById(id);
			if (movieDetails == null) return View("NotFound");

			var response = new NewMovieVM()
			{
				Id = movieDetails.Id,
				Title = movieDetails.Title,
				Description = movieDetails.Description,
				Price = movieDetails.Price,
				StartDate = movieDetails.StartDate,
				EndDate = movieDetails.EndDate,
				ImageUrl = movieDetails.ImageUrl,
				MovieCategory = movieDetails.MovieCategory,
				CinimaId = movieDetails.CinimaId,
				ProducerId = movieDetails.ProducerId,
				ActorIds = movieDetails.Movies_Actors.Select(n => n.ActorId).ToList(),
			};

			var movieDropdawnsData = await _service.GetNewMovieDropdawnsValue();
			ViewBag.Cinimas = new SelectList(movieDropdawnsData.Cinimas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropdawnsData.Producers, "Id", "FullName");
			ViewBag.Actors = new SelectList(movieDropdawnsData.Actors, "Id", "FullName");

			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, NewMovieVM movie)
		{
			if (id != movie.Id) return View("NotFound");

			if (!ModelState.IsValid)
			{
				var movieDropdawnsData = await _service.GetNewMovieDropdawnsValue();
				ViewBag.Cinimas = new SelectList(movieDropdawnsData.Cinimas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropdawnsData.Producers, "Id", "FullName");
				ViewBag.Actors = new SelectList(movieDropdawnsData.Actors, "Id", "FullName");

				return View(movie);
			}

			await _service.UpdateMovieAsync(movie);
			return RedirectToAction(nameof(Index));
		}


	}
}
