using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Simple_Cinima_Booking.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Simple_Cinima_Booking.Models
{
    public class Actor : IEntityBase
    {
        [Key]
		public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage="The name must be betwen 3 and 50")]
        public string FullName { get; set; }
		[Required]
		public string ProfilePictureUrl { get; set; }
		[Required]
		public string Bio { get; set; }
        //Relationship
        public List<Movie_Actor> Movies_Actors { get; set; }

	}
}
