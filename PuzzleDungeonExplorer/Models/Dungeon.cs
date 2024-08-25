using System.Collections.Generic;

namespace PuzzleDungeonExplorer.Models
{
    public class Dungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}