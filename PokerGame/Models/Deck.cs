using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Models
{
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    _cards.Add(new Card(suit, rank));
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rng = new Random();
            _cards = _cards.OrderBy(c => rng.Next()).ToList();
        }

        public Card Draw()
        {
            if (_cards.Count == 0) return null;

            Card drawnCard = _cards[0];
            _cards.RemoveAt(0);
            return drawnCard;
        }
    }
}