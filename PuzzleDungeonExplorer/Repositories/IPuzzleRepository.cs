using System.Collections.Generic;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public interface IPuzzleRepository
    {
        IEnumerable<Puzzle> GetAllPuzzles();
        Puzzle GetPuzzleById(int id);
        void AddPuzzle(Puzzle puzzle);
        void UpdatePuzzle(Puzzle puzzle);
        void DeletePuzzle(int id);
        void Save();
    }
}