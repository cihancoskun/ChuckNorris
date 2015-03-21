using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using App.Domain.Entities;
using App.Domain.RepositoryInterfaces;

namespace App.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected AppDbContext Context;

        public Repository()
        {
            Context = new AppDbContext();
        }

        public virtual TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                Context.Set<TEntity>().Remove(item);
            }
        }

        public virtual void SoftDelete(int id, int deletedBy)
        {
            var entity = Context.Set<TEntity>().Find(id);
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = deletedBy;
            entity.IsDeleted = true;
            entity.IsActive = false;
        }

        public void SoftDelete(Expression<Func<TEntity, bool>> where, int deletedBy)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                item.DeletedAt = DateTime.Now;
                item.DeletedBy = deletedBy;
                item.IsDeleted = true;
                item.IsActive = false;
            }
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        public bool Any(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).Any();
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).FirstOrDefault();
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var items = where != null
                ? Context.Set<TEntity>().Where(s => !s.IsDeleted).Where(where)
                : Context.Set<TEntity>().Where(s => !s.IsDeleted);

            foreach (var property in includeProperties)
            {
                items.Include(property);
            }

            return items;
        }
 
        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }

        public int Count(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return FindAll(where, includeProperties).Count();
        }

        public void Dispose()
        {
            if (null != Context)
            {
                Context.Dispose();
            }
        }
    }
}
