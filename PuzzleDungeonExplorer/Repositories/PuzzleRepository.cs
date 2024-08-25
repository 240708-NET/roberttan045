using System.Collections.Generic;
using System.Linq;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public class PuzzleRepository : IPuzzleRepository
    {
        private readonly PuzzleDungeonContext _context;

        public PuzzleRepository(PuzzleDungeonContext context)
        {
            _context = context;
        }

        public IEnumerable<Puzzle> GetAllPuzzles()
        {
            return _context.Puzzles.ToList();
        }

        public Puzzle GetPuzzleById(int id)
        {
            return _context.Puzzles.Find(id);
        }

        public void AddPuzzle(Puzzle puzzle)
        {
            _context.Puzzles.Add(puzzle);
        }

        public void UpdatePuzzle(Puzzle puzzle)
        {
            _context.Puzzles.Update(puzzle);
        }

        public void DeletePuzzle(int id)
        {
            var puzzle = _context.Puzzles.Find(id);
            if (puzzle != null)
            {
                _context.Puzzles.Remove(puzzle);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}