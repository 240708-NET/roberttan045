using System;
using System.Collections.Generic;

namespace PokerGame.Models
{
    public class PokerGameEngine
    {
        private Deck _deck;
        private List<Player> _players;

        public PokerGameEngine(List<Player> players)
        {
            _deck = new Deck();
            _players = players;
        }

        public void DealInitialCards()
        {
            foreach (var player in _players)
            {
                for (int i = 0; i < 2; i++) // Deal 2 cards to each player
                {
                    player.DrawCard(_deck);
                }
            }
        }

        public void ShowHands()
        {
            foreach (var player in _players)
            {
                Console.WriteLine(player);
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Starting Poker Game!");

            DealInitialCards();
            ShowHands();
            
            // Additional poker game logic goes here
        }
    }
}