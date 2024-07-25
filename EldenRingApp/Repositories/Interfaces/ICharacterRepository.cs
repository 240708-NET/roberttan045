using System.Collections.Generic;
using EldenRingApp.Models;

namespace EldenRingApp.Repositories.Interfaces
{
    public interface ICharacterRepository
    {
        Character? GetCharacterById(int id); // Allow nullable return type
        IEnumerable<Character> GetAllCharacters();
        void AddCharacter(Character character);
        void UpdateCharacter(Character character);
        void DeleteCharacter(int id);
    }
}