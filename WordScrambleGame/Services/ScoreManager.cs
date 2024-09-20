using WordScrambleGame.Models;
using WordScrambleGame.Repositories;

namespace WordScrambleGame.Services
{
    public class ScoreManager
    {
        private readonly IRepository<Player> _playerRepository;

        public ScoreManager(IRepository<Player> playerRepo)
        {
            _playerRepository = playerRepo;
        }

        public void UpdateScore(Player player, int points)
        {
            player.CurrentScore += points;
            if (player.CurrentScore > player.HighScore)
                player.HighScore = player.CurrentScore;
            _playerRepository.Update(player);
            _playerRepository.Save();
        }
    }
}