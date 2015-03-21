using System;
using System.Linq;
using System.Linq.Expressions;

using App.Domain.Entities;

namespace App.Domain.RepositoryInterfaces
{
    public interface IRepository<TEntity>
          where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);

        void SoftDelete(int id, int deletedBy);
        void SoftDelete(Expression<Func<TEntity, bool>> where, int deletedBy);

        void Delete(int id);
        void Delete(Expression<Func<TEntity, bool>> where);

        TEntity FindOne(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<T> Set<T>() where T : class;

        bool Any(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);

        bool SaveChanges();

        int Count(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
