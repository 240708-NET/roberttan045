using System.Collections.Generic;
using System.Linq;
using EldenRingApp.Data;
using EldenRingApp.Models;
using EldenRingApp.Repositories.Interfaces;

namespace EldenRingApp.Repositories.Implementations
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly EldenRingContext _context;

        public CharacterRepository(EldenRingContext context)
        {
            _context = context;
        }

        public Character GetCharacterById(int id)
        {
            var character = _context.Characters.Find(id);
            if (character == null)
            {
                throw new InvalidOperationException("Character not found");
            }
            return character;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _context.Characters.ToList();
        }

        public void AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public void UpdateCharacter(Character character)
        {
            _context.Characters.Update(character);
            _context.SaveChanges();
        }

        public void DeleteCharacter(int id)
        {
            var character = _context.Characters.Find(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                _context.SaveChanges();
            }
        }
    }
}