using AlintaEnergy_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AlintaEnergy_API.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<List<T>> GetEntities { get; }
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByConditionSingle(Expression<Func<T, bool>> expression);

        void Remove(T entity);
        void Add(T entity);
        void Update(T entity);
    }
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AlintaEnergy_API_DBContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;
        public Task<List<T>> GetEntities => Entities.ToListAsync();

        public GenericRepository(AlintaEnergy_API_DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await Entities
                .Where(expression).ToListAsync();
        }

        public async Task<T> FindByConditionSingle(Expression<Func<T, bool>> expression)
        {
            return await Entities.FirstAsync(expression);
        }
    }
}
