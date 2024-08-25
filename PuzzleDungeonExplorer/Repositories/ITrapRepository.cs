using System.Collections.Generic;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public interface ITrapRepository
    {
        IEnumerable<Trap> GetAllTraps();
        Trap GetTrapById(int id);
        void AddTrap(Trap trap);
        void UpdateTrap(Trap trap);
        void DeleteTrap(int id);
        void Save();
    }
}