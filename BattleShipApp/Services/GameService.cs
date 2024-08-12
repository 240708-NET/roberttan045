using System;
using System.Threading.Tasks;
using BattleShipApp.Models;
using BattleShipApp.Data;

namespace BattleShipApp.Services
{
    public class GameService
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly IRepository<Player> _playerRepository;

        public GameService(IRepository<Game> gameRepository, IRepository<Player> playerRepository)
        {
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
        }

        public async Task StartNewGameAsync(Player player1, Player player2)
        {
            var game = new Game
            {
                Player1Id = player1.Id,
                Player2Id = player2.Id,
                IsPlayer1Turn = true,
                StartTime = DateTime.Now
            };
            await _gameRepository.AddAsync(game);
        }

        public async Task<Player> GetWinnerAsync(int gameId)
        {
            var game = await _gameRepository.GetByIdAsync(gameId);
            if (game == null) return null;

            return game.Player1.HasLost ? game.Player2 : game.Player1;
        }

        public async Task ProcessMoveAsync(int gameId, Player player, Coordinate target)
        {
            var game = await _gameRepository.GetByIdAsync(gameId);
            if (game == null) throw new Exception("Game not found.");

            var opponent = game.IsPlayer1Turn ? game.Player2 : game.Player1;

            if (opponent.Board.ProcessAttack(target))
            {
                // Handle a successful hit
            }

            game.IsPlayer1Turn = !game.IsPlayer1Turn;
            await _gameRepository.UpdateAsync(game);
        }
    }
}