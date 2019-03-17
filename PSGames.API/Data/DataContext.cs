using Microsoft.EntityFrameworkCore;
using PSGames.API.Models;

namespace PSGames.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLibraryGame>().HasKey(ulg => new {ulg.UserId, ulg.GameId});
            modelBuilder.Entity<UserLibraryGame>()
                .HasOne(ulg => ulg.User)
                .WithMany(u => u.UserGameLibraries)
                .HasForeignKey(ulg => ulg.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserLibraryGame>()
                .HasOne(ulg => ulg.Game)
                .WithMany(g => g.UserGameLibraries)
                .HasForeignKey(ulg => ulg.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<UserLibraryGame> UsersGameLibraries { get; set; }
    }
}