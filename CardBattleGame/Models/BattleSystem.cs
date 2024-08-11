using System;

namespace CardBattleGame.Models
{
    public class BattleSystem
    {
        public void StartBattle(Player player1, Player player2)
        {
            Console.WriteLine($"Starting battle between {player1.Name} and {player2.Name}!");

            while (player1.Health > 0 && player2.Health > 0)
            {
                // Simulate a simple turn-based battle
                PlayerTurn(player1, player2);
                if (player2.Health > 0)
                {
                    PlayerTurn(player2, player1);
                }
            }

            if (player1.Health <= 0)
            {
                Console.WriteLine($"{player2.Name} wins!");
            }
            else if (player2.Health <= 0)
            {
                Console.WriteLine($"{player1.Name} wins!");
            }
        }

        private void PlayerTurn(Player attackingPlayer, Player defendingPlayer)
        {
            attackingPlayer.DrawCard();
            if (attackingPlayer.Hand.Count > 0)
            {
                Card card = attackingPlayer.Hand[0];
                attackingPlayer.Hand.RemoveAt(0);

                Console.WriteLine($"{attackingPlayer.Name} plays {card.Name}!");

                int damage = card.Attack - card.Defense;
                if (damage > 0)
                {
                    defendingPlayer.Health -= damage;
                    Console.WriteLine($"{defendingPlayer.Name} takes {damage} damage!");
                }
                else
                {
                    Console.WriteLine($"{card.Name} does no damage!");
                }
            }
            else
            {
                Console.WriteLine($"{attackingPlayer.Name} has no cards to play!");
            }
        }
    }
}