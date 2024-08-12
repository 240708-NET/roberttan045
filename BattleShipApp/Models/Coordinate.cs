namespace BattleShipApp.Models
{
    public class Coordinate
    {
        public int CoordinateId { get; set; }  // Primary key
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHit { get; set; }
    }
}