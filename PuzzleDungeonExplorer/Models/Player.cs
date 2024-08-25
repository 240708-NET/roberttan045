using System.Collections.Generic;

namespace PuzzleDungeonExplorer.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public List<Room> VisitedRooms { get; set; }
    }
}