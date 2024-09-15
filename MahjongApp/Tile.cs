public class Tile
{
    public string Suit { get; set; }
    public int Rank { get; set; }

    public Tile(string suit, int rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Suit} {Rank}";
    }
}