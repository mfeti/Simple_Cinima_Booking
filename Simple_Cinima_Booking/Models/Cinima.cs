using Simple_Cinima_Booking.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Simple_Cinima_Booking.Models
{
    public class Cinima: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Relationship
        public List<NewMovie> Movies { get; set; }
    }
}
