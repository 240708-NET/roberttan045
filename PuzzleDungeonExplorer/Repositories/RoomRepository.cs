using System.Collections.Generic;
using System.Linq;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Models;

namespace PuzzleDungeonExplorer.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly PuzzleDungeonContext _context;

        public RoomRepository(PuzzleDungeonContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        public Room GetRoomById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}