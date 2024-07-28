using SpaceShooterApp.Models;
using System.Collections.Generic;

namespace SpaceShooterApp.Repositories
{
    public class ShipRepository : IRepository<Ship>
    {
        private List<Ship> ships = new List<Ship>();

        public void Add(Ship ship) => ships.Add(ship);
        public void Remove(Ship ship) => ships.Remove(ship);
        public IEnumerable<Ship> GetAll() => ships;
    }
}