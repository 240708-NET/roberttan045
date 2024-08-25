using System.Collections.Generic;
using System.Linq;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public class TrapRepository : ITrapRepository
    {
        private readonly PuzzleDungeonContext _context;

        public TrapRepository(PuzzleDungeonContext context)
        {
            _context = context;
        }

        public IEnumerable<Trap> GetAllTraps()
        {
            return _context.Traps.ToList();
        }

        public Trap GetTrapById(int id)
        {
            return _context.Traps.Find(id);
        }

        public void AddTrap(Trap trap)
        {
            _context.Traps.Add(trap);
        }

        public void UpdateTrap(Trap trap)
        {
            _context.Traps.Update(trap);
        }

        public void DeleteTrap(int id)
        {
            var trap = _context.Traps.Find(id);
            if (trap != null)
            {
                _context.Traps.Remove(trap);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}