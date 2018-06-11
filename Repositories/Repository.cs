using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Picole.WebApi.Models;
using Picole.WebApi.Repositories.Core;

namespace Picole.WebApi.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : class
    {
        private readonly PicoleDbContext _dbContext;

        public Repository(PicoleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>()
                .Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>()
                .Update(entity);
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToList();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {   
            var query = _dbContext.Set<TEntity>().AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).FirstOrDefault(predicate);
            
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>()
                .Where(predicate);

            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
