using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BattleShipApp.Models;
using BattleShipApp.DataAccess;

namespace BattleShipApp.Data
{
    public class GameRepository : IRepository<Game>
    {
        private readonly BattleShipContext _context;

        public GameRepository(BattleShipContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task AddAsync(Game entity)
        {
            await _context.Games.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game entity)
        {
            _context.Games.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}