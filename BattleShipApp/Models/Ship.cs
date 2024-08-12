namespace BattleShipApp.Models
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public List<Coordinate> Coordinates { get; set; }
        public bool IsSunk => Coordinates.All(c => c.IsHit);
        // Other properties and methods
    }
}