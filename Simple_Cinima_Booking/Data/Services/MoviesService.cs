using Microsoft.EntityFrameworkCore;
using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Data.ViewModels;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.Services
{
    public class MoviesService: EntityBaseRepository<NewMovie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context): base(context) 
        {
            _context = context;
        }

		public async Task AddNewMovie(NewMovieVM data)
		{
			var newMovie = new NewMovie()
			{
				Title = data.Title,
				Description = data.Description,
				Price = data.Price,
				ImageUrl = data.ImageUrl,
				CinimaId = data.CinimaId,
				StartDate = data.StartDate,
				EndDate = data.EndDate,
				MovieCategory = data.MovieCategory,
				ProducerId = data.ProducerId
			};
			await _context.Movies.AddAsync(newMovie);
			await _context.SaveChangesAsync();

			//Add Movie Actors
			foreach (var actorId in data.ActorIds)
			{
				var newActorMovie = new Movie_Actor()
				{
					MovieId = newMovie.Id,
					ActorId = actorId
				};
				await _context.Movies_Actors.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
		}

		public async Task<NewMovie> GetMovieById(int id)
        {
            var moviesDetails = await _context.Movies.
                Include(c => c.Cinima).
                Include(p => p.Producer).
                Include(ma => ma.Movies_Actors).ThenInclude(a => a.Actor).
                FirstOrDefaultAsync(n => n.Id == id);
            return moviesDetails;

        }

        public async Task<NewMovieDropdawnsVM> GetNewMovieDropdawnsValue()
        {
            var response = new NewMovieDropdawnsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinimas = await _context.Cinimas.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

		public async Task UpdateMovieAsync(NewMovieVM data)
		{
			var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

			if (dbMovie != null)
			{
				dbMovie.Title = data.Title;
				dbMovie.Description = data.Description;
				dbMovie.Price = data.Price;
				dbMovie.ImageUrl = data.ImageUrl;
				dbMovie.CinimaId = data.CinimaId;
				dbMovie.StartDate = data.StartDate;
				dbMovie.EndDate = data.EndDate;
				dbMovie.MovieCategory = data.MovieCategory;
				dbMovie.ProducerId = data.ProducerId;
				await _context.SaveChangesAsync();
			}

			//Remove existing actors
			var existingActorsDb = _context.Movies_Actors.Where(n => n.MovieId == data.Id).ToList();
			_context.Movies_Actors.RemoveRange(existingActorsDb);
			await _context.SaveChangesAsync();

			//Add Movie Actors
			foreach (var actorId in data.ActorIds)
			{
				var newActorMovie = new Movie_Actor()
				{
					MovieId = data.Id,
					ActorId = actorId
				};
				await _context.Movies_Actors.AddAsync(newActorMovie);
			}
			await _context.SaveChangesAsync();
		}
	}
}
