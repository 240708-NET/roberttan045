namespace WordScrambleGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentScore { get; set; }
        public int HighScore { get; set; }
    }
}