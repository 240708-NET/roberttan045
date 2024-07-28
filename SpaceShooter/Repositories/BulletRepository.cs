using SpaceShooterApp.Models;
using System.Collections.Generic;

namespace SpaceShooterApp.Repositories
{
    public class BulletRepository : IRepository<Bullet>
    {
        private List<Bullet> bullets = new List<Bullet>();

        public void Add(Bullet bullet) => bullets.Add(bullet);
        public void Remove(Bullet bullet) => bullets.Remove(bullet);
        public IEnumerable<Bullet> GetAll() => bullets;
    }
}