using Sample.Core.UnitOfWork;
using Sample.Repository.EntityFramework.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        private System.Data.Entity.DbContextTransaction _transaction;

        public UnitOfWork(IDbContext context)
        {
            this._context = context;
        }

        public void BeginTranscope()
        {
            this._transaction = this._context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            if (this._transaction != null)
            {
                this._transaction.Commit();
                return true;
            }
            else
            {
                return this._context.SaveChanges() > 0;
            }
        }

        public bool RegisteDelete<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public bool RegisteDirty<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public bool RegisteManyDelete<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            this._context.Set<TEntity>().RemoveRange(entities);
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public bool RegisteManyDirty<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var item in entities)
            {
                this._context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;
            }
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public bool RegisteManyNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            this._context.Set<TEntity>().AddRange(entities);
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public bool RegisteNew<TEntity>(TEntity entity) where TEntity : class
        {
            this._context.Set<TEntity>().Add(entity);
            if (this._transaction != null)
                return this._context.SaveChanges() > 0;
            return true;
        }

        public void Rollback()
        {
            if (this._transaction != null)
                this._transaction.Rollback();
        }
    }
}
