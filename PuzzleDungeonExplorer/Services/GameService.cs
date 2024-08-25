using System;
using System.Linq;
using PuzzleDungeonExplorer.Models;
using PuzzleDungeonExplorer.Repositories;

namespace PuzzleDungeonExplorer.Services
{
    public class GameService
    {
        private readonly IDungeonRepository _dungeonRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly ITrapRepository _trapRepository;
        private readonly IPlayerRepository _playerRepository;

        public GameService(
            IDungeonRepository dungeonRepository,
            IRoomRepository roomRepository,
            IPuzzleRepository puzzleRepository,
            ITrapRepository trapRepository,
            IPlayerRepository playerRepository)
        {
            _dungeonRepository = dungeonRepository;
            _roomRepository = roomRepository;
            _puzzleRepository = puzzleRepository;
            _trapRepository = trapRepository;
            _playerRepository = playerRepository;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Puzzle Dungeon Explorer!");

            // Load or create a new dungeon
            var dungeon = LoadDungeon();

            // Create or load player
            var player = LoadPlayer();

            // Start the main game loop
            MainGameLoop(dungeon, player);
        }

        private Dungeon LoadDungeon()
        {
            // Here you could add logic to load an existing dungeon or create a new one
            var dungeon = _dungeonRepository.GetAllDungeons().FirstOrDefault();

            if (dungeon == null)
            {
                dungeon = new Dungeon { Name = "Mysterious Dungeon", Rooms = new System.Collections.Generic.List<Room>() };
                _dungeonRepository.AddDungeon(dungeon);
                _dungeonRepository.Save();
            }

            return dungeon;
        }

        private Player LoadPlayer()
        {
            // Here you could add logic to load an existing player or create a new one
            var player = _playerRepository.GetAllPlayers().FirstOrDefault();

            if (player == null)
            {
                player = new Player { Name = "Adventurer", Health = 100, VisitedRooms = new System.Collections.Generic.List<Room>() };
                _playerRepository.AddPlayer(player);
                _playerRepository.Save();
            }

            return player;
        }

        private void MainGameLoop(Dungeon dungeon, Player player)
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Explore a room");
                Console.WriteLine("2. View player status");
                Console.WriteLine("3. Exit game");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ExploreRoom(dungeon, player);
                        break;
                    case "2":
                        DisplayPlayerStatus(player);
                        break;
                    case "3":
                        gameRunning = false;
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ExploreRoom(Dungeon dungeon, Player player)
        {
            // Logic for exploring rooms, solving puzzles, and interacting with traps
            Console.WriteLine("\nYou enter a room...");

            var room = dungeon.Rooms.FirstOrDefault(); // Placeholder for room selection logic
            if (room == null)
            {
                room = new Room { RoomName = "Dark Chamber", Description = "A dimly lit room with a strange atmosphere.", Puzzles = new System.Collections.Generic.List<Puzzle>(), Traps = new System.Collections.Generic.List<Trap>(), Dungeon = dungeon };
                _roomRepository.AddRoom(room);
                _roomRepository.Save();

                dungeon.Rooms.Add(room);
                _dungeonRepository.UpdateDungeon(dungeon);
                _dungeonRepository.Save();
            }

            player.VisitedRooms.Add(room);
            _playerRepository.UpdatePlayer(player);
            _playerRepository.Save();

            Console.WriteLine($"You are in {room.RoomName}. {room.Description}");

            // Placeholder logic for solving puzzles and avoiding traps
            SolvePuzzlesInRoom(room);
            HandleTrapsInRoom(room, player);
        }

        private void SolvePuzzlesInRoom(Room room)
        {
            if (room.Puzzles.Count == 0)
            {
                var puzzle = new Puzzle { PuzzleType = "Riddle", Difficulty = "Medium", Solution = "Answer", Room = room };
                _puzzleRepository.AddPuzzle(puzzle);
                _puzzleRepository.Save();

                room.Puzzles.Add(puzzle);
                _roomRepository.UpdateRoom(room);
                _roomRepository.Save();

                Console.WriteLine("You encounter a puzzle: A riddle to solve!");
            }

            foreach (var puzzle in room.Puzzles)
            {
                Console.WriteLine($"Puzzle: {puzzle.PuzzleType} (Difficulty: {puzzle.Difficulty})");
                Console.Write("Your answer: ");
                var answer = Console.ReadLine();

                if (answer.Equals(puzzle.Solution, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct! You solved the puzzle.");
                }
                else
                {
                    Console.WriteLine("Incorrect. The puzzle remains unsolved.");
                }
            }
        }

        private void HandleTrapsInRoom(Room room, Player player)
        {
            if (room.Traps.Count == 0)
            {
                var trap = new Trap { TrapType = "Spikes", Damage = 10, DisarmCondition = "Carefully step over", Room = room };
                _trapRepository.AddTrap(trap);
                _trapRepository.Save();

                room.Traps.Add(trap);
                _roomRepository.UpdateRoom(room);
                _roomRepository.Save();

                Console.WriteLine("You notice a trap: Spikes protruding from the floor!");
            }

            foreach (var trap in room.Traps)
            {
                Console.WriteLine($"Trap: {trap.TrapType} (Damage: {trap.Damage})");
                Console.Write("What will you do? (Disarm/Pass): ");
                var action = Console.ReadLine();

                if (action.Equals("Disarm", StringComparison.OrdinalIgnoreCase) && trap.DisarmCondition.Equals("Carefully step over", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You carefully disarm the trap and proceed safely.");
                }
                else
                {
                    Console.WriteLine("You triggered the trap!");
                    player.Health -= trap.Damage;
                    Console.WriteLine($"You take {trap.Damage} damage. Your health is now {player.Health}.");
                }
            }
        }

        private void DisplayPlayerStatus(Player player)
        {
            Console.WriteLine($"\nPlayer: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Rooms visited: {player.VisitedRooms.Count}");
        }
    }
}