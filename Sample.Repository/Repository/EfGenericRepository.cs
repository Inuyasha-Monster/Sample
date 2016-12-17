using Sample.Core.DataBaseEntity;
using Sample.Core.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Sample.Repository.EntityFramework.DbContexts;

namespace Sample.Repository.Repository
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        public EfGenericRepository(IDbContext context)
        {
            this._context = context;
        }

        public IQueryable<TEntity> All()
        {
            return this._context.Set<TEntity>();
        }

        public IQueryable<TEntity> AllByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate);
        }

        public long Count(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate).LongCount();
        }

        public TEntity GetEntityByID(int id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetPageQuery(int pageSize, int pager, Expression<Func<TEntity, bool>> where)
        {
            if (pager - 1 <= 0)
            {
                pager = 1;
            }
            if (pageSize <= 10)
            {
                pageSize = 10;
            }
            return this._context.Set<TEntity>().Where(where).Skip(pageSize - 1).Take(pageSize);
        }
    }
}
