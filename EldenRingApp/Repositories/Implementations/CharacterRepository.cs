using EldenRingApp.Data;
using EldenRingApp.Models;
using EldenRingApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EldenRingApp.Repositories.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly EldenRingContext _context;

        public CharacterRepository(EldenRingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task AddAsync(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }
    }
}