using OrdisCephalonApp.Repositories;
using OrdisCephalonApp.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        var messageRepository = new MessageRepository();
        var ordisService = new OrdisService(messageRepository);

        Console.WriteLine("Welcome to the Ordis Cephalon Console App!");
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Make Ordis speak");
            Console.WriteLine("2. Add a new message");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ordisService.Speak();
                    break;
                case "2":
                    Console.WriteLine("Enter the new message:");
                    var newMessage = Console.ReadLine();
                    ordisService.AddMessage(newMessage);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}