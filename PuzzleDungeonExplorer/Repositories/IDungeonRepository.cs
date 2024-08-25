using System.Collections.Generic;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public interface IDungeonRepository
    {
        IEnumerable<Dungeon> GetAllDungeons();
        Dungeon GetDungeonById(int id);
        void AddDungeon(Dungeon dungeon);
        void UpdateDungeon(Dungeon dungeon);
        void DeleteDungeon(int id);
        void Save();
    }
}