using System.Collections.Generic;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        void Save();
    }
}