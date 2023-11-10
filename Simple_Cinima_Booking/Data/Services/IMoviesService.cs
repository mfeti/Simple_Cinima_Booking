using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Data.ViewModels;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<NewMovie>
    {
        Task<NewMovie> GetMovieById(int id);
        Task<NewMovieDropdawnsVM> GetNewMovieDropdawnsValue();
        Task AddNewMovie(NewMovieVM data);
		Task UpdateMovieAsync(NewMovieVM data);
	}

}
