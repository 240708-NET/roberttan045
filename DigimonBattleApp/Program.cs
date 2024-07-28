using System;
using System.Collections.Generic;
using DigimonBattleApp.Digimons;
using DigimonBattleApp.Moves;
using DigimonBattleApp.Battles;

namespace DigimonBattleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Digimon with some default moves
            var agumon = new Digimon("Agumon", new List<Move>
            {
                new Move("Pepper Breath", 20),
                new Move("Claw Attack", 10)
            });

            var gabumon = new Digimon("Gabumon", new List<Move>
            {
                new Move("Blue Blaster", 20),
                new Move("Horn Attack", 10)
            });

            // Display available moves for Agumon
            Console.WriteLine("Select moves for Agumon:");
            agumon.DisplayMoves();

            var selectedMoves = new List<Move>();
            while (selectedMoves.Count < 2)
            {
                Console.Write("Choose a move for Agumon (1 or 2): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= agumon.Moves.Count)
                {
                    selectedMoves.Add(agumon.Moves[choice - 1]);
                    Console.WriteLine($"Added {agumon.Moves[choice - 1].Name} to Agumon's moves.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }

            agumon.Moves = selectedMoves;  // Update Agumon's moves with user's selection

            // Display available moves for Gabumon
            Console.WriteLine("\nSelect moves for Gabumon:");
            gabumon.DisplayMoves();

            selectedMoves.Clear();
            while (selectedMoves.Count < 2)
            {
                Console.Write("Choose a move for Gabumon (1 or 2): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= gabumon.Moves.Count)
                {
                    selectedMoves.Add(gabumon.Moves[choice - 1]);
                    Console.WriteLine($"Added {gabumon.Moves[choice - 1].Name} to Gabumon's moves.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }

            gabumon.Moves = selectedMoves;  // Update Gabumon's moves with user's selection

            // Start the battle
            var battle = new Battle(agumon, gabumon);
            battle.Start();
        }
    }
}