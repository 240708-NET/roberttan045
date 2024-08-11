using System;
using System.Collections.Generic;
using PokerGame.Models;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("Player 1"),
                new Player("Player 2"),
                new Player("Player 3"),
                new Player("Player 4")
            };

            PokerGameEngine game = new PokerGameEngine(players);
            game.StartGame();
        }
    }
}