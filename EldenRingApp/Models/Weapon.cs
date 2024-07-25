using System.ComponentModel.DataAnnotations;

namespace EldenRingApp.Models
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty; // Initialize with a default value
        
        public int AttackPower { get; set; }
        
        public int CharacterId { get; set; }
        
        public Character Character { get; set; } = null!; // Use null-forgiving operator if you are sure it will be set later
    }
}