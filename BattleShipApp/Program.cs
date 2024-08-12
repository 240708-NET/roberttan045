using BattleShipApp.Services;
using BattleShipApp.Data;
using BattleShipApp.DataAccess;
using BattleShipApp.Models;

namespace BattleShipApp
{
    class Program
{
    static async Task Main(string[] args)
    {
        var context = new BattleShipContext();
        var playerRepository = new PlayerRepository(context);
        var gameRepository = new GameRepository(context);
        var gameService = new GameService(gameRepository, playerRepository);
        var playerService = new PlayerService(playerRepository);

        Console.WriteLine("Welcome to BattleShip!");

        // Setup players
        var player1 = new Player { Name = "Player 1" };
        var player2 = new Player { Name = "Player 2" };

        // Example of setting up the board
        await playerService.SetupBoardAsync(player1, new List<Ship> { /* ships */ });
        await playerService.SetupBoardAsync(player2, new List<Ship> { /* ships */ });

        // Start the game
        await gameService.StartNewGameAsync(player1, player2);

        // Main game loop
        while (true)
        {
            // Example game loop logic
            Console.WriteLine($"{player1.Name}, it's your turn.");
            var target = new Coordinate { X = 1, Y = 1 }; // Example target
            await gameService.ProcessMoveAsync(1, player1, target); // 1 is the game ID

            // Check for a winner
            var winner = await gameService.GetWinnerAsync(1);
            if (winner != null)
            {
                Console.WriteLine($"{winner.Name} wins!");
                break;
            }

            // Switch turns, etc.
        }
    }
  }
}
