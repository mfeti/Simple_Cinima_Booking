using Microsoft.EntityFrameworkCore;
using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.Services
{
	public class ActorsService : EntityBaseRepository<Actor>, IActorsService
	{
	
		public ActorsService(AppDbContext context) : base(context) { }
		
		

		
	}
}
