using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simple_Cinima_Booking.Models;

namespace Simple_Cinima_Booking.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Actor>().HasKey(ma => new
            {
                ma.ActorId,
                ma.MovieId
            });
            modelBuilder.Entity<Movie_Actor>().HasOne(m => m.Movie).WithMany(ma => ma.Movies_Actors).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Movie_Actor>().HasOne(m => m.Actor).WithMany(ma => ma.Movies_Actors).HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinima> Cinimas { get; set; }
        public DbSet<NewMovie> Movies { get; set; }
        public DbSet<Movie_Actor> Movies_Actors { get; set; }

        //Order related table
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
