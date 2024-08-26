using System;
using System.Linq;
using PuzzleDungeonExplorer.Models;
using PuzzleDungeonExplorer.Repositories;

namespace PuzzleDungeonExplorer.Services
{
    public class GameService
    {
        private Player player;
        private Dungeon dungeon;
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

            dungeon = LoadDungeon();
            player = LoadPlayer();

            MainGameLoop(dungeon, player);
        }

        private void SaveGame(Player player, Dungeon dungeon)
        {
            // Implement save logic here
        }

        private (Player, Dungeon) LoadGame()
        {
            // Implement load logic here
            return (new Player(), new Dungeon());
        }

        private Dungeon LoadDungeon()
        {
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
                Console.WriteLine("3. Save game");
                Console.WriteLine("4. Load game");
                Console.WriteLine("5. Exit game");

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
                        SaveGame(player, dungeon);
                        break;
                    case "4":
                        var gameState = LoadGame();
                        player = gameState.Item1;
                        dungeon = gameState.Item2;
                        break;
                    case "5":
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
            Console.WriteLine("\nYou enter a room...");

            var room = dungeon.Rooms.FirstOrDefault();
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

            SolvePuzzlesInRoom(room);
            HandleTrapsInRoom(room, player);
        }

        private void SolvePuzzlesInRoom(Room room)
        {
            foreach (var puzzle in room.Puzzles)
            {
                Console.WriteLine($"Puzzle: {puzzle.PuzzleType} (Difficulty: {puzzle.Difficulty})");
                Console.Write("Your answer: ");
                var answer = Console.ReadLine();

                if (answer.Equals(puzzle.Solution, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct! You solved the puzzle.");
                    player.Score += 10;
                }
                else
                {
                    Console.WriteLine("Incorrect. The puzzle remains unsolved.");
                }
            }
        }

        private void HandleTrapsInRoom(Room room, Player player)
        {
            foreach (var trap in room.Traps)
            {
                Console.WriteLine($"Trap: {trap.TrapType} (Damage: {trap.Damage})");
                Console.Write("What will you do? (Disarm/Pass): ");
                var action = Console.ReadLine();

                if (action.Equals("Disarm", StringComparison.OrdinalIgnoreCase) && trap.DisarmCondition.Equals("Carefully step over", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You carefully disarm the trap and proceed safely.");
                    player.Score += 5;
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
            Console.WriteLine($"Score: {player.Score}");
            Console.WriteLine($"Rooms visited: {player.VisitedRooms.Count}");
        }
    }
}