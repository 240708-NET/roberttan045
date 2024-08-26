using Microsoft.EntityFrameworkCore;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Data
{
    public class PuzzleDungeonContext : DbContext
    {
        public PuzzleDungeonContext(DbContextOptions<PuzzleDungeonContext> options) : base(options)
        {
            
        }

        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Puzzle> Puzzles { get; set; }
        public DbSet<Trap> Traps { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Set the connection string directly here
                optionsBuilder.UseSqlServer("Server=localhost;Database=PuzzleDungeonExplorer;User Id=sa;Password=IamNotATarnished123!;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints here if needed
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Puzzles)
                .WithOne(p => p.Room)
                .HasForeignKey(p => p.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Traps)
                .WithOne(t => t.Room)
                .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Dungeon>()
                .HasMany(d => d.Rooms)
                .WithOne(r => r.Dungeon)
                .HasForeignKey(r => r.DungeonId);
        }
    }
}