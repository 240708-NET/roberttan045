using System.Collections.Generic;
using System.Linq;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly PuzzleDungeonContext _context;

        public PlayerRepository(PuzzleDungeonContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.Find(id);
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
        }

        public void DeletePlayer(int id)
        {
            var player = _context.Players.Find(id);
            if (player != null)
            {
                _context.Players.Remove(player);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}