using System.Collections.Generic;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerById(int id);
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
        void Save();
    }
}