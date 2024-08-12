namespace BattleShipApp.Models
{
    public class Board
    {
        public int Id { get; set; }
        public List<Ship> Ships { get; set; }

        public bool ProcessAttack(Coordinate coordinate)
        {
            foreach (var ship in Ships)
            {
                var hit = ship.Coordinates.FirstOrDefault(c => c.X == coordinate.X && c.Y == coordinate.Y);
                if (hit != null)
                {
                    hit.IsHit = true;
                    return true;
                }
            }
            return false;
        }
    }
}