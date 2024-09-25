using MonopolyGame.Models;
using MonopolyGame.Data;

namespace MonopolyGame.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly GameDbContext _context;
        public IRepository<Player> Players { get; private set; }
        public IRepository<Property> Properties { get; private set; }

        public UnitOfWork(GameDbContext context)
        {
            _context = context;
            Players = new Repository<Player>(context);
            Properties = new Repository<Property>(context);
        }

        public void Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}