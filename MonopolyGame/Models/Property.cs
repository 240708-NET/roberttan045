namespace MonopolyGame.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rent { get; set; }
        public int OwnerId { get; set; }
        public Player Owner { get; set; }
    }
}