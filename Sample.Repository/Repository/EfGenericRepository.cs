using Sample.Core.DataBaseEntity;
using Sample.Core.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sample.Repository.Repository
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> AllByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
