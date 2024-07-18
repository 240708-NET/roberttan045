using System.Collections.Generic;
using GameCore;

namespace Data
{
    public class EnemyRepository : IRepository<Enemy>
    {
        private List<Enemy> enemies = new List<Enemy>();

        public void Add(Enemy entity)
        {
            enemies.Add(entity);
        }

        public void Remove(Enemy entity)
        {
            enemies.Remove(entity);
        }

        public IEnumerable<Enemy> GetAll()
        {
            return enemies;
        }
    }
}
