
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Picole.WebApi.Repositories.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        void Remove(TEntity entity);
    }
}
