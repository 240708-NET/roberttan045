namespace MonopolyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            // Main game loop (omitted for simplicity)
            
            game.EndGame();
        }
    }
}