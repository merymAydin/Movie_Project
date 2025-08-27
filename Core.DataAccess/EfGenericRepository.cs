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
        public async Task AddAsync(T entity)
        {
            _dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? await _dbSet.ToListAsync()
                : await _dbSet.Where(filter).ToListAsync();
        }

        public IQueryable<T> GetQueryableAsync(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null
                ? _dbSet
                : _dbSet.Where(filter);
        }
    }
}
