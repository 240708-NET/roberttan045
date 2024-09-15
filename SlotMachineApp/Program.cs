using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Slot Machine Game!");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Player player = new Player(name, 100); // Starting with 100 credits
        SlotMachine slotMachine = new SlotMachine(player);

        while (true)
        {
            Console.WriteLine($"Current Balance: {player.Balance}");
            Console.Write("Enter your bet amount (or type 'quit' to exit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }

            if (int.TryParse(input, out int bet))
            {
                slotMachine.Play(bet);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid bet amount.");
            }
        }
    }
}
