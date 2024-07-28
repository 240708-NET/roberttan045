namespace SpaceShooterApp.Services
{
    public class InputService
    {
        public char GetInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).KeyChar;
                return key;
            }
            return '\0';
        }
    }
}