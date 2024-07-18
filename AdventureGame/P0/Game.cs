// Game.cs
using System;
using System.Collections.Generic;

public class Game
{
    private Character player;
    private List<Room> rooms;
    private Random random;

    public Game()
    {
        player = new Character("Default"); // Initialize player with a default value
        rooms = new List<Room>
        {
            new Room("You enter a dark cave.", true),
            new Room("You find yourself in a dense forest.", false),
            new Room("You have arrived at a peaceful meadow.", false),
            new Room("You have step into a creepy haunted mansion.", true)
        };
        random = new Random();
    }

    public void Start()
    {
        Console.WriteLine("Welcome...to the Adventure Game!");
        Console.WriteLine("Please Enter Your Character Name: ");
        string name = Console.ReadLine() ?? "Default";
        player = new Character(name ?? "Default");
        player.DisplayStats();

        bool playing = true;
        while (playing)
        {

            // The user will have to choose three option
            
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Move to a available room");
            Console.WriteLine("2. View your character stats");
            Console.WriteLine("3. Exit game");
            string choice = Console.ReadLine() ?? "0";

            switch (choice)
            {
                case "1":
                    MoveToAvailableRoom();
                    break;
                case "2":
                    player.DisplayStats();
                    break;
                case "3":
                    playing = false;
                    break;
                default:
                    Console.WriteLine("That is a invalid choice. Try again.");
                    break;
            }
        }
    }

    private void MoveToAvailableRoom()
    {
        Room room = rooms[random.Next(rooms.Count)];
        room.EnterRoom();
    }
}