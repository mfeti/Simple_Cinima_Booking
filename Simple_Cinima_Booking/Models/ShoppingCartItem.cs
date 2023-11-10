using System.ComponentModel.DataAnnotations;

namespace Simple_Cinima_Booking.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public NewMovie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
