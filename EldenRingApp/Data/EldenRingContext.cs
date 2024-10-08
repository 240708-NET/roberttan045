using Microsoft.EntityFrameworkCore;
using EldenRingApp.Models;

namespace EldenRingApp.Data
{
    public class EldenRingContext : DbContext 
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EldenRingApp;User=sa;Password=IamNotATarnished123!;TrustServerCertificate=true;");
        }
    }
}