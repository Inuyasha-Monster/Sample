using Sample.Core.DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.IBaseRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetEntityByID(int id);

        IQueryable<TEntity> All();

        IQueryable<TEntity> AllByCondition(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetPageQuery(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> where);

        long Count(Expression<Func<TEntity, bool>> predicate);
    }
}
