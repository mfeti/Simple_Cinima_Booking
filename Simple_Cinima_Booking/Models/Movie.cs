using Simple_Cinima_Booking.Data.Base;
using Simple_Cinima_Booking.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple_Cinima_Booking.Models
{
    public class NewMovie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationship
        public List<Movie_Actor> Movies_Actors { get; set; }
        //cinima
        public int CinimaId { get; set; }
        [ForeignKey("CinimaId")]
        public Cinima Cinima { get; set; }

        //producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
