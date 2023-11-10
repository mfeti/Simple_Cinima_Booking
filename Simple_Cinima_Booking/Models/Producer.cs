using Simple_Cinima_Booking.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Simple_Cinima_Booking.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Bio { get; set; }

        //relationship
        public List<NewMovie> Movies { get; set; }
    }
}
