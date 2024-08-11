using System.Collections.Generic;

namespace CardBattleGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();

        public Player(string name, int health, List<Card> deck)
        {
            Name = name;
            Health = health;
            Deck = deck;
        }

        public void DrawCard()
        {
            if (Deck.Count > 0)
            {
                Card drawnCard = Deck[0];
                Hand.Add(drawnCard);
                Deck.RemoveAt(0);
            }
        }

        public override string ToString()
        {
            return $"{Name} - Health: {Health}, Cards in Hand: {Hand.Count}, Cards in Deck: {Deck.Count}";
        }
    }
}