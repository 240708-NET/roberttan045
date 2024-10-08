using System.ComponentModel.DataAnnotations;

namespace EldenRingApp.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty; // Initialize with a default value
        
        public string Class { get; set; } = string.Empty; // Initialize with a default value
        
        public int Level { get; set; }
    }
}