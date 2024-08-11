using System;
using System.Collections.Generic;
using CardBattleGame.Models;

namespace CardBattleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck1 = new List<Card>
            {
                new Card("Knight", 5, 3, 2, "Charge"),
                new Card("Archer", 3, 2, 1, "Piercing Arrow"),
                new Card("Mage", 4, 1, 3, "Fireball")
            };

            var deck2 = new List<Card>
            {
                new Card("Warrior", 4, 4, 2, "Shield Bash"),
                new Card("Rogue", 3, 2, 1, "Backstab"),
                new Card("Wizard", 5, 1, 3, "Lightning Bolt")
            };

            Player player1 = new Player("Player 1", 20, deck1);
            Player player2 = new Player("Player 2", 20, deck2);

            BattleSystem battleSystem = new BattleSystem();
            battleSystem.StartBattle(player1, player2);
        }
    }
}