using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Liar's Dice!");
        Console.WriteLine("Enter your name:");
        var playerName = Console.ReadLine();

        // Create a list of players including the user and the CPU
        var playerNames = new List<string> { playerName };
        var players = new List<Player>
        {
            new Player(playerName),
            new Player("CPU", isCPU: true) // Add a CPU player
        };

        LiarDiceGame game = new LiarDiceGame(players);
        game.StartGame();
    }
}