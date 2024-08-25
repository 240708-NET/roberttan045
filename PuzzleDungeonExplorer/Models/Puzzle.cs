namespace PuzzleDungeonExplorer.Models
{
    public class Puzzle
    {
        public int Id { get; set; }
        public string PuzzleType { get; set; }
        public string Difficulty { get; set; }
        public string Solution { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}