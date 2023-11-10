namespace Simple_Cinima_Booking.Models
{
    public class Movie_Actor
    {
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int MovieId { get; set; }
        public NewMovie Movie { get; set;}
    }
}
