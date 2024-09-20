using Microsoft.EntityFrameworkCore;
using WordScrambleGame.Models;

namespace WordScrambleGame.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LocalHost;Database=WordScrambleGame;User=sa;Password=IShallSuffer123!;TrustServerCertificate=true;");
        }
    }
}