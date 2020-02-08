using Core;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Registries
{
    public class Repository<TEntity>
        : IRepository<TEntity>
        where TEntity : class
    {
        protected FaxDbContext _faxDbContext { get; set; }
        public Repository(FaxDbContext faxDbContext)
        {
            _faxDbContext = faxDbContext;
        }
        public async Task<bool> Add(TEntity entity)
        {
            await _faxDbContext.AddAsync(entity);
            return true;
        }

        public async Task Delete(TEntity entity)
        {
            _faxDbContext.Remove(entity);
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _faxDbContext.Set<TEntity>().FindAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _faxDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _faxDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            _faxDbContext.Set<TEntity>().Update(entity);
        }
    }
}
