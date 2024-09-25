using Microsoft.EntityFrameworkCore;
using MonopolyGame.Models;

namespace MonopolyGame.Data
{
    public class GameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Tile> Tiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=MonopolyGame;User=sa;Password=IShallSufferAgain123!;TrustServerCertificate=true;");
        }
    }
}