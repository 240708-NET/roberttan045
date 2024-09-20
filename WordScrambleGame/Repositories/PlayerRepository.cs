using System.Collections.Generic;
using System.Linq;
using WordScrambleGame.Models;

namespace WordScrambleGame.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly GameContext _context;

        public PlayerRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAll() => _context.Players.ToList();
        public Player GetById(int id) => _context.Players.Find(id);
        public void Add(Player player) => _context.Players.Add(player);
        public void Update(Player player) => _context.Players.Update(player);
        public void Delete(int id)
        {
            var player = _context.Players.Find(id);
            if (player != null) _context.Players.Remove(player);
        }
        public void Save() => _context.SaveChanges();
    }
}