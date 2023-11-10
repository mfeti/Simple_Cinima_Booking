using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.Services
{
	public class CinimasService:EntityBaseRepository<Cinima>, ICinimasService
	{
        public CinimasService(AppDbContext context):base(context) { }
    }
}
