using SpaceShooterApp.Services;

namespace SpaceShooterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameService gameService = new GameService();
            InputService inputService = new InputService();
            gameService.StartGame();

            while (true)
            {
                char input = inputService.GetInput();
                if (input == 'q')
                {
                    break;
                }
                gameService.UpdateGame();
                gameService.DrawGame();
            }
        }
    }
}