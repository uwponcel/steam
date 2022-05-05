using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using steam.Models;

namespace steam.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game_Publisher>().HasKey(gp => new
            {
                gp.PublisherId,
                gp.GameId
            });

            //1 to many Joining table Game side
            modelBuilder.Entity<Game_Publisher>().HasOne(g => g.Game).WithMany(gp => gp.Games_Publishers).HasForeignKey(g => g.GameId);

            //1 to many Joining table Publisher side
            modelBuilder.Entity<Game_Publisher>().HasOne(g => g.Publisher).WithMany(gp => gp.Games_Publishers).HasForeignKey(g => g.PublisherId);

            base.OnModelCreating(modelBuilder);
        }

        //Defining table names

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Game_Publisher> Games_Publishers { get; set; }
        public DbSet<Developper> Developpers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
