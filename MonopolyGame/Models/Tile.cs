namespace MonopolyGame.Models
{
    public class Tile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TileType Type { get; set; }
    }

    public enum TileType
    {
        Property,
        Chance,
        Jail,
        FreeParking,
        GoToJail
    }
}