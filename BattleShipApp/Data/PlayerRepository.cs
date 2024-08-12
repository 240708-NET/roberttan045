using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BattleShipApp.Models;
using BattleShipApp.DataAccess;

namespace BattleShipApp.Data
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly BattleShipContext _context;

        public PlayerRepository(BattleShipContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task AddAsync(Player entity)
        {
            await _context.Players.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Player entity)
        {
            _context.Players.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}