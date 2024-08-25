using System.Collections.Generic;
using System.Linq;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public class DungeonRepository : IDungeonRepository
    {
        private readonly PuzzleDungeonContext _context;

        public DungeonRepository(PuzzleDungeonContext context)
        {
            _context = context;
        }

        public IEnumerable<Dungeon> GetAllDungeons()
        {
            return _context.Dungeons.ToList();
        }

        public Dungeon GetDungeonById(int id)
        {
            return _context.Dungeons.Find(id);
        }

        public void AddDungeon(Dungeon dungeon)
        {
            _context.Dungeons.Add(dungeon);
        }

        public void UpdateDungeon(Dungeon dungeon)
        {
            _context.Dungeons.Update(dungeon);
        }

        public void DeleteDungeon(int id)
        {
            var dungeon = _context.Dungeons.Find(id);
            if (dungeon != null)
            {
                _context.Dungeons.Remove(dungeon);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}