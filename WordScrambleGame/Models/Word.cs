namespace WordScrambleGame.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string OriginalWord { get; set; }
        public string ScrambledWord { get; set; }
        public string Difficulty { get; set; } // e.g., "Easy", "Medium", "Hard"
    }
}