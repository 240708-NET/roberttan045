namespace BattleShipApp.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Assuming each player has a board
        public Board Board { get; set; }

        // Property to check if the player has lost
        public bool HasLost
        {
            get
            {
                // Assuming HasLost is determined by whether all ships on the board are sunk
                return Board.Ships.All(ship => ship.IsSunk);
            }
        }

        // Navigation properties for the games where this player is involved
        public ICollection<Game> GamesAsPlayer1 { get; set; }  // Games where the player is Player 1
        public ICollection<Game> GamesAsPlayer2 { get; set; }  // Games where the player is Player 2
    }
}