using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MonopolyGame.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}