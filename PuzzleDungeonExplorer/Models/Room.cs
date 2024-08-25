using System.Collections.Generic;

namespace PuzzleDungeonExplorer.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public List<Puzzle> Puzzles { get; set; }
        public List<Trap> Traps { get; set; }
        public int DungeonId { get; set; }
        public Dungeon Dungeon { get; set; }
    }
}