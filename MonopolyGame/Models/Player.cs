namespace MonopolyGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Position { get; set; } // Board Position
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}