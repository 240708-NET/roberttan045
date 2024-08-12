using BattleShipApp.Models;
using BattleShipApp.Data;
namespace BattleShipApp.Services
{
    public class PlayerService
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayerService(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task SetupBoardAsync(Player player, List<Ship> ships)
        {
            player.Board = new Board { Ships = ships };
            await _playerRepository.UpdateAsync(player);
        }
    }
}