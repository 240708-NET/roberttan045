namespace PuzzleDungeonExplorer.Models
{
    public class Trap
    {
        public int Id { get; set; }
        public string TrapType { get; set; } = string.Empty; // Default to an empty string
        public int Damage { get; set; }
        public string DisarmCondition { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public Room Room { get; set; } = new Room(); // Initialize with a new instance}
    }
}