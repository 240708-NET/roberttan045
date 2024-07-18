using System.Collections.Generic;
using GameCore;

namespace Data
{
    public class PlayerRepository : IRepository<Player>
    {
        private List<Player> players = new List<Player>();

        public void Add(Player entity)
        {
            players.Add(entity);
        }

        public void Remove(Player entity)
        {
            players.Remove(entity);
        }

        public IEnumerable<Player> GetAll()
        {
            return players;
        }
    }
}