using SpaceShooterApp.Models;
using System.Collections.Generic;

namespace SpaceShooterApp.Repositories
{
    public class EnemyRepository : IRepository<Enemy>
    {
        private List<Enemy> enemies = new List<Enemy>();

        public void Add(Enemy enemy) => enemies.Add(enemy);
        public void Remove(Enemy enemy) => enemies.Remove(enemy);
        public IEnumerable<Enemy> GetAll() => enemies;
    }
}