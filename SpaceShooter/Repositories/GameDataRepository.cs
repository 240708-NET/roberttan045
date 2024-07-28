using SpaceShooterApp.Models;
using System.Collections.Generic;

namespace SpaceShooterApp.Repositories
{
    public class GameDataRepository : IRepository<GameData>
    {
        private List<GameData> gameData = new List<GameData>();

        public void Add(GameData data) => gameData.Add(data);
        public void Remove(GameData data) => gameData.Remove(data);
        public IEnumerable<GameData> GetAll() => gameData;
    }
}