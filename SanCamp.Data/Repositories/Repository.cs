using SanCamp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace SanCamp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        public readonly UserDbContext _context;

        public Repository(UserDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void UpdateStatus(T id)
        {
            
        }
    }
}
