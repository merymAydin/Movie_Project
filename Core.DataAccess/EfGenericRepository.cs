using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public abstract class EfGenericRepository<T, TContext> : IGenericRepository<T> 
        where T : class, IEntity, new()
        where TContext : DbContext
    {
        // protected readonly TContext _context { get; }
        protected TContext Context { get; }
        protected DbSet<T> _dbSet;
        protected EfGenericRepository(TContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Update(entity);
            Context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            Context.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter); //singleordefault()
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? _dbSet : _dbSet.Where(filter);
            // return filter == null ? _dbSet.AsQueryable() : _dbSet.Where(filter).AsQueryable();
        }
        
    }
}
