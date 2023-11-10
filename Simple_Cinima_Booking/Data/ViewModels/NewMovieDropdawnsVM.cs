using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data.ViewModels
{
    public class NewMovieDropdawnsVM
    {
        public NewMovieDropdawnsVM()
        {
            Producers = new List<Producer>();
            Cinimas = new List<Cinima>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Cinima> Cinimas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
