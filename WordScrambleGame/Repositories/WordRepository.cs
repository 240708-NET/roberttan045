using System.Collections.Generic;
using System.Linq;
using WordScrambleGame.Models;

namespace WordScrambleGame.Repositories
{
    public class WordRepository : IRepository<Word>
    {
        private readonly GameContext _context;

        public WordRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Word> GetAll() => _context.Words.ToList();
        public Word GetById(int id) => _context.Words.Find(id);
        public void Add(Word word) => _context.Words.Add(word);
        public void Update(Word word) => _context.Words.Update(word);
        public void Delete(int id)
        {
            var word = _context.Words.Find(id);
            if (word != null) _context.Words.Remove(word);
        }
        public void Save() => _context.SaveChanges();
    }
}