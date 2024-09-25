using MonopolyGame.Models;
using MonopolyGame.Repositories;
using MonopolyGame.Data;
using System;

namespace MonopolyGame
{
    public class Game
    {
        private UnitOfWork _unitOfWork;
        private List<Player> _players;

        public Game()
        {
            _unitOfWork = new UnitOfWork(new GameDbContext());
            _players = _unitOfWork.Players.GetAll().ToList();
        }

        public void Start()
        {
            Console.WriteLine("Starting Monopoly Game...");
            // Add players, roll dice, move, etc.
            foreach (var player in _players)
            {
                Console.WriteLine($"{player.Name} starts with ${player.Balance}");
            }
        }

        public void EndGame()
        {
            Console.WriteLine("Saving game state...");
            _unitOfWork.Save();
        }
    }
}