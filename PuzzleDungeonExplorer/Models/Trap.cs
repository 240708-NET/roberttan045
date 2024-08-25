namespace PuzzleDungeonExplorer.Models
{
    public class Trap
    {
        public int Id { get; set; }
        public string TrapType { get; set; }
        public int Damage { get; set; }
        public string DisarmCondition { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}