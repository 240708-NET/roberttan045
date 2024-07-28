using SpaceShooterApp.Models;
using SpaceShooterApp.Repositories;
using System.Collections.Generic;

namespace SpaceShooterApp.Services
{
    public class GameService
    {
        private readonly ShipRepository shipRepository;
        private readonly EnemyRepository enemyRepository;
        private readonly BulletRepository bulletRepository;
        private readonly GameDataRepository gameDataRepository;

        public GameService()
        {
            shipRepository = new ShipRepository();
            enemyRepository = new EnemyRepository();
            bulletRepository = new BulletRepository();
            gameDataRepository = new GameDataRepository();
        }

        public void StartGame()
        {
            // Initialize game logic
        }

        public void UpdateGame()
        {
            // Update game logic (move enemies, bullets, etc.)
        }

        public void DrawGame()
        {
            // Draw game state to console
        }
    }
}