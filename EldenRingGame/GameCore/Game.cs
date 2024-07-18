using System;
using Data;

namespace GameCore
{
    public class Game
    {
        private Player player;
        private Enemy enemy;
        private readonly PlayerRepository playerRepository;
        private readonly EnemyRepository enemyRepository;

        public Game()
        {
            playerRepository = new PlayerRepository();
            enemyRepository = new EnemyRepository();
        }

        public void Start()
        {
            Console.WriteLine("Welcome ye Tarnished, to Elden Ring!");
            Console.Write("Enter your character's name: ");
            string playerName = Console.ReadLine() ?? "Player";
            player = new Player(playerName);
            enemy = new Enemy("General Rahdan");

            playerRepository.Add(player);
            enemyRepository.Add(enemy);

            Console.WriteLine($"A Great boss {enemy.Name} appears!");

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine($"\n{player.Name} HP: {player.Health}");
                Console.WriteLine($"{enemy.Name} HP: {enemy.Health}");
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Defend");
                Console.WriteLine("3. Magic Attack");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine() ?? "4";

                if (choice == "1")
                {
                    player.Attack(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                    else
                    {
                        Console.WriteLine($"You defeated the great boss {enemy.Name}!");
                        break;
                    }
                }
                else if (choice == "2")
                {
                    player.Defend();
                    enemy.Attack(player);
                }
                else if (choice == "3")
                {
                    player.MagicAttack(enemy);
                    if (enemy.Health > 0)
                    {
                        enemy.Attack(player);
                    }
                    else
                    {
                        Console.WriteLine($"You defeated the {enemy.Name}!");
                        break;
                    }
                }
                else if (choice == "4")
                {
                    break;
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("You Died.");
            }

            Console.WriteLine("Thank you for playing Elden Ring, Tarnished. Also, you are maidenless.");
        }
    }
}