using System.Collections.Generic;

namespace PokerGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }

        public void DrawCard(Deck deck)
        {
            Hand.Add(deck.Draw());
        }

        public override string ToString()
        {
            return $"{Name} - Hand: {string.Join(", ", Hand)}";
        }
    }
}