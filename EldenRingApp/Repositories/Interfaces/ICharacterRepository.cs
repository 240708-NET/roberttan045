using EldenRingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EldenRingApp.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character> GetByIdAsync(int id);
        Task AddAsync(Character character);
        Task UpdateAsync(Character character);
        Task DeleteAsync(int id);
    }
}