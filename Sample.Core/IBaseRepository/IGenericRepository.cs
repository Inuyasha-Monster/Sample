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

        void Add(TEntity entity);

        void AddMany(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateMany(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveMany(IEnumerable<TEntity> entities);

        IQueryable<TEntity> All();

        IQueryable<TEntity> AllByCondition(Expression<Func<TEntity, bool>> predicate);

        long Count(Expression<Func<TEntity, bool>> predicate);
    }
}
