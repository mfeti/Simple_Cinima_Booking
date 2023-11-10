using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.Services
{
	public class ProducersService: EntityBaseRepository<Producer>, IProducersService
	{
        public ProducersService(AppDbContext context):base(context) { }
       
    }
}
