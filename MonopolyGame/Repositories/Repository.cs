using MonopolyGame.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyGame.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GameDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(GameDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T Get(int id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Remove(T entity) => _dbSet.Remove(entity);
    }
}